using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Characters
{
	public abstract class Character : ICharacter
	{
		protected Character(int health)
		{
			Health = health;
		}

		public abstract string Name { get; }
		public abstract int MaxHealth { get; }
		public int Health { get; set; }
		public Position Position { get; set; }
		
		public abstract int Damage { get; }
		
		public abstract char Symbol { get; }
		public abstract ConsoleColor Color { get; }

		public void Attack(ICharacter enemy)
		{
			enemy.Health -= Damage;
			if (enemy is IPlayer playerEnemy) enemy.Health += playerEnemy.DefensiveBonus;
		}
	}
}