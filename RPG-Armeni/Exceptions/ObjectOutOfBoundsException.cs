using System;

namespace RPGArmeni.Exceptions
{
	public class ObjectOutOfBoundsException : Exception
	{
		public ObjectOutOfBoundsException(string message) : base(message) { }
	}
}