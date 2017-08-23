using System;
using RPGArmeni.Interfaces;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
	public class PrintMapCommand : GameCommand
	{
		public PrintMapCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute()
		{
			ConsoleRenderer.BackgroundColor(ConsoleColor.Green);
			ConsoleRenderer.ForegroundColor(ConsoleColor.Red);
			for (var i = 0; i < Engine.Map.Height; i++)
			{
				for (var j = 0; j < Engine.Map.Width; j++)
				{
					switch (Engine.Map.Matrix[i, j])
					{
						case 'H':
						case 'B':
							ConsoleRenderer.ForegroundColor(ConsoleColor.Blue);
							break;
						case 'P':
							ConsoleRenderer.ForegroundColor(ConsoleColor.White);
							break;
						case 'A':
						case 'S':
							ConsoleRenderer.ForegroundColor(ConsoleColor.DarkCyan);
							break;
						case '~':
							ConsoleRenderer.BackgroundColor(ConsoleColor.DarkBlue);
							ConsoleRenderer.ForegroundColor(ConsoleColor.Cyan);
							break;
						default:
							ConsoleRenderer.ForegroundColor(ConsoleColor.Red);
							break;
					}
					ConsoleRenderer.Write(Engine.Map.Matrix[i, j].ToString());
				}

				ConsoleRenderer.WriteLine(string.Empty);
			}

			ConsoleRenderer.ResetColor();
		}
	}
}