using System;
using System.Text;

namespace ArmeniRpg.UI
{
	public class ConsoleWindow : ConsoleArea, IConsoleWindow
	{
		public ConsoleWindow() : base(new Area(Position.Zero, new Size(Console.WindowWidth, Console.WindowHeight)))
		{
			Console.OutputEncoding = Encoding.UTF8;
		}

		public string Title
		{
			get => Console.Title;
			set => Console.Title = value;
		}

	}
}