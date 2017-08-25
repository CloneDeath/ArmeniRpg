using System;
using ArmeniRpg.Attributes;

namespace ArmeniRpg.Models.Items
{
	[Item]
	public class HealthPotion : Item
	{
		public HealthPotion(Position position, HealthPotionSize healthPotionSize)
		{
			Position = position;
			HealthPotionSize = healthPotionSize;
		}

		public int HealthRestore => (int) HealthPotionSize;
		public HealthPotionSize HealthPotionSize { get; set; }

		public override char Symbol => 'H';
		public override ConsoleColor Color => ConsoleColor.Blue;
	}
}