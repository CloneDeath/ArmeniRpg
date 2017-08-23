using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class BackPackCommand : GameCommand
	{
		public BackPackCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute()
		{
			Engine.Player.Inventory.BackPack.ListItems();
		}
	}
}