using RPGArmeni.Interfaces;

namespace RPGArmeni
{
	public abstract class GameObject : IGameObject
	{
		protected GameObject(IPosition position, char objectSymbol)
		{
			Position = position;
			ObjectSymbol = objectSymbol;
		}

		public IPosition Position { get; set; }
		public char ObjectSymbol { get; set; }
	}
}