using System;
using System.Linq;
using RPGArmeni.Exceptions;
using RPGArmeni.Interfaces;
using RPGArmeni.Models.Items;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
	public class MovePlayerCommand : ICommand
	{
		private void CollectItem(IGameEngine gameEngine, IGameItem currentItem)
		{
			currentItem.ItemState = ItemState.Collected;
			gameEngine.Player.Inventory.BackPack.LootItem(currentItem);
			ConsoleRenderer.WriteLine("{0} collected!", currentItem.GetType().Name);
		}

		private void EnterBattle(IGameEngine gameEngine, ICharacter currentEnemy)
		{
			ConsoleRenderer.WriteLine(
				"An enemy {0} is approaching. Prepare for battle!",
				currentEnemy.GetType().Name);
			while (true)
			{
				gameEngine.Player.Attack(currentEnemy);
				ConsoleRenderer.WriteLine("You smash the {0} for {1} damage!",
					currentEnemy.GetType().Name, gameEngine.Player.Damage);

				if (currentEnemy.Health <= 0)
				{
					ConsoleRenderer.WriteLine("Enemy killed!");
					ConsoleRenderer.WriteLine("Health Remaining: {0}", gameEngine.Player.Health);
					gameEngine.RemoveEnemy(currentEnemy);
					return;
				}

				currentEnemy.Attack(gameEngine.Player);
				ConsoleRenderer.WriteLine("The {0} hits you for {1} damage!",
					currentEnemy.GetType().Name, currentEnemy.Damage);

				if (gameEngine.Player.Health < 150 && gameEngine.Player.Inventory.BackPack.SlotList.Any(x =>
					    x.GameItem is HealthPotion
					    || x.GameItem is HealthBonusPotion))
				{
					try
					{
						gameEngine.Player.SelfHeal();
					}
					catch (NoHealthPotionsException ex)
					{
						ConsoleRenderer.WriteLine(ex.Message);
					}
				}

				if (gameEngine.Player.Health <= 0)
				{
					gameEngine.IsRunning = false;
					GameStateScreens.ShowGameOverScreen();
					return;
				}
			}
		}

		private IGameItem FindItem(IGameEngine gameEngine)
		{
			return gameEngine
				.Items
				.FirstOrDefault(e => e.Position.X == gameEngine.Player.Position.X
				                     && e.Position.Y == gameEngine.Player.Position.Y
				                     && e.ItemState == ItemState.Available);
		}

		private ICharacter FindEnemy(IGameEngine gameEngine)
		{
			return gameEngine
				.Entities
				.FirstOrDefault(x => x.Position.X == gameEngine.Player.Position.X
				                     && x.Position.Y == gameEngine.Player.Position.Y) as ICharacter;
		}

		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.LeftArrow
			       || keyInfo.Key == ConsoleKey.RightArrow
			       || keyInfo.Key == ConsoleKey.UpArrow
			       || keyInfo.Key == ConsoleKey.DownArrow;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			MovePlayer(gameEngine, keyInfo);
		}

		private void MovePlayer(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.Player.Move(keyInfo);

			var currentEnemy = FindEnemy(gameEngine);

			if (currentEnemy != null)
			{
				EnterBattle(gameEngine, currentEnemy);
				return;
			}

			var currentItem = FindItem(gameEngine);
			if (currentItem != null) CollectItem(gameEngine, currentItem);
		}
	}
}