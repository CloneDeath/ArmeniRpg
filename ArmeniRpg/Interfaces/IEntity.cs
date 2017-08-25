using System;

namespace ArmeniRpg.Interfaces
{
	public interface IEntity
	{
		char Symbol { get; }
		ConsoleColor Color { get; }
		Position Position { get; set; }
	}
}