using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
	public interface IPlayer
	{
	    IList<IShip> Ships { get; }

        IWater Water { get; }

        IBattlefield Battlefield { get; }

        bool IsAlive { get; }

		int Health { get; }

		string Name { get; }

		void Fire();

		void AddShip(IShip ship);
	}
}
