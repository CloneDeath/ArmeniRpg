using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Containers
{
	public class WeaponSlot : Slot<IWeapon>, IWeaponSlot
	{
		public int AttackBonus => Item?.AttackBonus ?? 0;
	}
}