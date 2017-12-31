using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
	/// <summary>
	/// Player will hold the ships
	/// </summary>
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
