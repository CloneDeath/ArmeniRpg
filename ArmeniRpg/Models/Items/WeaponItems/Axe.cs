using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Items.WeaponItems
{
	public class Axe : Item, IWeapon
	{
		public override string Name => $"Axe (Damage +{AttackBonus})";
		public override char Symbol => 'A';
		public override ConsoleColor Color => ConsoleColor.DarkCyan;
		public int AttackBonus => 15;
	}
}