using System;
using ArmeniRpg.Engine;
using ArmeniRpg.Engine.Commands;
using ArmeniRpg.Engine.Factories;
using ArmeniRpg.Interfaces;
using ArmeniRpg.UI;

namespace ArmeniRpg
{
	public class Program
	{
		public static void Main()
		{
			var console = new ConsoleWindow
			{
				Title = "Armeni Rpg",
				DefaultForegroundColor = ConsoleColor.White,
				DefaultBackgroundColor = ConsoleColor.Black
			};
			console.Clear();
			console.Render();

			var engine = GetGameEngine();
			engine.Player = new PlayerFactory().CreatePlayer(console);
			engine.Run(console);
		}

		public static IGameEngine GetGameEngine()
		{
			var engine = new GameEngine();
			engine.RegisterCommand(new HelpCommand());
			engine.RegisterCommand(new MovePlayerCommand());
			engine.RegisterCommand(new HealCommand());
			engine.RegisterCommand(new BoostHealthCommand());
			engine.RegisterCommand(new ExitGameCommand());
			return engine;
		}
	}
}