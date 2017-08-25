using ArmeniRpg.Models;

namespace ArmeniRpg.Interfaces
{
	public interface IMap
	{
		int Width { get; }
		int Height { get; }
		ITile this[Position position] { get; set; }
	}
}