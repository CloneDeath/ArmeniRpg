using System;

namespace ArmeniRpg.Interfaces
{
	public interface IKeyInfo
	{
		char Character { get; }
		ConsoleKey Key { get; }
	}
}