using System;
using System.Linq;
using ArmeniRpg.Interfaces;
using ArmeniRpg.Models.Containers;
using ArmeniRpg.UI;

namespace ArmeniRpg.Engine
{
	public class PlayerRenderer
	{
		public void Render(IGameEngine engine, IConsoleArea area)
		{
			var player = engine.Player;
			area.Write(Position.Zero, $"[{player.Name}]");
			area.Write(new Position(0, 1), $"{player.Race.Name}");
			
			area.Write(new Position(0, 3), "Health: ");
			area.Write(new Position(7, 3), ConsoleColor.Green, $"{player.Health}/{player.MaxHealth}");

			area.Write(new Position(0, 4), $"Damage: {player.Damage}");
			area.Write(new Position(0, 5), $"Defensive Bonus: {player.DefensiveBonus}");
			
			area.Write(new Position(0, 7), $"Number of enemies left: {engine.Entities.Count()}");

			var itemArea = new Area(new Position(0, 9), new Size(area.Area.Width, area.Area.Height - 9));
			RenderInventory(player.Inventory, area.CreateConsoleArea(itemArea));
		}

		private void RenderInventory(IInventory inventory, IConsoleArea area)
		{
			area.Write(Position.Zero, $"Main Hand: {inventory.MainHandSlot.Item?.Name ?? "--empty--"}");
			var backpack = inventory.BackPack;
			for (var i = 0; i < backpack.Count(); i++)
			{
				var slot = backpack[i];
				var itemName = slot.Item?.Name ?? "--empty--";
				area.Write(new Position(0, i + 2), $"{(char) ('a' + i)}) {itemName}");
			}
		}
	}
}