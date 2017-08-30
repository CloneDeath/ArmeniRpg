using System;
using ArmeniRpg.Models.Characters;

namespace ArmeniRpg.Models.Enemies
{
	public class Troll : Character
	{
		private const int TrollHealth = 400;
		
		public Troll() : base(TrollHealth)
		{
		}

		public override int Damage => 45;
		public override string Name => "Troll";
		public override char Symbol => 'T';
		public override ConsoleColor Color => ConsoleColor.Red;
		public override int MaxHealth => TrollHealth;
	}
}