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
    public abstract class BattlefieldSegment : ViewSegment, IViewSegment
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
                if (i % 2 == 0)
                {
                    continue;
                }

                var numberOffset = count < 10 ? 1 : 2;
                Console.SetCursorPosition(this.BattlefieldStartingPosition.Col - numberOffset, this.BattlefieldStartingPosition.Row + i);
                Console.Write(count);
                count++;
            }
        }

        public abstract void DrawShip(IShip ship);

        public void DrawWater(IWater water)
        {
            var notHit = Constants.WaterNotHitSymbol;
            var hit = Constants.HitSymbol;

            foreach (var element in water.Elements)
            {
                var elementPosition = CalculateDrawingPosition(element.ElementPosition);

                Console.SetCursorPosition(elementPosition.Col, elementPosition.Row);

                char symbol;

                if (element.IsHit)
                {
                    this.SetConsole(ConsoleSettings.WaterHit);
                    symbol = hit;
                }
                else
                {
                    this.SetConsole(ConsoleSettings.WaterNotHit);
                    symbol = notHit;
                }

                Console.Write(symbol);
            }
        }

        protected IPosition CalculateDrawingPosition(IPosition position)
        {
            var row = position.Row;
            var col = position.Col;

            row *= 2;
            row += this.BattlefieldStartingPosition.Row + 1;

            col *= 2;
            col += this.BattlefieldStartingPosition.Col + 1;

            return new Position(row, col);
        }

    }
}