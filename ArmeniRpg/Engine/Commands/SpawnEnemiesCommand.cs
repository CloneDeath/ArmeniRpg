using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;
using RPGArmeni.Models.Characters;

namespace RPGArmeni.Engine.Commands
{
	public class SpawnEnemiesCommand
	{
		public void Execute(IGameEngine engine)
		{
			for (var i = 0; i < engine.NumberOfEnemies; i++)
			{
				var enemy = CreateCharacter(engine);
				engine.AddEnemy(enemy);
			}
		}

		private static ICharacter[] Enemies => new ICharacter[]
		{
			new EnemyElf(), new EnemyHuman(), new EnemyOrc(), new Goblin(), new Troll()
		};
		
		public ICharacter CreateCharacter(IGameEngine engine)
		{
			var current = RandomGenerator.GeneratePosition(engine.Map.Width, engine.Map.Height);

			var isEmptySpot = engine.IsEmpty(current);

			while (!isEmptySpot)
			{
				current = RandomGenerator.GeneratePosition(engine.Map.Width, engine.Map.Height);
				isEmptySpot = engine.IsEmpty(current);
			}

			var enemy = Enemies[RandomGenerator.GenerateNumber(0, Enemies.Length)];
			enemy.Position = current;
			return enemy;
		}
	}
}