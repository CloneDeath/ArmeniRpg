using System;
using System.Linq;
using ArmeniRpg.Interfaces;
using ArmeniRpg.UI;

namespace ArmeniRpg.Engine
{
	public class PlayerRenderer
	{
		public void Render(IGameEngine engine, IConsoleArea area)
		{
			var player = engine.Player;
			area.Write(Position.Zero, $"[{player.Name}]");
			
			area.Write(new Position(0, 1), "Health: ");
			area.Write(new Position(7, 1), ConsoleColor.Green, $"{player.Health}/{player.MaxHealth}");

			area.Write(new Position(0, 2), $"Damage: {player.Damage}");
			area.Write(new Position(0, 3), $"Defensive Bonus: {player.DefensiveBonus}");
			
			area.Write(new Position(0, 5), $"Number of enemies left: {engine.Entities.Count()}");
		}
	}
}