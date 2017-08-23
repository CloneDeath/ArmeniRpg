using RPGArmeni.Interfaces;

namespace RPGArmeni.Models.Containers
{
	public class Slot : ISlot
	{
		public Slot()
		{
			IsEmpty = true;
			GameItem = null;
		}

		public IGameItem GameItem { get; set; }

		public bool IsEmpty { get; set; }

		public void ClearSlot()
		{
			GameItem = null;
			IsEmpty = true;
		}
	}
}