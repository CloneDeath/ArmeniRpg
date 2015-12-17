﻿namespace RPGArmeni.Engine.Factories
{
    using RPGArmeni.Interfaces;
    using RPGArmeni.Models.Items;
    using System;
    using System.Linq;

    public class ItemFactory
    {
        private static ItemFactory instance;

        private ItemFactory()
        {
        }

        public static ItemFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemFactory();
                }

                return instance;
            }
        }

        public IGameEngine Engine { get; set; }

        public IGameItem CreateItem()
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

            int potionType = RandomGenerator.GenerateNumber(0, 3);

            HealthPotionSize potionSize;

            switch (potionType)
            {
                case 0:
                    potionSize = HealthPotionSize.Minor;
                    break;
                case 1:
                    potionSize = HealthPotionSize.Normal;
                    break;
                case 2:
                    potionSize = HealthPotionSize.Major;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid potion type.");
            }

            IGameItem currentItem = new HealthPotion(new Position(currentX, currentY), potionSize);
            this.Engine.Map.Matrix[currentX, currentY] = currentItem.ObjectSymbol;
            return currentItem;
        }
    }
}
