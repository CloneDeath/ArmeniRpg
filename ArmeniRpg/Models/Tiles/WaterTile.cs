using System;

namespace RPGArmeni.Models.Tiles
{
	public class WaterTile : ITile
	{
		public char Symbol => '~';
		public ConsoleColor Color => ConsoleColor.DarkBlue;
		public ConsoleColor DetailColor => ConsoleColor.Black;
		public bool CanStandOn => false;
	}
}