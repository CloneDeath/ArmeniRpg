using System;
using System.Linq;
using System.Reflection;
using RPGArmeni.Attributes;
using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Factories
{
	public class CharacterFactory
	{
		private static CharacterFactory _instance;

		private CharacterFactory()
		{
		}

		public static CharacterFactory Instance => _instance ?? (_instance = new CharacterFactory());

		public IGameEngine Engine { get; set; }

		public ICharacter CreateCharacter()
		{
			var currentX = RandomGenerator.GenerateNumber(0, Engine.Map.Height);
			var currentY = RandomGenerator.GenerateNumber(0, Engine.Map.Width);

			var isEmptySpot = Engine.Map.Matrix[currentX, currentY] == '.';

			while (!isEmptySpot)
			{
				currentX = RandomGenerator.GenerateNumber(0, Engine.Map.Height);
				currentY = RandomGenerator.GenerateNumber(0, Engine.Map.Width);

				isEmptySpot = Engine.Map.Matrix[currentX, currentY] == '.';
			}

			var enemyTypes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(type => type.CustomAttributes
					.Any(a => a.AttributeType == typeof(EnemyAttribute)))
				.ToArray();

			var currentType = enemyTypes[RandomGenerator.GenerateNumber(0, enemyTypes.Length)];

			var currentCharacter = Activator.CreateInstance(currentType, new Position(currentX, currentY)) as ICharacter;
			Engine.Map.Matrix[currentX, currentY] = currentCharacter.ObjectSymbol;

			return currentCharacter;
		}
	}
}