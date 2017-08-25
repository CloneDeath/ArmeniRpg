using System;
using System.Linq;
using ArmeniRpg.Interfaces;
using ArmeniRpg.Models.Items;

namespace ArmeniRpg.Engine.Commands
{
	public class MovePlayerCommand : ICommand
	{
		private void CollectItem(IGameEngine gameEngine, IGameItem currentItem)
		{
			currentItem.ItemState = ItemState.Collected;
			gameEngine.Player.Inventory.BackPack.LootItem(currentItem);
			gameEngine.SetStatus($"{currentItem.GetType().Name} collected!");
		}

		private void EnterBattle(IGameEngine engine, ICharacter currentEnemy)
		{
			engine.SetStatus($"An enemy {currentEnemy.GetType().Name} is approaching. Prepare for battle!");
			while (true)
			{
				engine.Player.Attack(currentEnemy);
				engine.SetStatus($"You smash the {currentEnemy.GetType().Name} for {engine.Player.Damage} damage!");

				if (currentEnemy.Health <= 0)
				{
					engine.SetStatus("Enemy killed!");
					engine.SetStatus($"Health Remaining: {engine.Player.Health}");
					engine.RemoveEnemy(currentEnemy);
					return;
				}

				currentEnemy.Attack(engine.Player);
				engine.SetStatus($"The {currentEnemy.GetType().Name} hits you for {currentEnemy.Damage} damage!");

				if (engine.Player.Health < 150 && engine.Player.Inventory.BackPack.SlotList.Any(x =>
					    x.GameItem is HealthPotion
					    || x.GameItem is HealthBonusPotion))
				{
					engine.Player.SelfHeal(engine);
				}

				if (engine.Player.Health <= 0)
				{
					engine.IsRunning = false;
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