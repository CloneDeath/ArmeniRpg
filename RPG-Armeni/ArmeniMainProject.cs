using System;
using System.Text;
using RPGArmeni.Engine;
using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;

namespace RPGArmeni
{
	public class ArmeniMainProject
	{
		public static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;

			IGameEngine engine = new GameEngine();
			ItemFactory.Instance.Engine = engine;
			CharacterFactory.Instance.Engine = engine;
			PlayerFactory.Instance.Engine = engine;

			engine.Run();
		}
	}
}