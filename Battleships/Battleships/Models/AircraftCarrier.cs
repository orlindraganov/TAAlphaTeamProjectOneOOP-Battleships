using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Enums;

namespace Battleships.Models
{
    class AircraftCarrier : Ship, IShip, IGameObject
    {
        public AircraftCarrier(IList<IGameObjectElement> elements) : base(elements)
        {
            this.ShipType = ShipType.Carrier;
        }
    }
}
