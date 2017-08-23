using System;
using RPGArmeni.Exceptions;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Models.Characters
{
	public abstract class Character : GameObject, ICharacter
	{
		private int _damage;

		protected Character(IPosition position, char objectSymbol, int damage, int health)
			: base(position, objectSymbol)
		{
			Damage = damage;
			Health = ValidateHealth(health);
		}

		public int Health { get; set; }

		public int Damage
		{
			get => _damage;
			protected set
			{
				if (value < 0) throw new Exception("Character damage value cannot be negative.");
				_damage = value;
			}
		}

		public void Attack(ICharacter enemy)
		{
			enemy.Health -= Damage;
			if (enemy is IPlayer playerEnemy) enemy.Health += playerEnemy.DefensiveBonus;
		}

		private static int ValidateHealth(int health)
		{
			if (health < 1) throw new InvalidHealthException("Starting health cannot be lower than 1.");
			return health;
		}
	}
}