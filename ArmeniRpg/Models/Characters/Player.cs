using System;
using System.Linq;
using System.Text;
using ArmeniRpg.Exceptions;
using ArmeniRpg.Interfaces;
using ArmeniRpg.Models.Containers;
using ArmeniRpg.Models.Items;
using ArmeniRpg.UI;

namespace ArmeniRpg.Models.Characters
{
	public class Player : Character, IPlayer
	{
		private int _startHealth;

		public Player(string name, IRace race) : base(race.Damage, race.Health)
		{
			Name = name;
			Race = race;
			Inventory = new Inventory();
			_startHealth = race.Health;
		}

		public string Name { get; set; }

		public int DefensiveBonus { get; set; }
		
		public IRace Race { get; }

		public IInventory Inventory { get; }

		public IGameEngine Engine { get; set; }

		public void Move(IKeyInfo directionKey)
		{
			switch (directionKey.Key)
			{
				case ConsoleKey.UpArrow:
					MoveUp();
					break;
				case ConsoleKey.DownArrow:
					MoveDown();
					break;
				case ConsoleKey.RightArrow:
					MoveRight();
					break;
				case ConsoleKey.LeftArrow:
					MoveLeft();
					break;
				default:
				{
					throw new ArgumentException("Invalid direction.");
				}
			}
		}

		public void SelfHeal()
		{
			var healthPotionSlot = Inventory
				.BackPack
				.SlotList
				.FirstOrDefault(x => x.GameItem is HealthPotion);

			var potion = healthPotionSlot?.GameItem as HealthPotion;

			if (potion == null)
				throw new NoHealthPotionsException("There are no health potions left in the backpack.");

			var maximumHealthRestore = _startHealth;
			Health += potion.HealthRestore;
			ConsoleRenderer.WriteLine($"You restored {potion.HealthRestore} health points using Health Potion!");
			if (Health > maximumHealthRestore)
				Health = maximumHealthRestore;
			Inventory.BackPack.RemoveItem(healthPotionSlot);
		}

		public void DrinkHealthBonusPotion()
		{
			var healthBonusPotionSlot = Inventory
				.BackPack
				.SlotList
				.FirstOrDefault(x => x.GameItem is HealthBonusPotion);

			var potion = healthBonusPotionSlot?.GameItem as HealthBonusPotion;
			if (potion == null) 
				throw new NoHealthBonusPotionsException("There are no health bonus potions left in the backpack.");
			Health += potion.HealthBonus;
			ConsoleRenderer.WriteLine($"You boosted your health with {potion.HealthBonus} points using Health Bonus Potion!");
			_startHealth += potion.HealthBonus;
			Inventory.BackPack.RemoveItem(healthBonusPotionSlot);
		}

		public override string ToString()
		{
			var output = new StringBuilder();
			output.AppendLine("Player stats:");
			output.AppendFormat($"Health: {Health}, Damage: {Damage}, Defensive Bonus: {DefensiveBonus}");
			return output.ToString();
		}

		private void MoveLeft()
		{
			if (Position.X - 1 < 0)
			{
				Engine.SetStatus("You have reached the border of the map.");
				return;
			}
			ChangePlayerCoordinates(-1, 0);
		}

		private void MoveRight()
		{
			if (Position.X + 1 >= Engine.Map.Width)
			{
				Engine.SetStatus("You have reached the border of the map.");
				return;
			}
			ChangePlayerCoordinates(1, 0);
		}

		private void MoveDown()
		{
			if (Position.Y + 1 >= Engine.Map.Height)
			{
				Engine.SetStatus("You have reached the border of the map.");
				return;
			}
			ChangePlayerCoordinates(0, 1);
		}

		private void MoveUp()
		{
			if (Position.Y - 1 < 0)
			{
				Engine.SetStatus("You have reached the border of the map.");
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