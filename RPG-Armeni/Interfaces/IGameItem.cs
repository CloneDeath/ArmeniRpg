using RPGArmeni.Models.Items;

namespace RPGArmeni.Interfaces
{
	public interface IGameItem : IGameObject
	{
		ItemState ItemState { get; set; }
	}
}