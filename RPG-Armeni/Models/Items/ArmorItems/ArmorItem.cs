using RPGArmeni.Interfaces;

namespace RPGArmeni.Models.Items.ArmorItems
{
	public abstract class ArmorItem : Item, IArmor
	{
		protected ArmorItem(Position position, char itemSymbol, int defenceBonus)
			: base(position, itemSymbol)
		{
			DefenceBonus = defenceBonus;
		}

		public int DefenceBonus { get; protected set; }

		public ArmorType ArmorType { get; protected set; }

		public override string ToString()
		{
			return string.Format("{0} defence bonus: {1}", GetType().Name, DefenceBonus);
		}
	}
}