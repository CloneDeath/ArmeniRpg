using System;
using System.Text;
using RPGArmeni.Engine;
using RPGArmeni.Engine.Commands;
using RPGArmeni.Engine.Factories;

namespace RPGArmeni
{
	public class Program
	{
		public static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;

			var engine = new GameEngine();
			engine.RegisterCommand(new HelpCommand());
			engine.RegisterCommand(new PrintMapCommand());
			engine.RegisterCommand(new MovePlayerCommand());
			engine.RegisterCommand(new PlayerStatusCommand());
			engine.RegisterCommand(new HealCommand());
			engine.RegisterCommand(new BoostHealthCommand());
			engine.RegisterCommand(new BackPackCommand());
			engine.RegisterCommand(new ExitGameCommand());
			engine.RegisterCommand(new RemoveLastItemCommand());
			
			ItemFactory.Instance.Engine = engine;
			CharacterFactory.Instance.Engine = engine;
			PlayerFactory.Instance.Engine = engine;

			engine.Run();
		}
	}
}