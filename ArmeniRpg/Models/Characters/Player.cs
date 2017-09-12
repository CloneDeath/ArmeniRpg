using System;
using ArmeniRpg.Interfaces;
using ArmeniRpg.Models.Containers;
using ArmeniRpg.Models.Items;

namespace ArmeniRpg.Models.Characters
{
	public class Player : Character, IPlayer
	{
		private int _maxHealth;
		public override int MaxHealth => _maxHealth;

		public Player(string name, IRace race) : base(race.Health)
		{
			Name = name;
			Race = race;
			Inventory = new Inventory();
			_maxHealth = race.Health;
		}

		public override int Damage => Race.Damage + Inventory.MainHandSlot.AttackBonus;

		public override string Name { get; }

		public int DefensiveBonus { get; set; }
		
		public IRace Race { get; }

		public IInventory Inventory { get; }

		public void Move(IGameEngine engine, IKeyInfo directionKey)
		{
			switch (directionKey.Key)
			{
				case ConsoleKey.UpArrow:
					MoveUp(engine);
					break;
				case ConsoleKey.DownArrow:
					MoveDown(engine);
					break;
				case ConsoleKey.RightArrow:
					MoveRight(engine);
					break;
				case ConsoleKey.LeftArrow:
					MoveLeft(engine);
					break;
				default:
				{
					throw new ArgumentException("Invalid direction.");
				}
			}
		}

		public void SelfHeal(IGameEngine engine)
		{
			var potion = Inventory.BackPack.GetItem<HealthPotion>();
			if (potion == null)
			{
				engine.PushStatus("There are no health potions left in the backpack.");
				return;
			}
			engine.PushStatus($"You restored {potion.HealthRestore} health points using Health Potion!");
			Health += potion.HealthRestore;
			if (Health > _maxHealth) {
				Health = _maxHealth;
			}
			Inventory.BackPack.RemoveItem(potion);
		}

		public void DrinkHealthBonusPotion(IGameEngine engine)
		{
			var potion = Inventory.BackPack.GetItem<HealthBonusPotion>();
			if (potion == null)
			{
				engine.PushStatus("There are no health bonus potions left in the backpack.");
				return;
			}
			engine.PushStatus($"You boosted your health with {potion.HealthBonus} points using Health Bonus Potion!");
			Health += potion.HealthBonus * 2;
			_maxHealth += potion.HealthBonus;
			Inventory.BackPack.RemoveItem(potion);
		}

		public void CollectItem(IGameEngine engine, IGameItem item)
		{
			if (Inventory.MainHandSlot.IsEmpty && Inventory.MainHandSlot.CanOccupy(item))
			{
				Inventory.MainHandSlot.SetItem(item);
				engine.PushStatus($"{item.Name} equiped to Main Hand.");
			} 
			else if (Inventory.BackPack.CanHoldItem(item))
			{
				Inventory.BackPack.HoldItem(item);
				engine.PushStatus($"{item.Name} placed in backpack.");
			}
			else
			{
				item.Position = Position;
				engine.AddItem(item);
			}
		}

		private void MoveLeft(IGameEngine engine)
		{
			if (Position.X - 1 < 0)
			{
				engine.PushStatus("You have reached the border of the map.");
				return;
			}
			ChangePlayerCoordinates(-1, 0);
		}

		private void MoveRight(IGameEngine engine)
		{
			if (Position.X + 1 >= engine.Map.Width)
			{
				engine.PushStatus("You have reached the border of the map.");
				return;
			}
			ChangePlayerCoordinates(1, 0);
		}

		private void MoveDown(IGameEngine engine)
		{
			if (Position.Y + 1 >= engine.Map.Height)
			{
				engine.PushStatus("You have reached the border of the map.");
				return;
			}
			ChangePlayerCoordinates(0, 1);
		}

		private void MoveUp(IGameEngine engine)
		{
			if (Position.Y - 1 < 0)
			{
				engine.PushStatus("You have reached the border of the map.");
				return;
			}
			ChangePlayerCoordinates(0, -1);
		}

		private void ChangePlayerCoordinates(int x, int y)
		{
			Position = new Position(Position.X + x, Position.Y + y);
		}

		public override char Symbol => '@';
		public override ConsoleColor Color => ConsoleColor.White;
	}
}