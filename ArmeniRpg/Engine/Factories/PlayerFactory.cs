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

		public IPlayer CreatePlayer()
		{
			var name = GetPlayerName();
			var playerRace = GetPlayerRace();
			return new Player(name, playerRace);
		}

		protected virtual string GetPlayerName()
		{
			Console.SetCursorPosition(0, 0);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Enter Player's Name: ");
			Console.ForegroundColor = ConsoleColor.White;
			return ConsoleInputReader.ReadLine();
		}

		private IRace GetPlayerRace()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Choose A Race: ");
			Console.ForegroundColor = ConsoleColor.White;

			for (var i = 0; i < AvailableRaces.Count; i++)
			{
				var currentRace = AvailableRaces[i];
				Console.WriteLine($"{i + 1}: " +
								  $"{currentRace.Name} - " +
								  $"(Health: {currentRace.Health}, Damage: {currentRace.Damage})");
			}

			while (true)
			{
				var raceNumber = ConsoleInputReader.ReadLine();

				int index;
				if (int.TryParse(raceNumber, out index) && index >= 1 && index <= AvailableRaces.Count)
				{
					return AvailableRaces[index - 1];
				}
				
				Console.WriteLine("Please enter a valid race number.");
			}
		}
	}
}