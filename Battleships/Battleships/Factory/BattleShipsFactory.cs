using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Models;

namespace Battleships.Factory
{
    class BattleshipsFactory : IBattleShipFactory
    {
        private static IBattleShipFactory instanceHolder = new BattleshipsFactory();
        public BattleshipsFactory()
        {

        }
        public static IBattleShipFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public IBattlefield CreateBattleField(IGameObjectElement[,] map)
        {
            return new Battlefield(map);
        }

        public IPlayer CreatePlayer(string name, IEnumerable<IGameObject> gameObjects)
        {
            return new Player(name,gameObjects);
        }


        public IShip CreateAircraftCarrier(IList<IGameObjectElement> elements,Direction direction)
        {
            return new AircraftCarrier(elements,direction);
        }
        public IShip CreateBattleCruiser (IList<IGameObjectElement> elements,Direction direction)
        {
            return new Battlecruiser(elements,direction);
        }
        public IShip CreateDestroyer(IList<IGameObjectElement> elements,Direction direction)
        {
            return new Destroyer(elements,direction);
        }
        public IShip CreateFrigate(IList<IGameObjectElement> elements,Direction direction)
        {
            return new Frigate(elements,direction);
        }
        public IShip CreateSubmarine(IList<IGameObjectElement> elements,Direction direction)
        {
            return new Submarine(elements,direction);
        }
    }
}
