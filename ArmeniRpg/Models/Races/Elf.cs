using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Races
{
	public class Elf : IRace
	{
		public string Name => "Elf";
		public int Health => 250;
		public int Damage => 30;
	}
}