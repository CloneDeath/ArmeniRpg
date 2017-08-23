using System.Linq;
using RPGArmeni.Exceptions;
using RPGArmeni.Interfaces;
using RPGArmeni.Models.Items;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
	public class MovePlayerCommand : GameCommand
	{
		public MovePlayerCommand(IGameEngine engine) : base(engine)
		{
		}

		public override void Execute(IKeyInfo directionKey)
		{
			Engine.Player.Move(directionKey);

			var currentEnemy = FindEnemy();

			if (currentEnemy != null)
			{
				EnterBattle(currentEnemy);
				return;
			}

			var currentItem = FindItem();

			if (currentItem != null)
				CollectItem(currentItem);
		}

		public override void Execute()
		{
		}

		private void CollectItem(IGameItem currentItem)
		{
			currentItem.ItemState = ItemState.Collected;
			Engine.Player.Inventory.BackPack.LootItem(currentItem);
			ConsoleRenderer.WriteLine("{0} collected!", currentItem.GetType().Name);
		}


		private void EnterBattle(ICharacter currentEnemy)
		{
			ConsoleRenderer.WriteLine(
				"An enemy {0} is approaching. Prepare for battle!",
				currentEnemy.GetType().Name);
			while (true)
			{
				Engine.Player.Attack(currentEnemy);
				ConsoleRenderer.WriteLine("You smash the {0} for {1} damage!",
					currentEnemy.GetType().Name, Engine.Player.Damage);

				if (currentEnemy.Health <= 0)
				{
					ConsoleRenderer.WriteLine("Enemy killed!");
					ConsoleRenderer.WriteLine("Health Remaining: {0}", Engine.Player.Health);
					Engine.RemoveEnemy(currentEnemy);
					return;
				}

				currentEnemy.Attack(Engine.Player);
				ConsoleRenderer.WriteLine("The {0} hits you for {1} damage!",
					currentEnemy.GetType().Name, currentEnemy.Damage);

				if (Engine.Player.Health < 150 && Engine.Player.Inventory.BackPack.SlotList.Any(x => x.GameItem is HealthPotion
				                                                                                     || x.GameItem is
					                                                                                     HealthBonusPotion))
					try
					{
						Engine.Player.SelfHeal();
					}
					catch (NoHealthPotionsException ex)
					{
						ConsoleRenderer.WriteLine(ex.Message);
					}

				if (Engine.Player.Health <= 0)
				{
					Engine.IsRunning = false;
					GameStateScreens.ShowGameOverScreen();
					return;
				}
			}
		}

		private IGameItem FindItem()
		{
			return Engine
				.Items
				.FirstOrDefault(e => e.Position.X == Engine.Player.Position.X
				                     && e.Position.Y == Engine.Player.Position.Y
				                     && e.ItemState == ItemState.Available);
		}

		private ICharacter FindEnemy()
		{
			return Engine
				.Characters
				.FirstOrDefault(x => x.Position.X == Engine.Player.Position.X
				                     && x.Position.Y == Engine.Player.Position.Y) as ICharacter;
		}
	}
}