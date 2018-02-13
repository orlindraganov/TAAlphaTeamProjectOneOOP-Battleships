using Battleships.Enums;
using Battleships.Models;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;
using Battleships.Utilities;
using System;
using System.Collections.Generic;

namespace Battleships.Factory
{
    public class BattleShipFactory : IBattleShipFactory
    {
        public BattleShipFactory()
        {

        }

        public IBattlefield CreateBattleField()
        {
            var map = new IGameObjectElement[Battlefield.DefaultHeight, Battlefield.DefaultWidth];
            return new Battlefield(map);
        }

        public IPlayer CreatePlayer(string name, IWater water, IBattlefield battlefield)
        {
            return new Player(name, water, battlefield);
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
            if (pos == null)
            {
                throw new NullReferenceException();
            }
            return new GameObjectElement(pos, type);
        }

        public IWater CreateWater(int height, int width)
        {
            var elements = new List<IGameObjectElement>();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var pos = new Position(i, j);
                    var el = this.CreateGameObjectElement(pos, GameObjectElementType.Water);
                    elements.Add(el);
                }
            }

            return new Water(elements);
        }
        //public IView CreateConsoleView(IViewFactory factory)
        //{
        //    return new ConsoleView(factory);
        //}
    }
}
