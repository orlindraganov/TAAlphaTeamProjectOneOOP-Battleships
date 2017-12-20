using System;
using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
    public abstract class Ship : IShip
    {
        private bool isAlive;
        private int health;
        private ShipType shipType;
        private IList<IGameObjectElement> elements;
        private GameObjectElementType type;

        public Ship(IList<IGameObjectElement> elements)
        {
            this.IsAlive = true;
            
            this.Health = elements.Count;
            this.type = GameObjectElementType.Ship;
        }

        public virtual bool IsAlive { get { return this.isAlive; } set { this.isAlive = value; } }
        public virtual int Health { get { return this.health; } set { this.health = value; } }
        public IList<IGameObjectElement> Elements { get { return this.elements; } set { this.elements = value; } }
        public ShipType ShipType { get { return this.shipType; } set { this.shipType = value; } }


    }
}
