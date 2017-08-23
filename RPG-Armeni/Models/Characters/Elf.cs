using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Characters
{
	[Race]
	public class Elf : Race //A playable race character.
	{
		private const int ElfBaseDamage = 30;
		private const int ElfBaseHealth = 250;

		public Elf(int health, int damage)
			: base(ElfBaseHealth, ElfBaseDamage)
		{
		}

		public Elf()
		{
			Health = ElfBaseHealth;
			Damage = ElfBaseDamage;
		}
	}
}