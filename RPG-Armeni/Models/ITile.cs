using System;

namespace RPGArmeni.Models
{
	public interface ITile
	{
		char Symbol { get; }
		ConsoleColor Color { get; }
		ConsoleColor DetailColor { get; }
	}
}