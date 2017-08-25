using System;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class BoostHealthCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.I;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.Player.DrinkHealthBonusPotion();
		}
	}
}