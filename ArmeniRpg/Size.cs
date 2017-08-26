namespace ArmeniRpg
{
	public struct Size
	{
		public Size(int width, int height)
		{
			Width = width;
			Height = height;
		}
		
		public int Width { get; }
		public int Height { get; }

		public static bool operator ==(Size left, Size right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Size left, Size right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Size)) return false;
			return Equals((Size) obj);
		}

		public bool Equals(Size other)
		{
			return Width == other.Width && Height == other.Height;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Width * 397) ^ Height;
			}
		}

		public override string ToString()
		{
			return $"Width: {Width}, Height: {Height}";
		}
	}
}