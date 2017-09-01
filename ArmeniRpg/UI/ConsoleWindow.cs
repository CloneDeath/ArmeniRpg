using System;
using System.Text;

namespace ArmeniRpg.UI
{
	public class ConsoleWindow : ConsoleArea, IConsoleWindow
	{
		private GlyphArray _previous;
		
		private static Size ConsoleSize => new Size(Console.WindowWidth, Console.WindowHeight);
		
		public ConsoleWindow() : base(new Area(Position.Zero, ConsoleSize), new GlyphArray(ConsoleSize))
		{
			Console.OutputEncoding = Encoding.UTF8;
		}

		public override Area Area => new Area(Position.Zero, ConsoleSize);

		protected override GlyphArray Glyphs
		{
			get
			{
				var g = base.Glyphs;
				if (g.Size != ConsoleSize)
				{
					_previous = null;
					g.Resize(ConsoleSize);
				}
				return g;
			}
		}

		public string Title
		{
			get => Console.Title;
			set => Console.Title = value;
		}

		public void Render()
		{
			for (var y = 0; y < Area.Height; y++)
			{
				for (var x = 0; x < Area.Width; x++)
				{
					var consoleX = x + Area.X;
					var consoleY = y + Area.Y;
					var glyph = Glyphs[x, y];

					if (_previous != null && _previous[x, y] == glyph) continue;
					
					Console.SetCursorPosition(consoleX, consoleY);
					Console.BackgroundColor = glyph.BackgroundColor;
					Console.ForegroundColor = glyph.ForegroundColor;
					Console.Write(glyph.Symbol);
				}
			}

			_previous = Glyphs.Clone();
		}
	}
}