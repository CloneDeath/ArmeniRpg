using System;
using System.Collections.Generic;
using RPGArmeni.Interfaces;
using RPGArmeni.Models.Characters;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Factories
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
			IPosition startingPosition = new Position(0, 0);
			
			const char playerSymbol = 'P';
			
			return new Player(startingPosition, playerSymbol, name, playerRace);
		}

		protected virtual string GetPlayerName()
		{
			ConsoleRenderer.ForegroundColor(ConsoleColor.Green);
			ConsoleRenderer.WriteLine("Enter Player's Name: ");
			ConsoleRenderer.ResetColor();
			return ConsoleInputReader.ReadLine();
		}

		private IRace GetPlayerRace()
		{
			ConsoleRenderer.ForegroundColor(ConsoleColor.Green);
			ConsoleRenderer.WriteLine("Choose a race : ");
			ConsoleRenderer.ResetColor();

			for (var i = 0; i < AvailableRaces.Count; i++)
			{
				var currentRace = AvailableRaces[i];
				ConsoleRenderer.WriteLine($"{i + 1}: " +
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
				
				ConsoleRenderer.WriteLine("Please enter a valid race number.");
			}
		}
	}
}