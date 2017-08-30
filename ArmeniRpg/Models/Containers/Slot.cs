using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Containers
{
	public abstract class Slot<T> : ISlot 
		where T : IGameItem
	{
		IGameItem ISlot.Item => Item;
		public T Item { get; protected set; }
		
		public bool IsEmpty => Item == null;
		public bool CanOccupy(IGameItem item) => item is T;
		public void SetItem(IGameItem item) => Item = (T)item;
		public void ClearItem() => Item = default(T);
	}
}