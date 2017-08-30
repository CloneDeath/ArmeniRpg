using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Containers
{
	public class BackPack : IContainer
	{
		private const int BackPackSlotNumber = 10;
		private readonly List<ISlot> _slotList;

		public BackPack()
		{
			_slotList = new List<ISlot>();
			for (var i = 0; i < BackPackSlotNumber; i++)
				_slotList.Add(new GenericSlot());
		}

		public bool CanHoldItem(IGameItem item)
		{
			return _slotList.Any(s => s.IsEmpty && s.CanOccupy(item));
		}

		public void HoldItem(IGameItem item)
		{
			var emptySlot = _slotList.FirstOrDefault(s => s.IsEmpty && s.CanOccupy(item));
			emptySlot.SetItem(item);
		}

		public bool ContainsItem(IGameItem item)
		{
			return _slotList.Any(s => s.Item == item);
		}

		public void RemoveItem(IGameItem item)
		{
			var slot = _slotList.FirstOrDefault(s => s.Item == item);
			slot?.ClearItem();
		}

		public int Size => _slotList.Count;

		public ISlot this[int index] => _slotList[index];
		
		public T GetItem<T>() where T : IGameItem
		{
			return _slotList.Where(s => !s.IsEmpty).Select(s => s.Item).OfType<T>().FirstOrDefault();
		}

		public IEnumerator<ISlot> GetEnumerator() => _slotList.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}