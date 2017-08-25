using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.UI
{
	public class KeyInfo : IKeyInfo
	{
		private ConsoleKeyInfo _keyInfo;

		public KeyInfo()
		{
			_keyInfo = Console.ReadKey();
		}

		public ConsoleKey Key => _keyInfo.Key;
		public char Character => _keyInfo.KeyChar;
	}
}