using System;

namespace ArmeniRpg.Interfaces
{
	public interface IEntity
	{
		string Name { get; }
		char Symbol { get; }
		ConsoleColor Color { get; }
		Position Position { get; set; }
	}
}