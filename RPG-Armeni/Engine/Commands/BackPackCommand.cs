using System;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class BackPackCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.B;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.Player.Inventory.BackPack.ListItems();
		}
	}
}