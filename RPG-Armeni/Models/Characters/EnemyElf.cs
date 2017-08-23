using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Characters
{
	[Enemy]
	public class EnemyElf : Character
	{
		private const int EnemyElfDamage = 17;
		private const int EnemyElfHealth = 90;
		private const char EnemyElfSymbol = 'E';

		public EnemyElf(Position position)
			: base(position, EnemyElfSymbol, EnemyElfDamage, EnemyElfHealth)
		{
		}
	}
}