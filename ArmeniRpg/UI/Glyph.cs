using System;

namespace ArmeniRpg.UI
{
	public class Glyph
	{
		public char Symbol { get; set; } = ' ';
		public ConsoleColor ForegroundColor = ConsoleColor.White;
		public ConsoleColor BackgroundColor = ConsoleColor.Black;
		
		public static bool operator ==(Glyph left, Glyph right)
		{
			if (ReferenceEquals(left, right)) return true;
			return !ReferenceEquals(left, null) && left.Equals(right);
		}

		public static bool operator !=(Glyph left, Glyph right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Glyph)) return false;
			return Equals((Glyph) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (int) ForegroundColor;
				hashCode = (hashCode * 397) ^ (int) BackgroundColor;
				hashCode = (hashCode * 397) ^ Symbol.GetHashCode();
				return hashCode;
			}
		}

		public bool Equals(Glyph other)
		{
			return Symbol == other.Symbol && BackgroundColor == other.BackgroundColor &&
			       ForegroundColor == other.ForegroundColor;
		}

	}
}