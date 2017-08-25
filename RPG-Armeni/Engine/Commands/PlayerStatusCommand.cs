using System;
using System.Linq;
using RPGArmeni.Interfaces;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
	public class PlayerStatusCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.S;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			ConsoleRenderer.WriteLine(gameEngine.Player.ToString());
			ConsoleRenderer.WriteLine(
				"Number of enemies left: {0}",
				gameEngine.Entities.Count());
		}
	}
}