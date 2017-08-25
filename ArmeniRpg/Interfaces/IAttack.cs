namespace ArmeniRpg.Interfaces
{
	public interface IAttack
	{
		int Damage { get; }
		void Attack(ICharacter enemy);
	}
}