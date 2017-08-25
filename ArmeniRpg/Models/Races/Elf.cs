using RPGArmeni.Interfaces;

namespace RPGArmeni.Models.Characters
{
	public class Elf : IRace
	{
		public string Name => "Elf";
		public int Health => 250;
		public int Damage => 30;
	}
}