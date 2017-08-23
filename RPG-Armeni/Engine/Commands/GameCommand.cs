using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine.Commands
{
	public abstract class GameCommand : IGameCommand
	{
		protected GameCommand(IGameEngine engine)
		{
			Engine = engine;
		}

		public IGameEngine Engine { get; set; }

		public virtual void Execute(IKeyInfo directionKey)
		{
		}

		public abstract void Execute();
	}
}