using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
	public class Frigate : Ship, IShip, IGameObject
	{
		private const int COUNT = 4;

		public Frigate(IPosition origin, Direction direction) : base(origin, direction, COUNT)
		{
		}
	}
}
