using System.Collections.Generic;
using System.Linq;
using ArmeniRpg.Exceptions;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Containers
{
	public class Inventory : IInventory
	{
		private readonly Dictionary<int, ISlot> armorSlots;
		private readonly List<ISlot> slotList;
		private readonly Dictionary<int, ISlot> weaponSlots;

		public Inventory()
		{
			MainHandSlot = new Slot();
			OffHandSlot = new Slot();
			ChestSlot = new Slot();
			HeadSlot = new Slot();
			FeetSlot = new Slot();
			GlovesSlot = new Slot();
			slotList = new List<ISlot> {MainHandSlot};
			weaponSlots = new Dictionary<int, ISlot>();
			armorSlots = new Dictionary<int, ISlot>();
			BackPack = new BackPack();

			weaponSlots.Add(1, MainHandSlot);
			weaponSlots.Add(2, OffHandSlot);

			armorSlots.Add(1, ChestSlot);
			armorSlots.Add(2, HeadSlot);
			armorSlots.Add(3, FeetSlot);
			armorSlots.Add(4, GlovesSlot);
		}

		public ISlot MainHandSlot { get; }

		public ISlot OffHandSlot { get; }

		public ISlot ChestSlot { get; }

		public ISlot HeadSlot { get; }

		public ISlot FeetSlot { get; }

		public ISlot GlovesSlot { get; }

		public IContainer BackPack { get; }

		public IEnumerable<ISlot> SlotList => slotList;

		public IDictionary<int, ISlot> WeaponSlots => weaponSlots;

		public IDictionary<int, ISlot> ArmorSlots => armorSlots;

		public void ClearInventory()
		{
			foreach (var currentSlot in SlotList)
				currentSlot.ClearSlot();
		}

		public void EquipItem(IGameItem itemToBeEquipped)
		{
			if (itemToBeEquipped is IWeapon)
			{
				var currentSlot = SlotList.FirstOrDefault(x => x.IsEmpty && x.GameItem is IWeapon);

				if (currentSlot == null)
					throw new NoSlotAvailableException("There is no available slot.");
				currentSlot.GameItem = itemToBeEquipped;
			}
		}

		public void RemoveItem(IGameItem itemToBeRemoved)
		{
			var currentSlot = SlotList.FirstOrDefault(x => x.GameItem == itemToBeRemoved);
			currentSlot.GameItem = null;
			currentSlot.IsEmpty = true;
		}
	}
}