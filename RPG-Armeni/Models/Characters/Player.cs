using System;
using System.Linq;
using System.Text;
using RPGArmeni.Exceptions;
using RPGArmeni.Interfaces;
using RPGArmeni.Models.Containers;
using RPGArmeni.Models.Items;
using RPGArmeni.UI;

namespace RPGArmeni.Models.Characters
{
	public class Player : Character, IPlayer
	{
		private const char DefaultPlayerSymbol = 'P';
		private const char DefaultEmptyMapSybmol = '.';
		private int defensiveBonus;
		private string name;

		private int startHealth;

		public Player(IPosition position, char objectSymbol, string name, IRace race)
			: base(position, objectSymbol, race.Damage, race.Health)
		{
			Name = name;
			Race = race;
			Inventory = new Inventory();
			startHealth = race.Health;
		}

		public string Name
		{
			get => name;

			private set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new InvalidNameException("Name cannot be null, empty or whitespace.");

				name = value;
			}
		}

		public int DefensiveBonus
		{
			get => defensiveBonus;
			private set
			{
				if (value < 0)
					throw new ArgumentException("Player defensive bonus.", "Defensive bonus value cannot be negative.");
				defensiveBonus = value;
			}
		}

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

			if (healthPotionSlot == null)
				throw new NoHealthPotionsException("There are no health potions left in the backpack.");

			var maximumHealthRestore = startHealth;
			Health += (healthPotionSlot.GameItem as HealthPotion).HealthRestore;
			ConsoleRenderer.WriteLine("You restored {0} health points using Health Potion!",
				(healthPotionSlot.GameItem as HealthPotion).HealthRestore);
			if (Health > maximumHealthRestore) //Healing potions only restore health to the player's current Health value.
				Health = maximumHealthRestore;
			Inventory.BackPack.RemoveItem(healthPotionSlot);
		}

		public void DrinkHealthBonusPotion()
		{
			var healthBonusPotionSlot = Inventory
				.BackPack
				.SlotList
				.FirstOrDefault(x => x.GameItem is HealthBonusPotion);

			if (healthBonusPotionSlot == null)
				throw new NoHealthBonusPotionsException("There are no health bonus potions left in the backpack.");
			Health += (healthBonusPotionSlot.GameItem as HealthBonusPotion).HealthBonus;
			ConsoleRenderer.WriteLine("You boosted your health with {0} points using Health Bonus Potion!",
				(healthBonusPotionSlot.GameItem as HealthBonusPotion).HealthBonus);
			startHealth += (healthBonusPotionSlot.GameItem as HealthBonusPotion).HealthBonus;
			Inventory.BackPack.RemoveItem(healthBonusPotionSlot);
		}

		public override string ToString()
		{
			var output = new StringBuilder();
			output.AppendLine("Player stats:");
			output.AppendFormat("Health: {0}, Damage: {1}, Defensive Bonus: {2}", Health, Damage, DefensiveBonus);
			return output.ToString();
		}

		private void MoveLeft()
		{
			if (Position.Y - 1 < 0)
				throw new ObjectOutOfBoundsException("You have reached the border of the map.");

			ChangePlayerCoordinates(0, -1);
		}

		private void MoveRight()
		{
			if (Position.Y + 1 >= Engine.Map.Width)
				throw new ObjectOutOfBoundsException("You have reached the border of the map.");

			ChangePlayerCoordinates(0, 1);
		}

		private void MoveDown()
		{
			if (Position.X + 1 >= Engine.Map.Height)
				throw new ObjectOutOfBoundsException("You have reached the border of the map.");

			ChangePlayerCoordinates(1, 0);
		}

		private void MoveUp()
		{
			if (Position.X - 1 < 0)
				throw new ObjectOutOfBoundsException("You have reached the border of the map.");

			ChangePlayerCoordinates(-1, 0);
		}

		private void ChangePlayerCoordinates(int x, int y)
		{
			Engine.Map.Matrix[Position.X, Position.Y] = DefaultEmptyMapSybmol;
			Position = new Position(Position.X + x, Position.Y + y);
			Engine.Map.Matrix[Position.X, Position.Y] = DefaultPlayerSymbol;
		}
	}
}