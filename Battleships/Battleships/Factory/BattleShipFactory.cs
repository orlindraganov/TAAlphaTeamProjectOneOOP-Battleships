using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Models;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;
using Battleships.Utilities;
using Battleships.View.Contracts;
using Battleships.View;

namespace Battleships.Factory
{
    public class BattleShipFactory : IBattleShipFactory
    {
        public BattleShipFactory()
        {

        }


        public IBattlefield CreateBattleField(IGameObjectElement[,] map)
        {
            return new Battlefield(map);
        }

        public IPlayer CreatePlayer(string name, IBattleShipFactory factory)
        {
            return new Player(name, factory);
        }


        public IShip CreateAircraftCarrier(IPosition origin, Direction direction)
        {
            return new AircraftCarrier(origin, direction);
        }
        public IShip CreateBattleCruiser(IPosition origin, Direction direction)
        {
            return new Battlecruiser(origin, direction);
        }
        public IShip CreateDestroyer(IPosition origin, Direction direction)
        {
            return new Destroyer(origin, direction);
        }
        public IShip CreateFrigate(IPosition origin, Direction direction)
        {
            return new Frigate(origin, direction);
        }
        public IShip CreateSubmarine(IPosition origin, Direction direction)
        {
            return new Submarine(origin, direction);
        }
        public IPosition CreatePosition(int row, int col)
        {
            return new Position(row, col);
        }

        public IGameObjectElement CreateGameObjectElement(IPosition pos, GameObjectElementType type)
        {
            return new GameObjectElement(pos, type);
        }

        public IWater CreateWater()
        {
            return new Water();
        }
        public IView CreateConsoleView(IViewFactory factory)
        {
            return new ConsoleView(factory);
        }
    }
}
