using System;
using System.Text;

namespace ArmeniRpg.UI
{
	public class ConsoleWindow : ConsoleArea, IConsoleWindow
	{
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
					Console.SetCursorPosition(consoleX, consoleY);

					var glyph = Glyphs[x, y];
					Console.BackgroundColor = glyph.BackgroundColor;
					Console.ForegroundColor = glyph.ForegroundColor;
					Console.Write(glyph.Symbol);
				}
			}
		}
	}
}