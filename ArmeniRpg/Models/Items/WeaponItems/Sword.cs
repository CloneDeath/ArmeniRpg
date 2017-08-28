using System;
using ArmeniRpg.Attributes;

namespace ArmeniRpg.Models.Items.WeaponItems
{
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