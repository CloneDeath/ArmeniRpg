using System;

namespace ArmeniRpg.UI
{
	public class ConsoleArea : IConsoleArea
	{
		public virtual Area Area { get; }

		protected virtual GlyphArray Glyphs { get; }
		
		public ConsoleColor DefaultForegroundColor { get; set; } = ConsoleColor.White;
		public ConsoleColor DefaultBackgroundColor { get; set; } = ConsoleColor.Black;

		public ConsoleArea(Area area, GlyphArray glyphs)
		{
			Area = area;
			Glyphs = glyphs;
		}
		
		public void Clear()
		{
			Glyphs.SetBackgroundColor(DefaultBackgroundColor);
			Glyphs.SetForegroundColor(DefaultForegroundColor);
			Glyphs.SetSymbol(' ');
		}

		public IConsoleArea CreateConsoleArea(Area subArea)
		{
			var childArea = new Area(Area.Position + subArea.Position, subArea.Size);
			var area = new ConsoleArea(childArea, Glyphs.GetArea(subArea))
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

				Glyphs[position].Symbol = character;
				position = position + new Position(1, 0);
				if (position.X >= Area.Width)
				{
					position = new Position(0, position.Y + 1);
				}
			}
		}

		public void Write(Position position, ConsoleColor color, string text)
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

				Glyphs[position].ForegroundColor = color;
				Glyphs[position].Symbol = character;
				position = position + new Position(1, 0);
				if (position.X > Area.Width)
				{
					position = new Position(0, position.Y + 1);
				}
			}
		}

		public Glyph this[Position position] => Glyphs[position];
	}
}