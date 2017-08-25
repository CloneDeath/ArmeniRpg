using System;

namespace RPGArmeni.Models.Characters
{
	public class EnemyOrc : Character
	{
		private const int EnemyOrcDamage = 25;
		private const int EnemyOrcHealth = 130;

		public EnemyOrc() : base(EnemyOrcDamage, EnemyOrcHealth)
		{
		}

		public override char Symbol => 'O';
		public override ConsoleColor Color => ConsoleColor.Red;
	}
}