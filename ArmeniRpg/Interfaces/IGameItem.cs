using ArmeniRpg.Models.Items;

namespace ArmeniRpg.Interfaces
{
	public interface IGameItem : IEntity
	{
		ItemState ItemState { get; set; }
	}
}