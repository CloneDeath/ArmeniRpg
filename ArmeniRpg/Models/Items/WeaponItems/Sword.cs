using System;

namespace ArmeniRpg.Models.Items.WeaponItems
{
	public class Sword : WeaponItem
	{
		private const int SwordAttackBonus = 10;

		public Sword() : base(SwordAttackBonus)
		{
		}

		public override char Symbol => 'S';
		public override ConsoleColor Color => ConsoleColor.DarkCyan;
	}
}