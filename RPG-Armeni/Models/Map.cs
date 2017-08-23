using RPGArmeni.Interfaces;

namespace RPGArmeni.Models
{
	public class Map : IMap
	{
		public Map(int height, int width)
		{
			Height = height;
			Width = width;
			Matrix = new char[Height, Width];
		}

		public int Height { get; }
		public int Width { get; }

		public char[,] Matrix { get; }
	}
}