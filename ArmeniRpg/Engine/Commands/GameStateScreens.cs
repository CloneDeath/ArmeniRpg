using System;
using System.IO;
using ArmeniRpg.UI;

namespace ArmeniRpg.Engine.Commands
{
	public static class GameStateScreens
	{
		public static void ShowGameOverScreen()
		{
			ConsoleRenderer.Clear();

			const int skullHeight = 19;
			var centerPadding = new string(' ', Console.BufferWidth / 4);

			var deathScreen = File.ReadAllLines("./UI/Utility/GameOver.txt");
			Console.CursorVisible = false;

			Console.ForegroundColor = ConsoleColor.Gray;
			for (var i = 0; i < skullHeight; i++)
			{
				ConsoleRenderer.Write(centerPadding);
				ConsoleRenderer.WriteLine(deathScreen[i]);
			}
			Console.ForegroundColor = ConsoleColor.Red;
			for (var i = skullHeight; i < deathScreen.Length; i++)
			{
				ConsoleRenderer.Write(centerPadding);
				ConsoleRenderer.WriteLine(deathScreen[i]);
			}

			Console.ForegroundColor = ConsoleColor.White;

			Environment.Exit(0);
		}
	}
}