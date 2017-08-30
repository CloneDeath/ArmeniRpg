namespace ArmeniRpg.Models.Containers
{
	public class Inventory : IInventory
	{
		public IWeaponSlot MainHandSlot { get; } = new WeaponSlot();
		public ISlot OffHandSlot { get; } = new GenericSlot();
		public ISlot ChestSlot { get; } = new GenericSlot();
		public ISlot HeadSlot { get; } = new GenericSlot();
		public ISlot FeetSlot { get; } = new GenericSlot();
		public ISlot GlovesSlot { get; } = new GenericSlot();
		public IContainer BackPack { get; } = new BackPack();
	}
}