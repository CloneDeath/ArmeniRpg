using System;

namespace ArmeniRpg.UI
{
	public interface IConsoleArea
	{
		ConsoleColor DefaultForegroundColor { get; set; }
		ConsoleColor DefaultBackgroundColor { get; set; }
		
		Area Area { get; }

		void Clear();
		void Render();
		IConsoleArea CreateConsoleArea(Area subArea);
		
		void Write(Position position, string text);
		Glyph this[Position position] { get; }
	}
}