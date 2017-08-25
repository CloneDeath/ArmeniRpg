using System.Collections.Generic;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Engine
{
	public class CommandFactory
	{
		private readonly List<ICommand> _commands = new List<ICommand>();
		
		public void RegisterCommand(ICommand command)
		{
			_commands.Add(command);
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo commandKey)
		{
			foreach (var command in _commands)
			{
				if (!command.HandlesInput(commandKey)) continue;
				command.Execute(gameEngine, commandKey);
			}
		}
	}
}