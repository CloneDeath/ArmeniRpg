using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Items
{
	[Item]
	public class HealthPotion : Item
	{
		private const char HealthPotionSymbol = 'H';

		public HealthPotion(Position position, HealthPotionSize healthPotionSize)
			: base(position, HealthPotionSymbol)
		{
			HealthPotionSize = healthPotionSize;
		}

		public int HealthRestore => (int) HealthPotionSize;

		public HealthPotionSize HealthPotionSize { get; set; }
	}
}