namespace ArmeniRpg.Interfaces
{
	public interface ICharacter : IEntity, IAttack, IDestroyable
	{
		int MaxHealth { get; }
	}
}