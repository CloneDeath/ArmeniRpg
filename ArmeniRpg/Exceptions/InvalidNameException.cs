using System;

namespace ArmeniRpg.Exceptions
{
	public class InvalidNameException : Exception
	{
		public InvalidNameException(string message) : base(message) { }
	}
}