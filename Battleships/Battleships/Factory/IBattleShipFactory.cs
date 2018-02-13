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
        IPlayer CreatePlayer(string name, IWater water, IBattlefield battlefield);
        IShip CreateAircraftCarrier(IPosition origin, Direction direction);
        IShip CreateBattleCruiser(IPosition origin, Direction direction);
        IShip CreateDestroyer(IPosition origin, Direction direction);
        IShip CreateFrigate(IPosition origin, Direction direction);
        IShip CreateSubmarine(IPosition origin, Direction direction);
        IBattlefield CreateBattleField();
        IPosition CreatePosition(int row, int col);
        IGameObjectElement CreateGameObjectElement(IPosition pos, GameObjectElementType type);
        IWater CreateWater(int height, int width);
        //       IView CreateConsoleView(IViewFactory factory);
        //IView CreateView(); no - po-skoro engine shte startira singleton na view-to. brgds orlin
    }
}
