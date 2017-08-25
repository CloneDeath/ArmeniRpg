using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Races
{
	public class Human : IRace
	{
		public string Name => "Human";
		public int Health => 220;
		public int Damage => 35;
	}
}