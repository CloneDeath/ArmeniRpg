using System;

namespace ArmeniRpg.Exceptions
{
	public class BackPackFullException : Exception
	{
		public BackPackFullException(string message) : base(message) { }
	}
}