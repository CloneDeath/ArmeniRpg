using System.Linq;
using RPGArmeni.Interfaces;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
	public class PlayerStatusCommand : GameCommand
	{
		public PlayerStatusCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute()
		{
			ConsoleRenderer.WriteLine(Engine.Player.ToString());

			ConsoleRenderer.WriteLine(
				"Number of enemies left: {0}",
				Engine.Characters.Count());
		}
	}
}