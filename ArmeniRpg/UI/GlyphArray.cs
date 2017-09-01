using System;

namespace ArmeniRpg.UI
{
	public class GlyphArray
	{
		private Glyph[,] _glyphs;
		public Size Size { get; private set; }

		protected GlyphArray(Size size, Glyph[,] glyphs)
		{
			_glyphs = glyphs;
			Size = size;
		}
		
		public GlyphArray(Size size)
		{
			Size = size;
			_glyphs = new Glyph[size.Width, size.Height];
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					_glyphs[x, y] = new Glyph();
				}
			}
		}

		public int Width => Size.Width;
		public int Height => Size.Height;

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

		public GlyphArray GetArea(Area subArea)
		{
			var newGlyphs = new Glyph[subArea.Width, subArea.Height];
			for (var x = 0; x < subArea.Width; x++)
			{
				for (var y = 0; y < subArea.Height; y++)
				{
					var source = _glyphs[x + subArea.X, y + subArea.Y];
					newGlyphs[x, y] = source;
				}
			}
			return new GlyphArray(subArea.Size, newGlyphs);
		}

		public void Resize(Size newSize)
		{
			var old = _glyphs;
			_glyphs = new Glyph[newSize.Width, newSize.Height];
			for (var x = 0; x < newSize.Width; x++)
			{
				for (var y = 0; y < newSize.Height; y++)
				{
					if (x >= Size.Width || y >= Size.Height)
					{
						_glyphs[x, y] = new Glyph();
					}
					else
					{
						_glyphs[x, y] = old[x, y];
					}
				}
			}
			Size = newSize;
		}

		public GlyphArray Clone()
		{
			var array = new GlyphArray(Size);
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					array[x, y].Symbol = this[x, y].Symbol;
					array[x, y].BackgroundColor = this[x, y].BackgroundColor;
					array[x, y].ForegroundColor = this[x, y].ForegroundColor;
				}
			}
			return array;
		}
	}
}