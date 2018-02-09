﻿using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Enums;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;
using Bytes2you.Validation;

namespace Battleships.Models
{
    public class Player : IPlayer
    {
        private bool isAlive;
        private int health;
        private string name;
        private IList<IShip> ships;
        private IWater water;
        private IBattlefield battlefield;
        private IGameObjectElement[,] map= new IGameObjectElement[10, 10];

        public Player()
        {
            name = "Gosho";
        }
        public Player(string name
            //IGameObjectElement[,] map ,
            //IBattlefield battlefield,
            //IList<IShip> ships ,
            //IWater water


            )
        {
            
            this.Name = name;
            this.ships = new List<IShip>();
            this.map = map;
            this.water = water;

            SetHealth();
            this.IsAlive = true;



     
            this.Water = new Water();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    var pos = new Position(i, j);
                    var el = new GameObjectElement(pos, GameObjectElementType.Water);
                    this.AddWaterElement(el);
                }
            }

        }

        public IList<IShip> Ships
        {
            get
            {
                return this.ships;
            }
            private set
            {
                Guard.WhenArgument(value, "Ships").IsNull().Throw();
                this.ships = value;
            }
        }

        public IWater Water
        {
            get
            {
                return this.water;
            }
            private set
            {
                Guard.WhenArgument(value, "Water").IsNull().Throw();
                this.water = value;
            }
        }

        public IBattlefield Battlefield
        {
            get
            {
                return this.battlefield;
            }
             set
            {
                Guard.WhenArgument(value, "Battlefield").IsNull().Throw();
                this.battlefield = value;
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
