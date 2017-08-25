using System;

namespace RPGArmeni.Models.Characters
{
	public class EnemyHuman : Character
	{
		private const int EnemyHumanDamage = 15;
		private const int EnemyHumanHealth = 80;
		
		public EnemyHuman() : base(EnemyHumanDamage, EnemyHumanHealth)
		{
		}

		public override char Symbol => 'M';
		public override ConsoleColor Color => ConsoleColor.Red;
	}
}