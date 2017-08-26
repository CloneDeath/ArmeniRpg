using System;
using System.Text;

namespace ArmeniRpg.UI
{
	public class ConsoleWindow : ConsoleArea, IConsoleWindow
	{
		public ConsoleWindow() 
			: base(new Area(Position.Zero, new Size(Console.WindowWidth, Console.WindowHeight)), 
				new GlyphArray(new Size(Console.WindowWidth, Console.WindowHeight)))
		{
			Console.OutputEncoding = Encoding.UTF8;
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