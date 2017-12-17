using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Enums;
using Battleships.Utilities.Contracts;
using Battleships.Utilities;

namespace Battleships.Models.Contracts
{
    public abstract class Ship : IShip, IShipElement
    {
        private bool isAlive;
        private int health;
        private ShipType shipType;
        private IPosition position;
        private GameObjectElementType elementType;
        private Direction direction;
        private bool isHit;
        public Ship(Position position, Direction direction)
        {
            this.position = position;
            this.direction = direction;
            this.elementType = GameObjectElementType.Ship;
            this.isAlive = true;
            this.isHit = false;
           
        }


        public IPosition Position { get { return this.position; } set { this.position = value; } }
        public Direction Direction { get { return this.direction; } private set { this.direction = value; } }



        public bool IsAlive { get { return this.isAlive; } set {this.isAlive=value; } }
        public int Health { get { return this.health; } set {this.health=value; } }
        public IGameObjectElement this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IGameObjectElement> Elements { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsHit { get; set; }

        

        public GameObjectElementType Type => throw new NotImplementedException();

        public void GetElementHit(IGameObjectElement hitGameObjectElement)
        {
            throw new NotImplementedException();
        }

        public void GetHit()
        {
          
        }
    }
}
