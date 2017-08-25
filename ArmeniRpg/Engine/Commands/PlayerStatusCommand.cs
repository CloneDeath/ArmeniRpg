using System;
using System.Linq;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Engine.Commands
{
	public class PlayerStatusCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.S;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.SetStatus(gameEngine.Player.ToString());
			gameEngine.SetStatus($"Number of enemies left: {gameEngine.Entities.Count()}");
		}
	}
}