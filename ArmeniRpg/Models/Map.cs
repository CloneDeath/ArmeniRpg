using RPGArmeni.Interfaces;

namespace RPGArmeni.Models
{
	public class Map : IMap
	{
		public Map(int width, int height)
		{
			Width = width;
			Height = height;
			_matrix = new ITile[Width, Height];
		}

		public int Width { get; }
		public int Height { get; }

		private readonly ITile[,] _matrix;

		public ITile this[Position position]
		{
			get => _matrix[position.X, position.Y];
			set => _matrix[position.X, position.Y] = value;
		}
	}
}