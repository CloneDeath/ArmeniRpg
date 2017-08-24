using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class SpawnEnemiesCommand
	{
		public void Execute(IGameEngine engine)
		{
			for (var i = 0; i < engine.NumberOfEnemies; i++)
			{
				var enemy = CharacterFactory.Instance.CreateCharacter();
				engine.AddEnemy(enemy);
			}
		}
	}
}