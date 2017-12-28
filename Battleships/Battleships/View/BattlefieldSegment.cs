using System;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;

namespace Battleships.View
{
    public class BattlefieldSegment : ViewSegment, IViewSegment
    {
        public BattlefieldSegment(int startingRow, int height, int startingCol, int width) : base(startingRow, height, startingCol, width)
        {
        }

        private char BattlefieldHorizontalSymbol
        {
            get
            {
                return Constants.BattlefieldHorizontalBorder;
            }
        }

        private char BattlefieldVerticalSymbol
        {
            get
            {
                return Constants.BattlefieldVerticalBorder;
            }
        }

        private char BattlefieldCrossSymbol
        {
            get
            {
                return Constants.BattlefieldCrossBorder;
            }
        }

        private Position BattlefieldStartingPosition { get; set; }

        private int BattlefieldHeight { get; set; }

        private int BattlefieldWidth { get; set; }

        private void CalculateBattlefieldStartingPosition(IBattlefield battlefield)
        {
            var mediumRow = this.StartingRow + this.Height / 2;
            var battlefieldRow = mediumRow - battlefield.RowsCount;

            var mediumCol = this.StartingCol + this.Width / 2;
            var battlefieldCol = mediumCol - battlefield.ColsCount;

            this.BattlefieldStartingPosition = new Position(battlefieldRow, battlefieldCol);
        }

        protected override int GetMinimumHeight()
        {
            return Constants.BattlefieldSegmentMinHeight;
        }

        protected override int GetMinimumWidth()
        {
            return Constants.BattlefieldSegmentMinWidth;
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public void DrawBattleField(IBattlefield battlefield)
        {
            CalculateBattlefieldStartingPosition(battlefield);
            this.SetConsole(ConsoleSettings.EmptyMatrix);

            this.BattlefieldWidth = battlefield.RowsCount * 2 + 1;
            this.BattlefieldHeight = battlefield.ColsCount * 2 + 1;

            for (int i = 0; i < this.BattlefieldWidth; i++)
            {
                for (int j = 0; j < this.BattlefieldHeight; j++)
                {
                    Console.SetCursorPosition(BattlefieldStartingPosition.Col + j, BattlefieldStartingPosition.Row + i);

                    //Grid row - just draw borders and empty spaces
                    if (i % 2 == 0)
                    {

                        if (j % 2 == 0)
                        {
                            Console.Write(this.BattlefieldCrossSymbol);
                            continue;
                        }

                        Console.Write(this.BattlefieldHorizontalSymbol);
                        continue;
                    }
                    //Data row - draw vertical borders and misses empty spaces
                    else
                    {
                        if (j % 2 == 0)
                        {
                            Console.Write(this.BattlefieldVerticalSymbol);
                        }
                    }
                }
            }
        }

        public void DrawShip(IShip ship)
        {
            Direction direction = GetShipDirection(ship);
            char bow;
            char hull;
            char stern;
            char hit = Constants.HitSymbol;

            switch (direction)
            {
                case Direction.Left:
                    bow = Constants.HorizontalShipRightEnd;
                    hull = Constants.HorizontalShipMiddle;
                    stern = Constants.HorizontalShipLeftEnd;
                    break;

                case Direction.Right:
                    bow = Constants.HorizontalShipLeftEnd;
                    hull = Constants.HorizontalShipMiddle;
                    stern = Constants.HorizontalShipRightEnd;
                    break;

                case Direction.Up:
                    bow = Constants.VerticalShipLowerEnd;
                    hull = Constants.VerticalShipMiddle;
                    stern = Constants.VerticalShipUpperEnd;
                    break;

                case Direction.Down:
                    bow = Constants.VerticalShipUpperEnd;
                    hull = Constants.VerticalShipMiddle;
                    stern = Constants.VerticalShipLowerEnd;
                    break;

                default:
                    throw new ArgumentException("Direction");
            }

            for (int i = 0; i < ship.Elements.Count; i++)
            {
                var elementPosition = CalculateDrawingPosition(ship.Elements[i].ElementPosition);

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

        public void WriteIndexesOnBattlefield()
        {
            this.SetConsole(ConsoleSettings.Text);
            //Letters
            var symbol = 'A';
            for (int i = 0; i < this.BattlefieldWidth; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }

                Console.SetCursorPosition(this.BattlefieldStartingPosition.Col + i, this.BattlefieldStartingPosition.Row + this.BattlefieldHeight);
                Console.Write(symbol);
                symbol++;
            }

            //Numbers
            var count = 1;
            for (int i = 0; i < this.BattlefieldHeight; i++)
            {
                if (i %2 ==0)
                {
                    continue;
                }

                var numberOffset = count < 10 ? 1 : 2;
                Console.SetCursorPosition(this.BattlefieldStartingPosition.Col - numberOffset, this.BattlefieldStartingPosition.Row + i );
                Console.Write(count);
                count++;
            }
        }

        private IPosition CalculateDrawingPosition(IPosition position)
        {
            var row = position.Row;
            var col = position.Col;

            row *= 2;
            row += this.BattlefieldStartingPosition.Row + 1;

            col *= 2;
            col += this.BattlefieldStartingPosition.Col + 1;

            return new Position(row, col);
        }

        private Direction GetShipDirection(IShip ship)
        {
            Direction direction;

            if (ship.Elements[0].ElementPosition.Row == ship.Elements[1].ElementPosition.Row && ship.Elements[0].ElementPosition.Col < ship.Elements[1].ElementPosition.Col)
            {
                direction = Direction.Right;
            }
            else if (ship.Elements[0].ElementPosition.Row == ship.Elements[1].ElementPosition.Row && ship.Elements[0].ElementPosition.Col > ship.Elements[1].ElementPosition.Col)
            {
                direction = Direction.Left;
            }
            else if (ship.Elements[0].ElementPosition.Row < ship.Elements[1].ElementPosition.Row && ship.Elements[0].ElementPosition.Col == ship.Elements[1].ElementPosition.Col)
            {
                direction = Direction.Down;
            }
            else if (ship.Elements[0].ElementPosition.Row > ship.Elements[1].ElementPosition.Row && ship.Elements[0].ElementPosition.Col == ship.Elements[1].ElementPosition.Col)
            {
                direction = Direction.Up;
            }
            else
            {
                throw new ArgumentException("Invalid ship");
            }

            return direction;
        }

    }
}