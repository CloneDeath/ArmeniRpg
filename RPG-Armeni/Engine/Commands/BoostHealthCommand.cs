using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class BoostHealthCommand : GameCommand
	{
		public BoostHealthCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute()
		{
			Engine.Player.DrinkHealthBonusPotion();
		}
	}
}