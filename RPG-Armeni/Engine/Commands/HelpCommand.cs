using System.IO;
using RPGArmeni.Interfaces;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
	public class HelpCommand : GameCommand
	{
		public HelpCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute()
		{
			var helpInfo = File.ReadAllText("./UI/Utility/HelpInfo.txt");
			ConsoleRenderer.WriteLine(helpInfo);
		}
	}
}