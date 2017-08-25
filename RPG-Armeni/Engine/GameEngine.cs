using System;
using System.Collections.Generic;
using System.Linq;
using RPGArmeni.Engine.Commands;
using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;
using RPGArmeni.Models;
using RPGArmeni.Models.Tiles;
using RPGArmeni.UI;

namespace RPGArmeni.Engine
{
	public class GameEngine : IGameEngine
	{
		private readonly IList<IEntity> _characters;
		private readonly IList<IGameItem> _items;
		
		private readonly CommandFactory _commandFactory = new CommandFactory();
		
		public GameEngine()
		{
			_characters = new List<IEntity>();
			_items = new List<IGameItem>();
			Map = new Map(50, 20);
			InitializeMap();
		}

		public void RegisterCommand(ICommand command)
		{
			_commandFactory.RegisterCommand(command);
		}

		public IEnumerable<IEntity> Entities => _characters;

		public IEnumerable<IGameItem> Items => _items;

		public IPlayer Player { get; private set; }

		public IMap Map { get; }

		public int NumberOfItems => 20;
		public int NumberOfEnemies => 20;

		public bool IsRunning { get; set; }

		private string _status = "Press ? for Help.";
		
		private readonly MapRenderer _renderer = new MapRenderer();

		public virtual void Run()
		{
			IsRunning = true;
			Player = new PlayerFactory().CreatePlayer();
			Player.Engine = this;

			new SpawnEnemiesCommand().Execute(this);
			new SpawnItemsCommand().Execute(this);

			while (IsRunning)
			{
				ConsoleRenderer.ResetColor();
				ConsoleRenderer.Clear();
				
				Console.WriteLine(_status);
				_renderer.Render(this, new Position(0, 1));
				
				_status = string.Empty;
				
				_commandFactory.Execute(this, new KeyInfo());

				if (_characters.Count == 0)
				{
					IsRunning = false;
					ConsoleRenderer.WriteLine("All your enemies are dead. Congratulations! You are the only one left on earth.");
				}
			}
		}

		public bool IsEmpty(Position position)
		{
			return Entities.All(c => c.Position != position)
			       && Items.All(i => i.Position != position)
			       && Player.Position != position;
		}

		public IEntity GetEntityAtPosition(Position position)
		{
			if (Player.Position == position) return Player;
			return Entities.FirstOrDefault(c => c.Position == position)
			       ?? Items.FirstOrDefault(c => c.Position == position);
		}

		public void SetStatus(string status)
		{
			_status = status;
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
			for (var y = 0; y < Map.Height; y++)
			{
				for (var x = 0; x < Map.Width; x++)
				{
					if (y > Map.Height - 5)
						Map[x, y] = new WaterTile();
					else
						Map[x, y] = new GrassTile();
				}
			}
		}
	}
}