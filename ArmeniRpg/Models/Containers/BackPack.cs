using System;
using System.Collections.Generic;
using System.Linq;
using ArmeniRpg.Exceptions;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Containers
{
	public class BackPack : IContainer
	{
		private const int BackPackSlotNumber = 10;
		private readonly List<ISlot> slotList;

		public BackPack()
		{
			slotList = new List<ISlot>();
			for (var i = 0; i < BackPackSlotNumber; i++)
				slotList.Add(new Slot());
		}

		public IEnumerable<ISlot> SlotList => slotList;

		public void LootItem(IGameItem itemToBeLooted)
		{
			var emptySlot = SlotList.FirstOrDefault(x => x.IsEmpty);

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

		public void ListItems(IGameEngine engine)
		{
			var fullSlots = SlotList.Where(x => !x.IsEmpty).ToList();
			foreach (var currentSlot in fullSlots)
				engine.SetStatus(currentSlot.GameItem.ToString());

			engine.SetStatus($"Empty slots: {SlotList.Count() - fullSlots.Count}");
		}

		private void RemoveLastItemInternal()
		{
			/* Method which removes the last collected item from the backpack
			(sets new object at that index) if the player wants to collect another one */
			var indexOfElemenToRemove = slotList.IndexOf(
				                            slotList.FirstOrDefault(slot => slot.IsEmpty)) - 1;

			if (indexOfElemenToRemove == -1)
				throw new ArgumentException("Invalid operation. Your backpack is empty.");

			if (indexOfElemenToRemove == -2)
				indexOfElemenToRemove = slotList.Count - 1; /*last element, because indexOf returns -1, 
                when it doesn't find element (empty slot) - 1 = -2 */

			slotList.RemoveAt(indexOfElemenToRemove);
			slotList.Insert(indexOfElemenToRemove, new Slot());
		}
	}
}