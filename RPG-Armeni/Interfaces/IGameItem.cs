using RPGArmeni.Models.Items;

namespace RPGArmeni.Interfaces
{
	public interface IGameItem : IEntity
	{
		ItemState ItemState { get; set; }
	}
}