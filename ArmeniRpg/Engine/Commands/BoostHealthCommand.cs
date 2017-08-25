using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Engine.Commands
{
	public class BoostHealthCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.I;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.Player.DrinkHealthBonusPotion(gameEngine);
		}
	}
}