using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Items
{
	public abstract class Item : IGameItem
	{
		public abstract string Name { get; }
		public abstract char Symbol { get; }
		public abstract ConsoleColor Color { get; }
		public Position Position { get; set; }
	}
}