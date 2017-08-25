using System;

namespace RPGArmeni.Interfaces
{
	public interface IKeyInfo
	{
		char Character { get; }
		ConsoleKey Key { get; }
	}
}