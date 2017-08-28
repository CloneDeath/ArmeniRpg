using System;

namespace ArmeniRpg.Models.Items
{
	public class HealthPotion : Item
	{
		public HealthPotion(HealthPotionSize healthPotionSize)
		{
			HealthPotionSize = healthPotionSize;
		}

		public int HealthRestore => (int) HealthPotionSize;
		public HealthPotionSize HealthPotionSize { get; set; }

		public override char Symbol => 'H';
		public override ConsoleColor Color => ConsoleColor.Blue;
	}
}