using System;

namespace ArmeniRpg.Models.Items
{
	internal class HealthBonusPotion : Item
	{
		public HealthBonusPotion(HealthBonusPotionSize healthBonusPotionSize)
		{
			HealthBonusPotionSize = healthBonusPotionSize;
		}

		public int HealthBonus => (int) HealthBonusPotionSize;

		public HealthBonusPotionSize HealthBonusPotionSize { get; set; }
		public override string Name => "Bonus Health Potion";
		public override char Symbol => 'B';
		public override ConsoleColor Color => ConsoleColor.Blue;
	}
}