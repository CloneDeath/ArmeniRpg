using System;
using ArmeniRpg.Models.Characters;

namespace ArmeniRpg.Models.Enemies
{
	public class EnemyElf : Character
	{
		private const int EnemyElfHealth = 90;

		public EnemyElf() : base(EnemyElfHealth) { }

		public override int Damage => 17;
		public override string Name => "Wild Elf";
		public override char Symbol => 'E';
		public override ConsoleColor Color => ConsoleColor.Red;
		public override int MaxHealth => EnemyElfHealth;
	}
}