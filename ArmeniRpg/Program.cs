using System;
using System.Text;
using RPGArmeni.Engine;
using RPGArmeni.Engine.Commands;
using RPGArmeni.Interfaces;
using RPGArmeni.UI;

namespace RPGArmeni
{
	public class Program
	{
		public static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.Title = "Armeni Rpg";
			ConsoleRenderer.ResetColor();
			ConsoleRenderer.Clear();

			var engine = GetGameEngine();

			engine.Run();
		}

		public static IGameEngine GetGameEngine()
		{
			var engine = new GameEngine();
			engine.RegisterCommand(new HelpCommand());
			engine.RegisterCommand(new MovePlayerCommand());
			engine.RegisterCommand(new PlayerStatusCommand());
			engine.RegisterCommand(new HealCommand());
			engine.RegisterCommand(new BoostHealthCommand());
			engine.RegisterCommand(new BackPackCommand());
			engine.RegisterCommand(new ExitGameCommand());
			engine.RegisterCommand(new RemoveLastItemCommand());
			return engine;
		}
	}
}