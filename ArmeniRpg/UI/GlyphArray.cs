using System;

namespace ArmeniRpg.UI
{
	public class GlyphArray
	{
		private readonly Glyph[,] _glyphs;
		private Size _size;

		public GlyphArray(Size size)
		{
			_size = size;
			_glyphs = new Glyph[size.Width, size.Height];
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					_glyphs[x, y] = new Glyph();
				}
			}
		}

		public int Width => _size.Width;
		public int Height => _size.Height;

		public void SetBackgroundColor(ConsoleColor color)
		{
			foreach (var glyph in _glyphs)
			{
				glyph.BackgroundColor = color;
			}
		}

		public void SetForegroundColor(ConsoleColor color)
		{
			foreach (var glyph in _glyphs)
			{
				glyph.ForegroundColor = color;
			}
		}

		public void SetSymbol(char symbol)
		{
			foreach (var glyph in _glyphs)
			{
				glyph.Symbol = symbol;
			}
		}

		public Glyph this[int x, int y] => _glyphs[x, y];
		public Glyph this[Position position] => _glyphs[position.X, position.Y];
	}
}