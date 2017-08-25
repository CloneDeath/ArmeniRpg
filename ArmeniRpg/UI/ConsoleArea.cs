using System;

namespace ArmeniRpg.UI
{
	public class ConsoleArea : IConsoleArea
	{
		public Area Area { get; }

		private readonly GlyphArray _glyphs;
		
		public ConsoleColor DefaultForegroundColor { get; set; } = ConsoleColor.White;
		public ConsoleColor DefaultBackgroundColor { get; set; } = ConsoleColor.Black;

		public ConsoleArea(Area area)
		{
			Area = area;
			_glyphs = new GlyphArray(area.Size);
		}
		
		public void Clear()
		{
			_glyphs.SetBackgroundColor(DefaultBackgroundColor);
			_glyphs.SetForegroundColor(DefaultForegroundColor);
			_glyphs.SetSymbol(' ');
		}

		public void Render()
		{
			for (var y = 0; y < Area.Height; y++)
			{
				for (var x = 0; x < Area.Width; x++)
				{
					var consoleX = x + Area.X;
					var consoleY = y + Area.Y;
					Console.SetCursorPosition(consoleX, consoleY);

					var glyph = _glyphs[x, y];
					Console.BackgroundColor = glyph.BackgroundColor;
					Console.ForegroundColor = glyph.ForegroundColor;
					Console.Write(glyph.Symbol);
				}
			}
		}

		public IConsoleArea CreateConsoleArea(Area subArea)
		{
			var area = new ConsoleArea(new Area(Area.Position + subArea.Position, subArea.Size))
			{
				DefaultBackgroundColor = DefaultBackgroundColor,
				DefaultForegroundColor = DefaultForegroundColor
			};
			area.Clear();
			return area;
		}

		public void Write(Position position, string text)
		{
			foreach (var character in text)
			{
				switch (character)
				{
					case '\r':
						position = new Position(0, position.Y);
						continue;
					case '\n':
						position = new Position(0, position.Y + 1);
						break;
				}
				
				_glyphs[position].Symbol = character;
				position = position + new Position(1, 0);
				if (position.X > Area.Width)
				{
					position = new Position(0, position.Y + 1);
				}
			}
		}

		public Glyph this[Position position] => _glyphs[position];
	}
}