using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
    public abstract class Ship : IShip
    {
        
        protected Ship(IPosition origin, Direction direction, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Must be positive", nameof(count));
            }

            this.Elements = new List<IGameObjectElement>();
            for (int i = 0; i < count; i++)
            {
                int x = origin.Row;
                int y = origin.Col;
                switch (direction)
                {
                    case Direction.Up:
                        x -= i;
                        break;
                    case Direction.Right:
                        y += i;
                        break;
                    case Direction.Down:
                        x += i;
                        break;
                    case Direction.Left:
                        y -= i;
                        break;
                }

                var gameObjectElement = new GameObjectElement()
                {
                    IsHit = false,
                    Position = new Position()
                    {
                        Row = x,
                        Col = y
                    }
                };
                gameObjectElement.WasHitEvent += Element_WasHitEvent;
                this.Elements.Add(gameObjectElement);
            }

            this.Health = count;
            this.Direction = direction;

        }

        public bool IsAlive => this.Health > 0;

        public int Health { get; set; }

        public Direction Direction { get; set; }

        private void GetHit()
        {
            this.Health = this.Elements.Count(e => !e.IsHit);
        }

        private void Element_WasHitEvent(object sender, EventArgs e)
        {
            this.GetHit();
        }

        public IList<IGameObjectElement> Elements { get; set; }
    }
}
