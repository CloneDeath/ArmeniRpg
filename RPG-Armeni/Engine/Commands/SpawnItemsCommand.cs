using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class SpawnItemsCommand : GameCommand
	{
		public SpawnItemsCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute()
		{
			for (var i = 0; i < Engine.NumberOfItems; i++)
			{
				var newItem = ItemFactory.Instance.CreateItem();
				Engine.AddItem(newItem);
			}
		}
	}
}