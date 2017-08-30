using ArmeniRpg.Models.Containers;

namespace ArmeniRpg.Interfaces
{
	public interface ICollect
	{
		IInventory Inventory { get; }
	}
}