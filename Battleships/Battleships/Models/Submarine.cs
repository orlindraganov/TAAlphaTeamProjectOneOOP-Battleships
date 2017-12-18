using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Enums;

namespace Battleships.Models
{
    class Submarine : Ship, IShip, IGameObject
    {
        public Submarine(ShipType shiptype, IList<IGameObjectElement> elements) : base(shiptype, elements)
        {
            this.ShipType = ShipType.Submarine;

        }
    }
}
