using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Items.WeaponItems
{
	public class Sword : Item, IWeapon
	{
		public override string Name => $"Sword (Damage +{AttackBonus})";
		public override char Symbol => 'S';
		public override ConsoleColor Color => ConsoleColor.DarkCyan;
		public int AttackBonus => 10;
	}
}