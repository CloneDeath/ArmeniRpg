using System;
using System.Collections.Generic;
using RPGArmeni.Engine.Commands;
using RPGArmeni.Engine.Factories;
using RPGArmeni.Exceptions;
using RPGArmeni.Interfaces;
using RPGArmeni.Models;
using RPGArmeni.UI;

namespace RPGArmeni.Engine
{
	public class GameEngine : IGameEngine
	{
		public const int MapHeight = 20;
		public const int MapWidth = 50;
		private const int DefaultNumberOfEnemies = 20;
		private const int DefaultNumberOfItems = 20;

		private readonly IList<IGameObject> characters;
		private readonly IList<IGameItem> items;

		public GameEngine()
		{
			characters = new List<IGameObject>();
			items = new List<IGameItem>();
			Map = new Map(MapHeight, MapWidth);
			InitializeMap();
			NumberOfEnemies = DefaultNumberOfEnemies;
			NumberOfItems = DefaultNumberOfItems;
		}

		public IEnumerable<IGameObject> Characters => characters;

		public IEnumerable<IGameItem> Items => items;

		public IPlayer Player { get; private set; }

		public IMap Map { get; }

		public int NumberOfItems { get; }

		public int NumberOfEnemies { get; }

		public bool IsRunning { get; set; }

		public virtual void Run()
		{
			IsRunning = true;
			Player = PlayerFactory.Instance.CreatePlayer();
			Player.Engine = this;

			IGameCommand spawnEnemies = new SpawnEnemiesCommand(this);
			spawnEnemies.Execute();

			IGameCommand spawnItems = new SpawnItemsCommand(this);
			spawnItems.Execute();
			ConsoleRenderer.WriteLine("Press F1 to get playing instructions.");

			while (IsRunning)
			{
				IKeyInfo commandKey = new KeyInfo();

				try
				{
					ExecuteCommand(commandKey);
				}
				catch (ObjectOutOfBoundsException ex)
				{
					ConsoleRenderer.WriteLine(ex.Message);
				}
				catch (Exception ex)
				{
					ConsoleRenderer.WriteLine(ex.Message);
				}

				if (characters.Count == 0)
				{
					IsRunning = false;
					ConsoleRenderer.WriteLine("All your enemies are dead. Congratulations! You are the only one left on earth.");
				}
			}
		}

		public void AddItem(IGameItem itemToBeAdded)
		{
			items.Add(itemToBeAdded);
		}

		public void AddEnemy(ICharacter enemyToBeAdded)
		{
			characters.Add(enemyToBeAdded);
		}

		public void RemoveItem(IGameItem itemToBeRemoved)
		{
			items.Remove(itemToBeRemoved);
		}

		public void RemoveEnemy(ICharacter enemyToBeRemoved)
		{
			characters.Remove(enemyToBeRemoved);
		}

		protected virtual void ExecuteCommand(IKeyInfo commandKey)
		{
			IGameCommand currentCommand;
			switch (commandKey.Key)
			{
				case ConsoleKey.F1:
					currentCommand = new HelpCommand(this);
					currentCommand.Execute();
					break;
				case ConsoleKey.M:
					ConsoleRenderer.Clear();
					currentCommand = new PrintMapCommand(this);
					currentCommand.Execute();
					break;
				case ConsoleKey.LeftArrow:
				case ConsoleKey.RightArrow:
				case ConsoleKey.UpArrow:
				case ConsoleKey.DownArrow:
					ConsoleRenderer.Clear();
					RenderSuccessMoveMessage(commandKey);
					currentCommand = new MovePlayerCommand(this);
					currentCommand.Execute(commandKey);
					currentCommand = new PrintMapCommand(this);
					currentCommand.Execute();
					break;
				case ConsoleKey.S:
					currentCommand = new PlayerStatusCommand(this);
					currentCommand.Execute();
					break;
				case ConsoleKey.C:
					ConsoleRenderer.Clear();
					break;
				case ConsoleKey.H:
					currentCommand = new HealCommand(this);
					currentCommand.Execute();
					break;
				case ConsoleKey.I:
					currentCommand = new BoostHealthCommand(this);
					currentCommand.Execute();
					break;
				case ConsoleKey.R:
					Player.Inventory.BackPack.RemoveLastItem();
					break;
				case ConsoleKey.B:
					currentCommand = new BackPackCommand(this);
					currentCommand.Execute();
					break;
				case ConsoleKey.Escape:
					ExitApplication();
					break;
				default:
				{
					throw new ArgumentException("Unknown command");
				}
			}
		}

		private void ExitApplication()
		{
			IsRunning = false;
			ConsoleRenderer.WriteLine("Good Bye! Do come again to play this great game!");
		}

		private static void RenderSuccessMoveMessage(IKeyInfo commandKey)
		{
			ConsoleRenderer.WriteLine(
				"Moved " +
				commandKey.Key.ToString().ToLower().Substring(0, commandKey.Key.ToString().Length - 5));
		}

		private void InitializeMap()
		{
			for (var i = 0; i < Map.Height; i++)
			for (var j = 0; j < Map.Width; j++)
				if (i > Map.Height - 5)
					Map.Matrix[i, j] = '~';
				else
					Map.Matrix[i, j] = '.';
		}
	}
}