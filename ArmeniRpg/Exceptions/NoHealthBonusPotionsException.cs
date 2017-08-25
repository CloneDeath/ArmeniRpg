using System;

namespace ArmeniRpg.Exceptions
{
	public class NoHealthBonusPotionsException : Exception
	{
		public NoHealthBonusPotionsException(string message) : base(message) { }
	}
}