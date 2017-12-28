using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;


namespace Battleships.Models
{
	class Battlecruiser : Ship, IShip, IGameObject
	{
		private const int COUNT = 3;

		public Battlecruiser(IPosition origin, Direction direction) : base(origin, direction, COUNT)
		{
		}
	}
}
