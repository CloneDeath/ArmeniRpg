using RPGArmeni.Engine;
using RPGArmeni.Exceptions;
using RPGArmeni.Interfaces;

namespace RPGArmeni
{
	public abstract class GameObject : IGameObject
	{
		private IPosition _position;

		protected GameObject(IPosition position, char objectSymbol)
		{
			Position = position;
			ObjectSymbol = objectSymbol;
		}

		public IPosition Position
		{
			get => _position;
			set
			{
				if (IsOutsideGameField(value))
					throw new ObjectOutOfBoundsException("Specified coordinates are outside the game map.");
				_position = value;
			}
		}

		public char ObjectSymbol { get; set; }

		private static bool IsOutsideGameField(IPosition value)
		{
			return value.X < 0
			       || value.Y < 0
			       || value.X >= GameEngine.MapHeight
			       || value.Y >= GameEngine.MapWidth;
		}
	}
}