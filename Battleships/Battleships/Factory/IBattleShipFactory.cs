using Battleships.Enums;
using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Factory
{
    interface IBattleShipFactory
    {
        
        IPlayer CreatePlayer(string name, IEnumerable<IGameObject> gameObjects);
        IBattlefield CreateBattleField(IGameObjectElement[,] map);
        //IView CreateView();




    }
}
