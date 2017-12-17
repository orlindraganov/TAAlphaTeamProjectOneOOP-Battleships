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
        char symbolOfShip;
        private ShipType shipType;
        private IList<IGameObjectElement> element=new List<IGameObjectElement>();
        
        public Ship(ShipType shiptype)
        {
            this.isAlive = true;
            this.shipType = shiptype;
            this.health = 0;
            this.symbolOfShip = 'Z';
           
        }
        public virtual bool IsAlive { get { return this.isAlive; } set {this.isAlive=value; } }
        public virtual int Health { get { return this.health; } set {this.health=value; } }
        public virtual char SymbolOfShip { get { return this.symbolOfShip; } set {this.symbolOfShip=value; } }
        public IList<IGameObjectElement> Elements { get { return this.element; } set { this.element=value ; } }
        

        public void GetElementHit(IGameObjectElement hitGameObjectElement)
        {
            throw new NotImplementedException();
        }
    }
}
