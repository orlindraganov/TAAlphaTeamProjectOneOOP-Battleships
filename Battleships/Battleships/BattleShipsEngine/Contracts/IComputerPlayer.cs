
using Battleships.Models;
using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.BattleshipsEngine.Contracts
{
    interface IComputerPlayer
    {
        void Initialize( Battlefield hiddenGrid, IList<IShip> ships);
    }
}
