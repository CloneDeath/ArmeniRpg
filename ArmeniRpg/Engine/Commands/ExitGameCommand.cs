using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Engine.Commands
{
	public class ExitGameCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.Escape;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.IsRunning = false;
		}
	}
}