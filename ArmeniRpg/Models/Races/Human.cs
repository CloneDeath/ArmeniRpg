using RPGArmeni.Interfaces;

namespace RPGArmeni.Models.Characters
{
	public class Human : IRace
	{
		public string Name => "Human";
		public int Health => 220;
		public int Damage => 35;
	}
}