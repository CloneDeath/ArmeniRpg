using System;
using ArmeniRpg.Models.Characters;

namespace ArmeniRpg.Models.Enemies
{
	public class EnemyHuman : Character
	{
		private const int EnemyHumanHealth = 80;
		
		public EnemyHuman() : base(EnemyHumanHealth) { }

		public override int Damage => 15;
		public override char Symbol => 'M';
		public override ConsoleColor Color => ConsoleColor.Red;
		public override int MaxHealth => EnemyHumanHealth;
	}
}