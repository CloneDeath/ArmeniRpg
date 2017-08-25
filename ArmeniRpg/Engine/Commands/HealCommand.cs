using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Engine.Commands
{
	public class HealCommand : ICommand
	{
		public bool HandlesInput(IKeyInfo keyInfo)
		{
			return keyInfo.Key == ConsoleKey.H;
		}

		public void Execute(IGameEngine gameEngine, IKeyInfo keyInfo)
		{
			gameEngine.Player.SelfHeal();
		}
	}
}