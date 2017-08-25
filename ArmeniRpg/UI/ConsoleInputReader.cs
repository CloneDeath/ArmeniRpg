using System;

namespace RPGArmeni.UI
{
	public static class ConsoleInputReader
	{
		public static string ReadLine()
		{
			return Console.ReadLine();
		}

		public static ConsoleKeyInfo ReadKey()
		{
			return Console.ReadKey();
		}
	}
}