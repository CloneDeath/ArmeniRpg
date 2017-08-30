using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Containers
{
	public interface ISlot
	{
		IGameItem Item { get; }
		
		bool IsEmpty { get; }

		bool CanOccupy(IGameItem item);
		void SetItem(IGameItem item);
		void ClearItem();
	}
}