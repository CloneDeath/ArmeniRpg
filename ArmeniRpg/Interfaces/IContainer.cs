using System.Collections.Generic;

namespace ArmeniRpg.Interfaces
{
	public interface IContainer
	{
		IEnumerable<ISlot> SlotList { get; }
		void LootItem(IGameItem itemToBeLooted);
		void RemoveItem(ISlot slot);
		void RemoveLastItem();
		void ListItems();
	}
}