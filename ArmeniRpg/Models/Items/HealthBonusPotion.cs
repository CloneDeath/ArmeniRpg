using System;
using ArmeniRpg.Attributes;

namespace ArmeniRpg.Models.Items
{
	[Item]
	internal class HealthBonusPotion : Item
	{
		public HealthBonusPotion(Position position, HealthBonusPotionSize healthBonusPotionSize)
		{
			Position = position;
			HealthBonusPotionSize = healthBonusPotionSize;
		}

		public int HealthBonus => (int) HealthBonusPotionSize;

		public HealthBonusPotionSize HealthBonusPotionSize { get; set; }
		public override char Symbol => 'B';
		public override ConsoleColor Color => ConsoleColor.Blue;
	}
}