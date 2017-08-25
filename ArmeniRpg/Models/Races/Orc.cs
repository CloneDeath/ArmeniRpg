using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Races
{
	public class Orc : IRace
	{
		public string Name => "Orc";
		public int Health => 260;
		public int Damage => 20;
	}
}