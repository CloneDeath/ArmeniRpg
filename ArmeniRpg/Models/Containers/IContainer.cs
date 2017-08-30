using System.Collections.Generic;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Containers
{
	public interface IContainer : IEnumerable<ISlot>
	{
		bool CanHoldItem(IGameItem item);
		void HoldItem(IGameItem item);

		bool ContainsItem(IGameItem item);
		void RemoveItem(IGameItem item);
		
		int Size { get; }
		ISlot this[int index] { get; }
		
		T GetItem<T>() where T : IGameItem;
	}
}