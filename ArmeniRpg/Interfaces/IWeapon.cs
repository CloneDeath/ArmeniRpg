namespace ArmeniRpg.Interfaces
{
	public interface IWeapon : IGameItem
	{
		int AttackBonus { get; }
	}
}