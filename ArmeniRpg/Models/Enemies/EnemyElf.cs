using System;

namespace RPGArmeni.Models.Characters
{
	public class EnemyElf : Character
	{
		private const int EnemyElfDamage = 17;
		private const int EnemyElfHealth = 90;

		public EnemyElf() : base(EnemyElfDamage, EnemyElfHealth)
		{
		}

		public override char Symbol => 'E';
		public override ConsoleColor Color => ConsoleColor.Red;
	}
}