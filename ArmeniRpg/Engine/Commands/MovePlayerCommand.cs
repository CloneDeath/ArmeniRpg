using System;
using System.Linq;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Engine.Commands
{
	public class MovePlayerCommand : ICommand
	{
		private void CollectItem(IGameEngine gameEngine, IGameItem currentItem)
		{
			gameEngine.RemoveItem(currentItem);
			gameEngine.Player.CollectItem(gameEngine, currentItem);
		}

		private void EnterBattle(IGameEngine engine, ICharacter currentEnemy)
		{
			while (true)
			{
				engine.Player.Attack(currentEnemy);
				engine.PushStatus($"You smash the {currentEnemy.Name} for {engine.Player.Damage} damage!");

				if (currentEnemy.Health <= 0)
				{
					engine.PushStatus($"Enemy {currentEnemy.Name} killed!");
					engine.RemoveEnemy(currentEnemy);
					return;
				}

				currentEnemy.Attack(engine.Player);
				engine.PushStatus($"The {currentEnemy.Name} hits you for {currentEnemy.Damage} damage!");

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
				.FirstOrDefault(e => e.Position == gameEngine.Player.Position);
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
			gameEngine.Player.Move(gameEngine, keyInfo);

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