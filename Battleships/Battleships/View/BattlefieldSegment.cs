using System;
using Battleships.Models.Contracts;
using Battleships.Utilities;
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

        private void CalculateStartingPosition(IBattlefield battlefield)
        {
            var mediumRow = this.StartingRow + this.Height / 2;
            var battlefieldRow = mediumRow - battlefield.RowsCount;

            var mediumCol = this.StartingCol + this.Width / 2;
            var battlefieldCol = mediumCol - battlefield.ColsCount;

            BattlefieldStartingPosition = new Position(battlefieldRow, battlefieldCol);
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

        private void DrawBattleField(IBattlefield battlefield)
        {
            //TODO

            CalculateStartingPosition(battlefield);
            SetConsole(ConsoleSettings.EmptyMatrix);

            var drawingRows = battlefield.RowsCount * 2 + 2;
            var drawingCols = battlefield.ColsCount * 2 + 2;

            for (int i = 0; i < drawingRows; i++)
            {
                for (int j = 0; j < drawingCols; j++)
                {
                    //Last row - mark letters
                    if (i == drawingRows - 1)
                    {
                        while (j < 2)
                        {
                            j++;
                        }

                        if (j % 2 == 0)
                        {
                            SetConsole(ConsoleSettings.Text);
                            Console.SetCursorPosition(BattlefieldStartingPosition.Col + j, BattlefieldStartingPosition.Row + i);
                            Console.Write((char)(62 + j / 2));
                            continue;
                        }
                    }

                    //Grid row - just draw border
                    if (i % 2 == 0)
                    {
                        if (j == 0)
                        {
                            continue;
                        }

                        SetConsole(ConsoleSettings.EmptyMatrix);
                        Console.SetCursorPosition(BattlefieldStartingPosition.Col + j, BattlefieldStartingPosition.Row + i);

                        if (j % 2 != 0)
                        {
                            Console.Write(this.BattlefieldCrossSymbol);
                            continue;
                        }

                        Console.Write(this.BattlefieldHorizontalSymbol);
                        continue;
                    }
                    //Data row - draw vertical borders and empty spaces
                    else
                    {
                        SetConsole(ConsoleSettings.EmptyMatrix);
                        Console.SetCursorPosition(BattlefieldStartingPosition.Col + j, BattlefieldStartingPosition.Row + i);

                        if (j == 0)
                        {
                            Console.Write(i / 2 + 1);
                            continue;
                        }

                        if (j % 2 != 0)
                        {
                            Console.Write(this.BattlefieldVerticalSymbol);
                        }
                    }
                }
            }
        }

        private void DrawShip(IShip ship)
        {
            bool isHorizontal;
            char bow;
            char hull;
            char stern;
            char hit = Constants.HitSymbol;

            if (ship.Elements[0].ElementPosition.Row == ship.Elements[1].ElementPosition.Row)
            {
                isHorizontal = true;
                bow = Constants.HorizontalShipLeftEnd;
                hull = Constants.HorizontalShipMiddle;
                stern = Constants.HorizontalShipRightEnd;

                for (int i = 0; i < ship.Elements.Count; i++)
                {
                    if (ship.Elements[i].IsHit)
                    {
                        SetConsole(ConsoleSettings.ShipHit);
                        //TODO
                    }
                }
            }
            else if (ship.Elements[0].ElementPosition.Col == ship.Elements[1].ElementPosition.Col)
            {
                isHorizontal = false;
                bow = Constants.VerticalShipUpperEnd;
                hull = Constants.VerticalShipMiddle;
                stern = Constants.VerticalShipLowerEnd;
                //TODO
            }
            else
            {
                throw new ArgumentException("Invalid ship");
            }
        }

        private void DrawElement();
    }
}