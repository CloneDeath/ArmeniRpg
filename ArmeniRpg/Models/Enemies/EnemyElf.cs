using System;
using ArmeniRpg.Models.Characters;

namespace ArmeniRpg.Models.Enemies
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
		public override int MaxHealth => EnemyElfHealth;
	}
}