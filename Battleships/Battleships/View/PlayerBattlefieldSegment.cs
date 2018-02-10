using System;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;

namespace Battleships.View
{
    public class PlayerBattlefieldSegment : BattlefieldSegment, IViewSegment, IBattlefieldSegment
    {
        public PlayerBattlefieldSegment(int startingRow, int height, int startingCol, int width) : base(startingRow, height, startingCol, width)
        {
        }

        protected override void DrawShip(IShip ship)
        {
            Direction direction = this.GetShipDirection(ship);
            char bow;
            char hull;
            char stern;
            char hit = ViewSettings.HitSymbol;

            switch (direction)
            {
                case Direction.Left:
                    bow = ViewSettings.HorizontalShipRightEnd;
                    hull = ViewSettings.HorizontalShipMiddle;
                    stern = ViewSettings.HorizontalShipLeftEnd;
                    break;

                case Direction.Right:
                    bow = ViewSettings.HorizontalShipLeftEnd;
                    hull = ViewSettings.HorizontalShipMiddle;
                    stern = ViewSettings.HorizontalShipRightEnd;
                    break;

                case Direction.Up:
                    bow = ViewSettings.VerticalShipLowerEnd;
                    hull = ViewSettings.VerticalShipMiddle;
                    stern = ViewSettings.VerticalShipUpperEnd;
                    break;

                case Direction.Down:
                    bow = ViewSettings.VerticalShipUpperEnd;
                    hull = ViewSettings.VerticalShipMiddle;
                    stern = ViewSettings.VerticalShipLowerEnd;
                    break;

                default:
                    throw new ArgumentException("Direction");
            }

            for (int i = 0; i < ship.Elements.Count; i++)
            {
                var elementPosition = CalculateDrawingPosition(ship.Elements[i].Position);

                Console.SetCursorPosition(elementPosition.Col, elementPosition.Row);

                this.SetConsole(ConsoleSettings.ShipNotHit);
                if (ship.Elements[i].IsHit)
                {
                    this.SetConsole(ConsoleSettings.ShipHit);
                    Console.Write(hit);
                    continue;
                }

                if (i == 0)
                {
                    Console.Write(bow);
                    continue;
                }

                if (i == ship.Elements.Count - 1)
                {
                    Console.Write(stern);
                    continue;
                }

                Console.Write(hull);
            }
        }

        private Direction GetShipDirection(IShip ship)
        {
            return ship.Direction;
        }
    }
}

