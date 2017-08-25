namespace ArmeniRpg
{
	public struct Position
	{
		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }

		public static bool operator ==(Position left, Position right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Position left, Position right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Position)) return false;
			var other = (Position) obj;
			return other.X == X && other.Y == Y;
		}

		public override int GetHashCode()
		{
			return X + Y << 16;
		}

		public static Position operator +(Position left, Position right)
		{
			return new Position(left.X + right.X, left.Y + right.Y);
		}
	}
}