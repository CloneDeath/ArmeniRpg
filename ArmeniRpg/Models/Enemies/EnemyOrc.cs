using System;
using ArmeniRpg.Models.Characters;

namespace ArmeniRpg.Models.Enemies
{
	public class EnemyOrc : Character
	{
		private const int EnemyOrcHealth = 130;

		public EnemyOrc() : base(EnemyOrcHealth) { }

		public override int Damage => 25;
		public override char Symbol => 'O';
		public override ConsoleColor Color => ConsoleColor.Red;
		public override int MaxHealth => EnemyOrcHealth;
	}
}