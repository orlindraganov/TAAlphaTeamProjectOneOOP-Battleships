using Battleships.Models;
using Battleships.Models.Contracts;
using System.Collections.Generic;

namespace Battleships.BattleshipsEngine.Contracts
{
    interface IComputerPlayer
    {
        void Initialize( Battlefield hiddenGrid, IList<IShip> ships);
    }
}
