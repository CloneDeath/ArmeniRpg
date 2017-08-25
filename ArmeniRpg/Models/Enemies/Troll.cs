using System;

namespace RPGArmeni.Models.Characters
{
	public class Troll : Character
	{
		private const int TrollDamage = 45;
		private const int TrollHealth = 400;
		
		public Troll() : base(TrollDamage, TrollHealth)
		{
		}

		public override char Symbol => 'T';
		public override ConsoleColor Color => ConsoleColor.Red;
	}
}