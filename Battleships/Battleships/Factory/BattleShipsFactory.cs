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
        public IBattlefield CreateBattleField(IGameObjectElement[,] map)
        {
            return new Battlefield(map);
        }

        public IPlayer CreatePlayer(string name, IEnumerable<IGameObject> gameObjects)
        {
            return new Player(name,gameObjects);
        }


        public IShip CreateAircraftCarrier(IList<IGameObjectElement> elements)
        {
            return new AircraftCarrier(elements);
        }
        public IShip CreateBattleCruiser (IList<IGameObjectElement> elements)
        {
            return new Battlecruiser(elements);
        }
        public IShip CreateDestroyer(IList<IGameObjectElement> elements)
        {
            return new Destroyer(elements);
        }
        public IShip CreateFregate(IList<IGameObjectElement> elements)
        {
            return new Frigate(elements);
        }
        public IShip CreateSubMarine(IList<IGameObjectElement> elements)
        {
            return new Submarine(elements);
        }
    }
}
