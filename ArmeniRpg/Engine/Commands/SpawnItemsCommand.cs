using ArmeniRpg.Engine.Factories;
using ArmeniRpg.Interfaces;
using ArmeniRpg.Models.Items;
using ArmeniRpg.Models.Items.WeaponItems;

namespace ArmeniRpg.Engine.Commands
{
	public class SpawnItemsCommand
	{
		private static IGameItem[] Items => new IGameItem[]
		{
			new HealthBonusPotion(HealthBonusPotionSize.Minor),
			new HealthBonusPotion(HealthBonusPotionSize.Normal),
			new HealthBonusPotion(HealthBonusPotionSize.Major),
			new HealthPotion(HealthPotionSize.Minor),
			new HealthPotion(HealthPotionSize.Normal),
			new HealthPotion(HealthPotionSize.Major),
			new Axe(),
			new Sword()
		};
		
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
			
			var currentType = Items[RandomGenerator.GenerateNumber(0, Items.Length)];
			currentType.Position = current;
			return currentType;
		}
	}
}