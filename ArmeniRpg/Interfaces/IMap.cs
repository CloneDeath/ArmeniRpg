using RPGArmeni.Models;

namespace RPGArmeni.Interfaces
{
	public interface IMap
	{
		int Width { get; }
		int Height { get; }
		ITile this[Position position] { get; set; }
	}
}