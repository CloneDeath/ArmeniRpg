using System;
using System.Collections.Generic;
using RPGArmeni.Engine.Commands;
using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;
using RPGArmeni.Models;
using RPGArmeni.UI;

namespace RPGArmeni.Engine
{
	public class GameEngine : IGameEngine
	{
		public const int MapHeight = 20;
		public const int MapWidth = 50;

		private readonly IList<IGameObject> _characters;
		private readonly IList<IGameItem> _items;
		
		private readonly CommandFactory _commandFactory = new CommandFactory();
		
		public GameEngine()
		{
			_characters = new List<IGameObject>();
			_items = new List<IGameItem>();
			Map = new Map(MapHeight, MapWidth);
			InitializeMap();
		}

		public void RegisterCommand(ICommand command)
		{
			_commandFactory.RegisterCommand(command);
		}

		public IEnumerable<IGameObject> Characters => _characters;

		public IEnumerable<IGameItem> Items => _items;

		public IPlayer Player { get; private set; }

		public IMap Map { get; }

		public int NumberOfItems => 20;
		public int NumberOfEnemies => 20;

		public bool IsRunning { get; set; }

		private string _status = string.Empty;

		public virtual void Run()
		{
			IsRunning = true;
			Player = new PlayerFactory().CreatePlayer();
			Map.Matrix[Player.Position.X, Player.Position.Y] = Player.ObjectSymbol;
			Player.Engine = this;

			IGameCommand spawnEnemies = new SpawnEnemiesCommand(this);
			spawnEnemies.Execute();

			IGameCommand spawnItems = new SpawnItemsCommand(this);
			spawnItems.Execute();
			ConsoleRenderer.WriteLine("Press ? to get playing instructions.");

			while (IsRunning)
			{
				IKeyInfo commandKey = new KeyInfo();

				ConsoleRenderer.ResetColor();
				ConsoleRenderer.Clear();
				Console.WriteLine(_status);
				_status = string.Empty;
				
				try
				{
					_commandFactory.Execute(this, commandKey);
				}
				catch (Exception ex)
				{
					_status = ex.Message;
				}

				if (_characters.Count == 0)
				{
					IsRunning = false;
					ConsoleRenderer.WriteLine("All your enemies are dead. Congratulations! You are the only one left on earth.");
				}
			}
		}

		public void AddItem(IGameItem itemToBeAdded)
		{
			_items.Add(itemToBeAdded);
		}

		public void AddEnemy(ICharacter enemyToBeAdded)
		{
			_characters.Add(enemyToBeAdded);
		}

		public void RemoveItem(IGameItem itemToBeRemoved)
		{
			_items.Remove(itemToBeRemoved);
		}

		public void RemoveEnemy(ICharacter enemyToBeRemoved)
		{
			_characters.Remove(enemyToBeRemoved);
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