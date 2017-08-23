using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public class SpawnEnemiesCommand : GameCommand
	{
		public SpawnEnemiesCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute()
		{
			for (var i = 0; i < Engine.NumberOfEnemies; i++)
			{
				var enemy = CharacterFactory.Instance.CreateCharacter();
				Engine.AddEnemy(enemy);
			}
		}
	}
}