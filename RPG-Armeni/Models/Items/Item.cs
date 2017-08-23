using RPGArmeni.Interfaces;

namespace RPGArmeni.Models.Items
{
	public abstract class Item : GameObject, IGameItem
	{
		protected Item(Position position, char itemSymbol)
			: base(position, itemSymbol)
		{
			ItemState = ItemState.Available;
		}

		public ItemState ItemState { get; set; }

		public override string ToString()
		{
			return string.Format("{0}", GetType().Name);
		}
	}
}