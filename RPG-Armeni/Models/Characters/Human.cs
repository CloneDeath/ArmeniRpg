using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Characters
{
	[Race]
	public class Human : Race //A playable race character.
	{
		private const int HumanBaseDamage = 35;
		private const int HumanBaseHealth = 220;

		public Human(int health, int damage)
			: base(HumanBaseHealth, HumanBaseDamage)
		{
		}

		public Human()
		{
			Health = HumanBaseHealth;
			Damage = HumanBaseDamage;
		}
	}
}