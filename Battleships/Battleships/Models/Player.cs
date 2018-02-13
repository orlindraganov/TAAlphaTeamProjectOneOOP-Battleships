using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Enums;
using Battleships.Utilities.Contracts;
using Bytes2you.Validation;

namespace Battleships.Models
{
    public class Player : IPlayer
    {
        private bool isAlive;
        private int health;
        private string name;
        private readonly IList<IShip> ships;
        private readonly IWater water;
        private readonly IBattlefield battlefield;

        public Player(string name, IWater water, IBattlefield battlefield)
        {
            this.Name = name;
            this.ships = new List<IShip>();
            SetHealth();
            this.IsAlive = true;

            Guard.WhenArgument(water, "Water").IsNull().Throw();
            this.water = water;

            Guard.WhenArgument(battlefield, "Battlefield").IsNull().Throw();
            this.battlefield = battlefield;
        }

        public IList<IShip> Ships
        {
            get
            {
                return this.ships;
            }
        }

        public IWater Water
        {
            get
            {
                return this.water;
            }
        }

        public IBattlefield Battlefield
        {
            get
            {
                return this.battlefield;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            private set
            {
                this.isAlive = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public void Fire()
        {
            throw new NotImplementedException();
        }

        private void GetHit()
        {
            this.SetHealth();
        }

        public void AddShip(IShip ship)
        {
            if (this.Ships.Contains(ship))
            {
                throw new InvalidOperationException("Ship already added");
            }

            foreach (var element in ship.Elements)
            {
                this.RemoveWaterElement(element.Position);
                this.Battlefield[element.Position] = element;
                element.WasHitEvent += Element_WasHitEvent;
            }

            this.Ships.Add(ship);
            this.SetHealth();
        }

        private void Element_WasHitEvent(object sender, EventArgs e)
        {
            this.GetHit();
        }

        private void AddWaterElement(IGameObjectElement element)
        {
            if (this.Water.Elements.Contains(element))
            {
                throw new InvalidOperationException("Water element already added");
            }

            this.Water.Elements.Add(element);
            this.Battlefield[element.Position] = element;
        }

        private void RemoveWaterElement(IPosition posistion)
        {
            var element = this.Battlefield[posistion];
            if (element.Type != GameObjectElementType.Water)
            {
                throw new InvalidOperationException("Not water");
            }

            this.Water.Elements.Remove(element);
            this.Battlefield[posistion] = null;
        }

        private void SetHealth()
        {
            this.Health = this.Ships.Sum(s => s.Health);
            CheckIfDead();
        }

        private void CheckIfDead()
        {
            this.IsAlive = this.Health > 0;
        }
    }
}
