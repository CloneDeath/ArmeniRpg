using RPGArmeni.Interfaces;

namespace RPGArmeni.Models.Characters
{
	public abstract class Race : IRace //A base abstract class for playable races. The player picks one.
	{
		protected Race(int health, int damage)
		{
			Health = health;
			Damage = damage;
		}

		protected Race()
		{
		}

		public int Health { get; protected set; }

		public int Damage { get; protected set; }
	}
}