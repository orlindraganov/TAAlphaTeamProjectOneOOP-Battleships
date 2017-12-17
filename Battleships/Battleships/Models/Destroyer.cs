using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Enums;

namespace Battleships.Models
{
    class Destroyer : Ship, IShip
    {
        public Destroyer(ShipType shiptype) : base(shiptype)
        {

        }
    }
}
