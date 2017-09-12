using System;
using System.Collections.Generic;
using System.Linq;
using ArmeniRpg.Engine.Commands;
using ArmeniRpg.Interfaces;
using ArmeniRpg.Models;
using ArmeniRpg.Models.Tiles;
using ArmeniRpg.UI;

namespace ArmeniRpg.Engine
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

		public IPlayer Player { get; set; }

		public IMap Map { get; }

		public int NumberOfItems => 20;
		public int NumberOfEnemies => 20;

		public bool IsRunning { get; set; }

		private readonly Queue<string> _statusList = new Queue<string>();
		
		private readonly MapRenderer _renderer = new MapRenderer();
		private readonly PlayerRenderer _playerRenderer = new PlayerRenderer();

		public virtual void Run(IConsoleWindow window)
		{
			_statusList.Enqueue("Press ? for Help.");
			
			IsRunning = true;

			new SpawnEnemiesCommand().Execute(this);
			new SpawnItemsCommand().Execute(this);

			while (IsRunning)
			{
				Console.CursorVisible = false;

				var mapWidth = window.Area.Width * 2 / 3;
				var mapHeight = window.Area.Height - 1;

				var mapArea = window.CreateConsoleArea(new Area(new Position(0, 1), new Size(mapWidth, mapHeight)));
				mapArea.Clear();
				_renderer.Render(this, mapArea);

				var playerArea = window.CreateConsoleArea(new Area(
					new Position(mapWidth, 1),
					new Size(window.Area.Width - mapWidth, mapHeight)));
				playerArea.Clear();
				_playerRenderer.Render(this, playerArea);
				
				
				var statusArea = window.CreateConsoleArea(new Area(Position.Zero, new Size(window.Area.Width, 1)));
				statusArea.Clear();
				while (_statusList.Any())
				{
					statusArea.Clear();
					var status = _statusList.Dequeue();
					if (_statusList.Any())
					{
						status += " <more>";
					}
					statusArea.Write(Position.Zero, status);
					window.Render();
					if (_statusList.Any())
					{
						KeyInfo.GetInput();
					}
				}
				
				window.Render();

				_commandFactory.Execute(this, KeyInfo.GetInput());

				if (_characters.Count != 0) continue;
				
				IsRunning = false;
				window.Clear();
				window.Write(Position.Zero, "All your enemies are dead. Congratulations!");
				window.Write(new Position(0, 1), "You are the only one left on earth.");
				window.Render();
			}
		}

		public bool IsEmpty(Position position)
		{
			if (!Map[position].CanStandOn) return false;
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

		public void PushStatus(string status)
		{
			_statusList.Enqueue(status);
		}

		public bool IsInBounds(Position position)
		{
			if (position.X < 0) return false;
			if (position.Y < 0) return false;
			if (position.X >= Map.Width) return false;
			if (position.Y >= Map.Height) return false;
			return true;
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
					var position = new Position(x, y);
					if (y > Map.Height - 5)
						Map[position] = new WaterTile();
					else
						Map[position] = new GrassTile();
				}
			}
		}
	}
}