using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class HealCommand : GameCommand
	{
		public HealCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute()
		{
			Engine.Player.SelfHeal();
		}
	}
}