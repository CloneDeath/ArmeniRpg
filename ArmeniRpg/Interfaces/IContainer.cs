using System.Collections.Generic;

namespace ArmeniRpg.Interfaces
{
	public interface IContainer : IEnumerable<ISlot>
	{
		void LootItem(IGameItem itemToBeLooted);
		void RemoveItem(ISlot slot);
		void RemoveLastItem();
		ISlot this[int index] { get; }
	}
}