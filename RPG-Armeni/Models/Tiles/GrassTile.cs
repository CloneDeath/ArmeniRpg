using System;

namespace RPGArmeni.Models.Tiles
{
	public class GrassTile : ITile
	{
		public char Symbol => '.';
		public ConsoleColor Color => ConsoleColor.DarkGreen;
		public ConsoleColor DetailColor => ConsoleColor.Green;
	}
}