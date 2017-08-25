using System;
using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Items.WeaponItems
{
	[Weapon]
	[Item]
	public class Axe : WeaponItem
	{
		private const int AxeAttackBonus = 15;

		public Axe(Position position) : base(position, AxeAttackBonus)
		{
		}

		public override char Symbol => 'A';
		public override ConsoleColor Color => ConsoleColor.DarkCyan;
	}
}