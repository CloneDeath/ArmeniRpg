using System;
using System.Linq;
using System.Reflection;
using ArmeniRpg.Attributes;
using ArmeniRpg.Engine.Factories;
using ArmeniRpg.Interfaces;
using ArmeniRpg.Models.Items;

namespace ArmeniRpg.Engine.Commands
{
	public class SpawnItemsCommand
	{
		public void Execute(IGameEngine engine)
		{
			for (var i = 0; i < engine.NumberOfItems; i++)
			{
				var newItem = CreateItem(engine);
				engine.AddItem(newItem);
			}
		}
		
		public IGameItem CreateItem(IGameEngine engine)
		{
			var current = RandomGenerator.GeneratePosition(engine.Map.Width, engine.Map.Height);

			var isEmptySpot = engine.IsEmpty(current);

			while (!isEmptySpot)
			{
				current = RandomGenerator.GeneratePosition(engine.Map.Width, engine.Map.Height);
				isEmptySpot = engine.IsEmpty(current);
			}
			var itemTypes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(type => type.CustomAttributes
					.Any(a => a.AttributeType == typeof(ItemAttribute)))
				.ToArray();
			
			var currentType = itemTypes[RandomGenerator.GenerateNumber(0, itemTypes.Length)];
			if (currentType.Name == "HealthPotion")
			{
				var potionType = RandomGenerator.GenerateNumber(0, 3);
				return new HealthPotion(current, GetPotionSize(potionType));
			}
			
			if (currentType.Name == "HealthBonusPotion")
			{
				
				var potionType = RandomGenerator.GenerateNumber(0, 3);
				return new HealthBonusPotion(current, GetBonusPotionSize(potionType));
			}
			
			return Activator.CreateInstance(currentType, current) as IGameItem;
		}

		public HealthPotionSize GetPotionSize(int value)
		{
			switch (value)
			{
				case 0: return HealthPotionSize.Minor;
				case 1: return HealthPotionSize.Normal;
				case 2: return HealthPotionSize.Major;
				default: return HealthPotionSize.Normal;
			}
		}
		
		public HealthBonusPotionSize GetBonusPotionSize(int value)
		{
			switch (value)
			{
				case 0: return HealthBonusPotionSize.Minor;
				case 1: return HealthBonusPotionSize.Normal;
				case 2: return HealthBonusPotionSize.Major;
				default: return HealthBonusPotionSize.Normal;
			}
		}
	}
}