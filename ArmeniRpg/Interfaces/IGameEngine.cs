using System.Collections.Generic;
using ArmeniRpg.UI;

namespace ArmeniRpg.Interfaces
{
	public interface IGameEngine
	{
		int NumberOfItems { get; }
		int NumberOfEnemies { get; }
		IPlayer Player { get; set; }
		IMap Map { get; }
		bool IsRunning { get; set; }
		IEnumerable<IEntity> Entities { get; }
		IEnumerable<IGameItem> Items { get; }
		void AddEnemy(ICharacter enemyToBeAdded);
		void RemoveEnemy(ICharacter enemyToBeRemoved);
		void AddItem(IGameItem itemToBeAdded);
		void RemoveItem(IGameItem itemToBeRemoved);
		void Run(IConsoleWindow window);
		bool IsEmpty(Position position);
		IEntity GetEntityAtPosition(Position position);
		bool IsInBounds(Position position);
		
		void PushStatus(string status);
	}
}