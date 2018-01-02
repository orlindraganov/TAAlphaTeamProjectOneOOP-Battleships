using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
	class Destroyer : Ship, IShip, IGameObject
	{
		private const int COUNT = 1;

		public Destroyer(IPosition origin, Direction direction) : base(origin, direction, COUNT)
		{
		}
	}
}
