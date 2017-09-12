using System;
using ArmeniRpg.Interfaces;
using ArmeniRpg.UI;

namespace ArmeniRpg.Engine.Commands
{
	public class DropItemCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.D;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.PushStatus("Drop Which Item?");
			var key = KeyInfo.GetInput();

			var slotId = (int) key.Key - (int) ConsoleKey.A;
			if (slotId < 0 || slotId >= gameEngine.Player.Inventory.BackPack.Size)
			{
				gameEngine.PushStatus("Invalid Item.");
				return;
			}

			var slot = gameEngine.Player.Inventory.BackPack[slotId];
			if (slot.IsEmpty)
			{
				gameEngine.PushStatus("Nothing to drop.");
				return;
			}

			var item = slot.Item;
			slot.ClearItem();
			item.Position = gameEngine.Player.Position;
			gameEngine.AddItem(item);
		}
	}
}