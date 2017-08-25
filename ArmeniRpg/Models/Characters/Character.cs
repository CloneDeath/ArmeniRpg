using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Characters
{
	public abstract class Character : ICharacter
	{
		protected Character(int damage, int health)
		{
			Damage = damage;
			Health = health;
		}

		public int Health { get; set; }
		public int Damage { get; set; }
		public Position Position { get; set; }
		
		public abstract char Symbol { get; }
		public abstract ConsoleColor Color { get; }

		public void Attack(ICharacter enemy)
		{
			enemy.Health -= Damage;
			if (enemy is IPlayer playerEnemy) enemy.Health += playerEnemy.DefensiveBonus;
		}
	}
}