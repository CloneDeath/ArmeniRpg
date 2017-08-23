using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using RPGArmeni.Attributes;
using RPGArmeni.Interfaces;
using RPGArmeni.Models.Characters;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Factories
{
	public class PlayerFactory
	{
		private static PlayerFactory instance;
		private static readonly Regex PlayerNamePattern = new Regex("([a-zA-Z]+){2,10}");

		private readonly List<Type> availableRaces = Assembly
			.GetExecutingAssembly()
			.GetTypes()
			.Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(RaceAttribute)))
			.ToList();

		private PlayerFactory()
		{
		}

		public static PlayerFactory Instance
		{
			get
			{
				if (instance == null)
					instance = new PlayerFactory();

				return instance;
			}
		}

		public IGameEngine Engine { get; set; }

		public IPlayer CreatePlayer()
		{
			var name = GetPlayerName();
			var playerRace = GetPlayerRace();
			IPosition startingPosition = new Position(0, 0);
			var playerSymbol = 'P';
			Engine.Map.Matrix[startingPosition.X, startingPosition.Y] = playerSymbol;

			return new Player(startingPosition, playerSymbol, name, playerRace);
		}

		private string GetPlayerName()
		{
			string name;
			ConsoleRenderer.ForegroundColor(ConsoleColor.Green);
			ConsoleRenderer.Write("Type player's name : ");
			ConsoleRenderer.ResetColor();
			ConsoleRenderer.WriteLine("(including only small and capital letters and between 2 and 10 characters)");
			while (true)
				try
				{
					name = ConsoleInputReader.ReadLine();

					if (!PlayerNamePattern.IsMatch(name))
						throw new ArgumentException("Invalid name. Try again.");

					break;
				}
				catch (ArgumentException ex)
				{
					ConsoleRenderer.WriteLine(ex.Message);
				}

			ConsoleRenderer.ForegroundColor(ConsoleColor.Green);
			ConsoleRenderer.WriteLine("Player name set to: {0}", name);
			ConsoleRenderer.ResetColor();

			return name;
		}

		private IRace GetPlayerRace()
		{
			ConsoleRenderer.ForegroundColor(ConsoleColor.Green);
			ConsoleRenderer.WriteLine("Choose a race : ");
			ConsoleRenderer.ResetColor();

			for (var i = 0; i < availableRaces.Count; i++)
			{
				var currentRace = Activator.CreateInstance(availableRaces[i]) as IRace;
				ConsoleRenderer.WriteLine("{0}: {1} - (Health: {2}, Damage: {3})",
					i + 1, availableRaces[i].Name, currentRace.Health, currentRace.Damage);
			}

			int index;
			while (true)
				try
				{
					var raceNumber = ConsoleInputReader.ReadLine();

					if (!int.TryParse(raceNumber, out index))
						throw new ArgumentException("Please enter a valid race number.");

					index = int.Parse(raceNumber);

					if (index < 1 || index > availableRaces.Count)
						throw new ArgumentOutOfRangeException("Please enter a valid race number.");

					break;
				}

				catch (ArgumentOutOfRangeException ex)
				{
					ConsoleRenderer.WriteLine(ex.Message);
				}
				catch (ArgumentException ex)
				{
					ConsoleRenderer.WriteLine(ex.Message);
				}

			ConsoleRenderer.ForegroundColor(ConsoleColor.Green);
			ConsoleRenderer.WriteLine("Race chosen: {0}", availableRaces[index - 1].Name);
			ConsoleRenderer.ResetColor();

			return Activator.CreateInstance(availableRaces[index - 1]) as IRace;
		}
	}
}