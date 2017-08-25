using System;

namespace ArmeniRpg.Exceptions
{
	public class InvalidHealthException : Exception
	{
		public InvalidHealthException(string message) : base(message) { }
	}
}