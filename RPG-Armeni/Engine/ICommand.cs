using RPGArmeni.Interfaces;

namespace RPGArmeni.Engine
{
	public interface ICommand
	{
		bool HandlesInput(IKeyInfo keyInfo);
		void Execute(IGameEngine gameEngine, IKeyInfo keyInfo);
	}
}