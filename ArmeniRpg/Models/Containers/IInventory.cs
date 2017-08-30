namespace ArmeniRpg.Models.Containers
{
	public interface IInventory
	{
		IWeaponSlot MainHandSlot { get; }
		ISlot OffHandSlot { get; }
		ISlot ChestSlot { get; }
		ISlot HeadSlot { get; }
		ISlot FeetSlot { get; }
		ISlot GlovesSlot { get; }
		IContainer BackPack { get; }
	}
}