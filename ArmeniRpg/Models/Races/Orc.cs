using RPGArmeni.Interfaces;

namespace RPGArmeni.Models.Characters
{
	public class Orc : IRace
	{
		public string Name => "Orc";
		public int Health => 260;
		public int Damage => 20;
	}
}