using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Characters
{
	[Enemy]
	public class EnemyOrc : Character
	{
		private const int EnemyOrcDamage = 25;
		private const int EnemyOrcHealth = 130;
		private const char EnemyOrcSymbol = 'O';

		public EnemyOrc(Position position)
			: base(position, EnemyOrcSymbol, EnemyOrcDamage, EnemyOrcHealth)
		{
		}
	}
}