using System;
using RPGArmeni.Interfaces;

namespace RPGArmeni.UI
{
	public class KeyInfo : IKeyInfo
	{
		private ConsoleKeyInfo keyInfo;

		public KeyInfo()
		{
			keyInfo = Console.ReadKey();
		}

		public ConsoleKey Key => keyInfo.Key;
	}
}