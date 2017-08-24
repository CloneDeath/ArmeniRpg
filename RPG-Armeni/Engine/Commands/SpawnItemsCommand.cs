using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class SpawnItemsCommand
	{
		public void Execute(IGameEngine engine)
		{
			for (var i = 0; i < engine.NumberOfItems; i++)
			{
				var newItem = ItemFactory.Instance.CreateItem();
				engine.AddItem(newItem);
			}
		}
	}
}