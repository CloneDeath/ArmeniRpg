using RPGArmeni.Models.Items.ArmorItems;

namespace RPGArmeni.Interfaces
{
	public interface IArmor
	{
		int DefenceBonus { get; }
		ArmorType ArmorType { get; }
	}
}