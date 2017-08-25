using ArmeniRpg.Interfaces;
using ArmeniRpg.UI;

namespace ArmeniRpg.Engine
{
	public class MapRenderer
	{
		public void Render(IGameEngine engine, IConsoleArea console)
		{
			var renderOffset = new Position(console.Area.Width / 2, console.Area.Height / 2);
			
			for (var x = 0; x < console.Area.Width; x++)
			{
				for (var y = 0; y < console.Area.Height; y++)
				{
					var consolePosition = new Position(x, y);
					var worldPosition = engine.Player.Position + consolePosition - renderOffset;
					
					if (!engine.IsInBounds(worldPosition)) continue;
					
					var tile = engine.Map[worldPosition];
					var entity = engine.GetEntityAtPosition(worldPosition);

					console[consolePosition].BackgroundColor = tile.Color;
					console[consolePosition].ForegroundColor = entity?.Color ?? tile.DetailColor;
					
					var symbol = entity?.Symbol ?? tile.Symbol;
					
					console[consolePosition].Symbol = symbol;
				}
			}
		}
	}
}