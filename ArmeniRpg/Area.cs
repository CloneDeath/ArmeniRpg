namespace ArmeniRpg
{
	public struct Area
	{
		public Position Position { get; }
		public Size Size { get; }

		public int Width => Size.Width;
		public int Height => Size.Height;
		public int X => Position.X;
		public int Y => Position.Y;

		public Area(Position position, Size size)
		{
			Position = position;
			Size = size;
		}
		
		public bool Equals(Area other)
		{
			return Position == other.Position && Size == other.Size;
		}
		
		#region Equals
		public static bool operator ==(Area left, Area right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Area left, Area right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Area)) return false;
			return Equals((Area) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Position.GetHashCode() * 397) ^ Size.GetHashCode();
			}
		}
		#endregion
	}
}