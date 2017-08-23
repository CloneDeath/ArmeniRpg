using System;
using System.Linq;
using System.Reflection;
using RPGArmeni.Attributes;
using RPGArmeni.Interfaces;
using RPGArmeni.Models.Items;

namespace RPGArmeni.Engine.Factories
{
	public class ItemFactory
	{
		private static ItemFactory instance;

		private ItemFactory()
		{
		}

		public static ItemFactory Instance
		{
			get
			{
				if (instance == null)
					instance = new ItemFactory();

				return instance;
			}
		}

		public IGameEngine Engine { get; set; }

		public IGameItem CreateItem()
		{
			var currentX = RandomGenerator.GenerateNumber(0, Engine.Map.Height);
			var currentY = RandomGenerator.GenerateNumber(0, Engine.Map.Width);

			var isEmptySpot = Engine.Map.Matrix[currentX, currentY] == '.';

			while (!isEmptySpot)
			{
				currentX = RandomGenerator.GenerateNumber(0, Engine.Map.Height);
				currentY = RandomGenerator.GenerateNumber(0, Engine.Map.Width);

				isEmptySpot = Engine.Map.Matrix[currentX, currentY] == '.';
			}
			var itemTypes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(type => type.CustomAttributes
					.Any(a => a.AttributeType == typeof(ItemAttribute)))
				.ToArray();
			var currentType = itemTypes[RandomGenerator.GenerateNumber(0, itemTypes.Length)];
			IGameItem currentItem;
			if (currentType.Name == "HealthPotion")
			{
				var potionType = RandomGenerator.GenerateNumber(0, 3);

				HealthPotionSize potionSize;

				switch (potionType)
				{
					case 0:
						potionSize = HealthPotionSize.Minor;
						break;
					case 1:
						potionSize = HealthPotionSize.Normal;
						break;
					case 2:
						potionSize = HealthPotionSize.Major;
						break;
					default:
						throw new ArgumentOutOfRangeException("Invalid potion type.");
				}

				currentItem = new HealthPotion(new Position(currentX, currentY), potionSize);
				Engine.Map.Matrix[currentX, currentY] = currentItem.ObjectSymbol;
				return currentItem;
			}
			if (currentType.Name == "HealthBonusPotion")
			{
				var potionType = RandomGenerator.GenerateNumber(0, 3);

				HealthBonusPotionSize potionSize;

				switch (potionType)
				{
					case 0:
						potionSize = HealthBonusPotionSize.Minor;
						break;
					case 1:
						potionSize = HealthBonusPotionSize.Normal;
						break;
					case 2:
						potionSize = HealthBonusPotionSize.Major;
						break;
					default:
						throw new ArgumentOutOfRangeException("Invalid potion type.");
				}

				currentItem = new HealthBonusPotion(new Position(currentX, currentY), potionSize);
				Engine.Map.Matrix[currentX, currentY] = currentItem.ObjectSymbol;
				return currentItem;
			}
			currentItem = Activator.CreateInstance(currentType, new Position(currentX, currentY)) as IGameItem;
			Engine.Map.Matrix[currentX, currentY] = currentItem.ObjectSymbol;

			return currentItem;
		}
	}
}