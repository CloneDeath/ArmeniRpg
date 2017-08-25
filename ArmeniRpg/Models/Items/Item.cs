using System;
using ArmeniRpg.Interfaces;

namespace ArmeniRpg.Models.Items
{
	public abstract class Item : IGameItem
	{
		protected Item()
		{
			ItemState = ItemState.Available;
		}
		
		public abstract char Symbol { get; }
		public abstract ConsoleColor Color { get; }

		public ItemState ItemState { get; set; }
		public Position Position { get; set; }

		public override string ToString()
		{
			return string.Format("{0}", GetType().Name);
		}
	}
}