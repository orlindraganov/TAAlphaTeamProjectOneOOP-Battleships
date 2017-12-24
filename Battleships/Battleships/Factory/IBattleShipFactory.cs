using Battleships.Enums;
using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Factory
{
   public interface IBattleShipFactory
    {

        IPlayer CreatePlayer(string name, IEnumerable<IGameObject> gameObjects);
        IShip CreateAircraftCarrier(IList<IGameObjectElement> elements, Direction direction);
        IShip CreateBattleCruiser(IList<IGameObjectElement> elements, Direction direction);
        IShip CreateDestroyer(IList<IGameObjectElement> elements, Direction direction);
        IShip CreateFrigate(IList<IGameObjectElement> elements, Direction direction);
        IShip CreateSubmarine(IList<IGameObjectElement> elements, Direction direction);
        IBattlefield CreateBattleField(IGameObjectElement[,] map);
        //IView CreateView();




    }
}
