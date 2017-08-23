using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Characters
{
	[Race]
	public class Orc : Race //A playable race character.
	{
		private const int OrcBaseDamage = 20;
		private const int OrcBaseHealth = 260;

		public Orc(int health, int damage)
			: base(OrcBaseHealth, OrcBaseDamage)
		{
		}

		public Orc()
		{
			Health = OrcBaseHealth;
			Damage = OrcBaseDamage;
		}
	}
}