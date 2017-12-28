using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.Factory
{
	public interface IBattleShipFactory
	{

		IPlayer CreatePlayer(string name, IEnumerable<IGameObject> gameObjects);
		IShip CreateAircraftCarrier(IPosition origin, Direction direction);
		IShip CreateBattleCruiser(IPosition origin, Direction direction);
		IShip CreateDestroyer(IPosition origin, Direction direction);
		IShip CreateFrigate(IPosition origin, Direction direction);
		IShip CreateSubmarine(IPosition origin, Direction direction);
		IBattlefield CreateBattleField(IGameObjectElement[,] map);
		//IView CreateView();
	}
}
