using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
	public class AircraftCarrier : Ship, IShip, IGameObject
	{
		private const int COUNT = 5;

		public AircraftCarrier(IPosition origin, Direction direction) : base(origin, direction, COUNT)
		{
		}
	}
}
