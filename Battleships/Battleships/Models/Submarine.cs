using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
	public class Submarine : Ship, IShip, IGameObject
	{
		private const int COUNT = 2;

		public Submarine(IPosition origin, Direction direction) : base(origin, direction, COUNT)
		{
		}
	}
}
