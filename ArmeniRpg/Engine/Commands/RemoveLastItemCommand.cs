using System;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class RemoveLastItemCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.R;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.Player.Inventory.BackPack.RemoveLastItem();
		}
	}
}