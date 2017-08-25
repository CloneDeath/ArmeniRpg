using System;

namespace ArmeniRpg.Models
{
	public interface ITile
	{
		char Symbol { get; }
		ConsoleColor Color { get; }
		ConsoleColor DetailColor { get; }
		bool CanStandOn { get; }
	}
}