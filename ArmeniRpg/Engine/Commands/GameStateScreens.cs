using System;
using System.IO;

namespace ArmeniRpg.Engine.Commands
{
	public static class GameStateScreens
	{
		public static void ShowGameOverScreen()
		{
			Console.ResetColor();
			Console.Clear();

			const int skullHeight = 19;
			var centerPadding = new string(' ', Console.BufferWidth / 4);

			var deathScreen = File.ReadAllLines("./UI/Utility/GameOver.txt");
			Console.CursorVisible = false;

			Console.ForegroundColor = ConsoleColor.Gray;
			for (var i = 0; i < skullHeight; i++)
			{
				Console.Write(centerPadding);
				Console.WriteLine(deathScreen[i]);
			}
			Console.ForegroundColor = ConsoleColor.Red;
			for (var i = skullHeight; i < deathScreen.Length; i++)
			{
				Console.Write(centerPadding);
				Console.WriteLine(deathScreen[i]);
			}

			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}