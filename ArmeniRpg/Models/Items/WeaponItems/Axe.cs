using System;

namespace ArmeniRpg.Models.Items.WeaponItems
{
	public class Axe : WeaponItem
	{
		private const int AxeAttackBonus = 15;

		public Axe() : base(AxeAttackBonus)
		{
		}

		public override char Symbol => 'A';
		public override ConsoleColor Color => ConsoleColor.DarkCyan;
	}
}