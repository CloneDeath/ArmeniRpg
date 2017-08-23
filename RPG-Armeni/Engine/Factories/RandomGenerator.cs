using System;

namespace RPGArmeni.Engine.Factories
{
	public static class RandomGenerator
	{
		private static readonly Random RandomSource = new Random();

		public static int GenerateNumber(int limit)
		{
			return RandomSource.Next(limit);
		}

		public static int GenerateNumber(int start, int end)
		{
			return RandomSource.Next(start, end);
		}
	}
}