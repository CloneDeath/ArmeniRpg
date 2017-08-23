using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Items
{
	[Item]
	internal class HealthBonusPotion : Item
	{
		private const char HealthBonusPotionSymbol = 'B';

		public HealthBonusPotion(Position position, HealthBonusPotionSize healthBonusPotionSize)
			: base(position, HealthBonusPotionSymbol)
		{
			HealthBonusPotionSize = healthBonusPotionSize;
		}

		public int HealthBonus => (int) HealthBonusPotionSize;

		public HealthBonusPotionSize HealthBonusPotionSize { get; set; }
	}
}