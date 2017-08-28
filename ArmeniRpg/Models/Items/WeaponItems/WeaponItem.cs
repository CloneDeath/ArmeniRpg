using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Items.WeaponItems
{
	public abstract class WeaponItem : Item, IWeapon
	{
		protected WeaponItem(int attackBonus)
		{
			AttackBonus = attackBonus;
		}

		public int AttackBonus { get; protected set; }

		public override string ToString()
		{
			return string.Format("{0} attack bonus: {1}", GetType().Name, AttackBonus);
		}
	}
}