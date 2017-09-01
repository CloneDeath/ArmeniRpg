using System;
using System.Collections.Generic;
using ArmeniRpg.Interfaces;
using ArmeniRpg.Models.Characters;
using ArmeniRpg.Models.Races;
using ArmeniRpg.UI;

namespace ArmeniRpg.Engine.Factories
{
	public class PlayerFactory
	{
		protected virtual IReadOnlyList<IRace> AvailableRaces => new List<IRace>
		{
			new Human(), new Elf(), new Orc()
		};

		public IPlayer CreatePlayer(IConsoleWindow console)
		{
			var name = GetPlayerName(console);
			var playerRace = GetPlayerRace(console);
			
			Console.Clear();
			console.Clear();
			return new Player(name, playerRace);
		}

		protected virtual string GetPlayerName(IConsoleWindow console)
		{
			console.Write(Position.Zero, ConsoleColor.Green, "Enter Player's Name: ");
			console.Render();
			Console.ForegroundColor = ConsoleColor.White;
			return ConsoleInputReader.ReadLine();
		}

		private IRace GetPlayerRace(IConsoleWindow console)
		{
			Console.Clear();
			console.Clear();
			console.Write(Position.Zero, ConsoleColor.Green, "Choose A Race: ");
			for (var i = 0; i < AvailableRaces.Count; i++)
			{
				var currentRace = AvailableRaces[i];
				console.Write(new Position(0, i + 1), $"{i + 1}: " +
				                                      $"{currentRace.Name} - " +
				                                      $"(Health: {currentRace.Health}, Damage: {currentRace.Damage})");
			}

			while (true)
			{
				console.Render();
				var raceNumber = ConsoleInputReader.ReadKey();

				if (int.TryParse(raceNumber.KeyChar.ToString(), out int index) && index >= 1 && index <= AvailableRaces.Count)
				{
					return AvailableRaces[index - 1];
				}
				
				console.Write(new Position(0, AvailableRaces.Count + 1), "Please enter a valid race number.");
			}
		}
	}
}