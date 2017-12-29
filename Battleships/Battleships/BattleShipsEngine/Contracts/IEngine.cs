using System.Collections.Generic;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.Models.Contracts;

namespace Battleships.BattleShipsEngine.Contracts
{
	public interface IEngine
	{
		void Start();

		IReader Reader { get; set; }

		IWriter Writer { get; set; }

		IParser Parser { get; set; }

		IList<IShip> Ships { get; }

		void AddShip(IShip ship);

		void FireAt(int row, int column);
	}
}
