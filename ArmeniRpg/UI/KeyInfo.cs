using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.UI
{
	public class KeyInfo : IKeyInfo
	{
		public static IKeyInfo GetInput()
		{
			return new KeyInfo();
		}
		
		private ConsoleKeyInfo _keyInfo;

		private KeyInfo()
		{
			Console.SetCursorPosition(0, 0);
			_keyInfo = Console.ReadKey();
		}

		public ConsoleKey Key => _keyInfo.Key;
		public char Character => _keyInfo.KeyChar;
	}
}