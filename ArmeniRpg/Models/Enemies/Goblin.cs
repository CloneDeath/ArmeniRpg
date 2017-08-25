using System;

namespace RPGArmeni.Models.Characters
{
	public class Goblin : Character
	{
		private const int GoblinDamage = 5;
		private const int GoblinHealth = 30;

		public Goblin() : base(GoblinDamage, GoblinHealth)
		{
		}

		public override char Symbol => 'G';
		public override ConsoleColor Color => ConsoleColor.Red;
	}
}