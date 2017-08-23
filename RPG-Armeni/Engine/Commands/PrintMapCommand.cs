using System;
using RPGArmeni.Interfaces;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
	public class PrintMapCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.M;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			ConsoleRenderer.BackgroundColor(ConsoleColor.Green);
			ConsoleRenderer.ForegroundColor(ConsoleColor.Red);
			for (var i = 0; i < gameEngine.Map.Height; i++)
			{
				for (var j = 0; j < gameEngine.Map.Width; j++)
				{
					switch (gameEngine.Map.Matrix[i, j])
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
					ConsoleRenderer.Write(gameEngine.Map.Matrix[i, j].ToString());
				}
				ConsoleRenderer.WriteLine();
			}
			ConsoleRenderer.ResetColor();
		}
	}
}