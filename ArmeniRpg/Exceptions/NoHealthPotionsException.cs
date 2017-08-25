using System;

namespace ArmeniRpg.Exceptions
{
	public class NoHealthPotionsException : Exception
	{
		public NoHealthPotionsException(string message) : base(message) { }
	}
}