using System;

namespace ArmeniRpg.Engine.Factories
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

		public static Position GeneratePosition(int width, int height)
		{
			var y = GenerateNumber(0, height);
			var x = GenerateNumber(0, width);
			return new Position(x, y);
		}
	}
}