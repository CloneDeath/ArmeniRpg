using System;
using System.IO;
using ArmeniRpg.Interfaces;
using ArmeniRpg.UI;

namespace ArmeniRpg.Engine.Commands
{
	public class HelpCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.F1
			       || keyInfo.Key == ConsoleKey.Help
			       || keyInfo.Character == '?';
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			var helpInfo = File.ReadAllText("./UI/Utility/HelpInfo.txt");
			ConsoleRenderer.WriteLine(helpInfo);
		}
	}
}