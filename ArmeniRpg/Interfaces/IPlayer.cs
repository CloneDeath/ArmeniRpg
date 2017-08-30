namespace ArmeniRpg.Interfaces
{
	public interface IPlayer : ICharacter, IMoveable, ICollect
	{
		IRace Race { get; }
		int DefensiveBonus { get; }
		void SelfHeal(IGameEngine engine);
		void DrinkHealthBonusPotion(IGameEngine engine);
		void CollectItem(IGameEngine engine, IGameItem item);
	}
}