using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ArmeniRpg.Exceptions;
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
				_slotList.Add(new Slot());
		}

		public void LootItem(IGameItem itemToBeLooted)
		{
			var emptySlot = _slotList.FirstOrDefault(x => x.IsEmpty);

			if (emptySlot == null)
				throw new BackPackFullException("Your backpack is full.");

			emptySlot.GameItem = itemToBeLooted;
			emptySlot.IsEmpty = false;
		}

		public void RemoveItem(ISlot slot)
		{
			slot.GameItem = null;
			slot.IsEmpty = true;
		}

		public void RemoveLastItem()
		{
			RemoveLastItemInternal();
		}

		public ISlot this[int index] => _slotList[index];

		private void RemoveLastItemInternal()
		{
			/* Method which removes the last collected item from the backpack
			(sets new object at that index) if the player wants to collect another one */
			var indexOfElemenToRemove = _slotList.IndexOf(
				                            _slotList.FirstOrDefault(slot => slot.IsEmpty)) - 1;

			if (indexOfElemenToRemove == -1)
				throw new ArgumentException("Invalid operation. Your backpack is empty.");

			if (indexOfElemenToRemove == -2)
				indexOfElemenToRemove = _slotList.Count - 1; /*last element, because indexOf returns -1, 
                when it doesn't find element (empty slot) - 1 = -2 */

			_slotList.RemoveAt(indexOfElemenToRemove);
			_slotList.Insert(indexOfElemenToRemove, new Slot());
		}

		public IEnumerator<ISlot> GetEnumerator() => _slotList.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}