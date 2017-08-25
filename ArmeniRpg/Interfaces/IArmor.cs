using ArmeniRpg.Models.Items.ArmorItems;

namespace ArmeniRpg.Interfaces
{
	public interface IArmor
	{
		int DefenceBonus { get; }
		ArmorType ArmorType { get; }
	}
}