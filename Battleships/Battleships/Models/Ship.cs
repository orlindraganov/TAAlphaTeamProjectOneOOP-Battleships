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
        private Direction direction;
        private IEnumerable<IGameObjectElement> element;
        
        public Ship(Direction direction,ShipType type)
        {
            this.direction = direction;
            this.isAlive = true;
            
           
        }


        public Direction Direction { get { return this.direction; } private set { this.direction = value; } }



        public bool IsAlive { get { return this.isAlive; } set {this.isAlive=value; } }
        public int Health { get { return this.health; } set {this.health=value; } }
        public IGameObjectElement this[int index] { get ; set; }
        public IEnumerable<IGameObjectElement> Elements { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void GetHit()
        {
          
        }
    }
}
