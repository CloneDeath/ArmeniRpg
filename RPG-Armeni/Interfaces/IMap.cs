using RPGArmeni.Models;

namespace RPGArmeni.Interfaces
{
	public interface IMap
	{
		int Width { get; }
		int Height { get; }
		ITile this[int x,int y] { get; set; }
	}
}