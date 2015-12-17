﻿namespace RPGArmeni.Engine.Factories
{
    using RPGArmeni.Attributes;
    using RPGArmeni.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class CharacterFactory
    {
        private static CharacterFactory instance;

        private CharacterFactory()
        {
        }

        public static CharacterFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CharacterFactory();
                }

                return instance;
            }
        }

        public IGameEngine Engine { get; set; }

        public ICharacter CreateCharacter()
        {
            int currentX = RandomGenerator.GenerateNumber(0, this.Engine.Map.Height);
            int currentY = RandomGenerator.GenerateNumber(0, this.Engine.Map.Width);

            bool isEmptySpot = this.Engine.Map.Matrix[currentX, currentY] == '.';

            while (!isEmptySpot)
            {
                currentX = RandomGenerator.GenerateNumber(0, this.Engine.Map.Height);
                currentY = RandomGenerator.GenerateNumber(0, this.Engine.Map.Width);

                isEmptySpot = this.Engine.Map.Matrix[currentX, currentY] == '.';
            }

            var enemyTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.CustomAttributes
                    .Any(a => a.AttributeType == typeof(EnemyAttribute)))
                    .ToArray();

            var type = enemyTypes[RandomGenerator.GenerateNumber(0, enemyTypes.Length)];

            ICharacter currentCharacter = Activator
                .CreateInstance(type, new Position(currentX, currentY)) as ICharacter;
            this.Engine.Map.Matrix[currentX, currentY] = currentCharacter.ObjectSymbol;

            return currentCharacter;
        }
    }
}
