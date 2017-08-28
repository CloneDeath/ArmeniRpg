using System;
using ArmeniRpg.Models.Characters;

namespace ArmeniRpg.Models.Enemies
{
	public class Goblin : Character
	{
		private const int GoblinHealth = 30;

		public Goblin() : base(GoblinHealth) { }

		public override int Damage => 5;
		public override char Symbol => 'G';
		public override ConsoleColor Color => ConsoleColor.Red;
		public override int MaxHealth => GoblinHealth;
	}
}