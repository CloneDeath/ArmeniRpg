using System;
using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Items.WeaponItems
{
	[Weapon]
	[Item]
	public class Sword : WeaponItem
	{
		private const int SwardAttackBonus = 10;

		public Sword(Position position) : base(position, SwardAttackBonus)
		{
		}

		public override char Symbol => 'S';
		public override ConsoleColor Color => ConsoleColor.DarkCyan;
	}
}