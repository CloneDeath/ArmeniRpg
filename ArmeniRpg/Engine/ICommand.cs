using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Engine
{
	public interface ICommand
	{
		bool HandlesInput(IKeyInfo keyInfo);
		void Execute(IGameEngine gameEngine, IKeyInfo keyInfo);
	}
}