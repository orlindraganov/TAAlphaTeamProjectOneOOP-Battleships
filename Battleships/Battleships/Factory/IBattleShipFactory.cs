using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;
using Battleships.View.Contracts;
using Battleships.View;

namespace Battleships.Factory
{
	public interface IBattleShipFactory
	{

		IPlayer CreatePlayer(string name,IBattleShipFactory factory);
		IShip CreateAircraftCarrier(IPosition origin, Direction direction);
		IShip CreateBattleCruiser(IPosition origin, Direction direction);
		IShip CreateDestroyer(IPosition origin, Direction direction);
		IShip CreateFrigate(IPosition origin, Direction direction);
		IShip CreateSubmarine(IPosition origin, Direction direction);
		IBattlefield CreateBattleField(IGameObjectElement[,] map);
        IPosition CreatePosition(int row, int col);
        IGameObjectElement CreateGameObjectElement(IPosition pos , GameObjectElementType type);
        IWater CreateWater();
        IView CreateConsoleView(IViewFactory factory);
		//IView CreateView(); no - po-skoro engine shte startira singleton na view-to. brgds orlin
	}
}
