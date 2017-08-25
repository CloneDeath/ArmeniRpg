using System;
using RPGArmeni.Interfaces;
using RPGArmeni.UI;

namespace RPGArmeni.Engine
{
	public class MapRenderer
	{
		public void Render(IGameEngine engine, Position offset)
		{
			ConsoleRenderer.BackgroundColor(ConsoleColor.Green);
			ConsoleRenderer.ForegroundColor(ConsoleColor.Red);
			for (var x = 0; x < engine.Map.Width; x++)
			{
				for (var y = 0; y < engine.Map.Height; y++)
				{
					var current = new Position(x, y);
					var tile = engine.Map[x, y];
					var entity = engine.GetEntityAtPosition(current);
					
					ConsoleRenderer.BackgroundColor(tile.Color);
					ConsoleRenderer.ForegroundColor(entity?.Color ?? tile.DetailColor);
					
					var symbol = entity?.Symbol ?? tile.Symbol;
					ConsoleRenderer.WriteCharacter(current + offset, symbol);
				}
			}
			ConsoleRenderer.ResetColor();
		}
	}
}