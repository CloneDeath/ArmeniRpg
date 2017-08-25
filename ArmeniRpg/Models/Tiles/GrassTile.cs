using System;

namespace ArmeniRpg.Models.Tiles
{
	public class GrassTile : ITile
	{
		public char Symbol => '.';
		public ConsoleColor Color => ConsoleColor.Black;
		public ConsoleColor DetailColor => ConsoleColor.Green;
		public bool CanStandOn => true;
	}
}