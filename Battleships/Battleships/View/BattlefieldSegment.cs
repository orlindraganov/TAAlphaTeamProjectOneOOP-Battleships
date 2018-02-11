using System;
using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;
using Bytes2you.Validation;

namespace Battleships.View
{
    public abstract class BattlefieldSegment : ViewSegment, IViewSegment, IBattlefieldSegment
    {
        private IPlayer player;

        protected BattlefieldSegment(int startingRow, int height, int startingCol, int width) : base(startingRow, height, startingCol, width)
        {
            this.IsBattlefieldDrawn = false;
        }

        public IPlayer Player
        {
            get
            {
                return this.player;
            }
            set
            {
                Guard.WhenArgument(this.player, "Player").IsNotNull().Throw();
                Guard.WhenArgument(value, "Player").IsNull().Throw();
                this.player = value;
            }
        }

        private char BattlefieldHorizontalSymbol
        {
            get
            {
                return ViewSettings.BattlefieldHorizontalBorder;
            }
        }

        private char BattlefieldVerticalSymbol
        {
            get
            {
                return ViewSettings.BattlefieldVerticalBorder;
            }
        }

        private char BattlefieldCrossSymbol
        {
            get
            {
                return ViewSettings.BattlefieldCrossBorder;
            }
        }

        private IPosition BattlefieldStartingPosition { get; set; }

        private int BattlefieldHeight { get; set; }

        private int BattlefieldWidth { get; set; }

        private bool IsBattlefieldDrawn { get; set; }

        protected void CalculateBattlefieldStartingPosition(IBattlefield battlefield)
        {
            var mediumRow = this.StartingRow + this.Height / 2;
            var battlefieldRow = mediumRow - battlefield.RowsCount;

            var mediumCol = this.StartingCol + this.Width / 2;
            var battlefieldCol = mediumCol - battlefield.ColsCount;

            this.BattlefieldStartingPosition = new Position(battlefieldRow, battlefieldCol);
        }

        protected override int GetMinimumHeight()
        {
            return ViewSettings.BattlefieldSegmentMinHeight;
        }

        protected override int GetMinimumWidth()
        {
            return ViewSettings.BattlefieldSegmentMinWidth;
        }

        public override void Update()
        {
            if (this.Player == null)
            {
                return;
            }

            if (!IsBattlefieldDrawn)
            {
                this.DrawBattleField();
                this.WriteIndexesOnBattlefield();
                this.DrawWater();
            }
            this.DrawShips();
        }

        public void Update(IPosition position)
        {
            if (this.Player == null)
            {
                return;
            }

            DrawElement(position);
        }

        private void DrawElement(IPosition position)
        {
            var element = this.Player.Battlefield[position];
            char symbol;

            switch (element.Type)
            {
                case GameObjectElementType.Ship:
                    if (element.IsHit)
                    {
                        symbol = ViewSettings.HitSymbol;
                        this.SetConsole(ConsoleSettings.ShipHit);
                    }
                    else
                    {
                        this.DrawShips();
                        return;
                    }
                    break;
                case GameObjectElementType.Water:
                    if (element.IsHit)
                    {
                        symbol = ViewSettings.HitSymbol;
                        this.SetConsole(ConsoleSettings.WaterHit);
                    }
                    else
                    {
                        symbol = ViewSettings.WaterNotHitSymbol;
                        this.SetConsole(ConsoleSettings.WaterNotHit);
                    }
                    break;
                default:
                    throw new ArgumentException("Unknown Element Type");
            }
            var drawingPosition = this.CalculateDrawingPosition(position);
            Console.SetCursorPosition(drawingPosition.Col, drawingPosition.Row);
            Console.Write(symbol);
        }

        private void DrawBattleField()
        {
            var battlefield = this.Player.Battlefield;
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

        private void WriteIndexesOnBattlefield()
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

        private void DrawShips()
        {
            this.DrawShips(this.Player.Ships);
        }

        private void DrawShips(IList<IShip> ships)
        {
            if (ships.Count == 0)
            {
                return;
            }

            foreach (var obj in ships)
            {
                if (obj is IShip ship)
                {
                    this.DrawShip(ship);
                }
            }
        }

        protected abstract void DrawShip(IShip ship);

        private void DrawWater()
        {
            this.DrawWater(this.Player.Water);
        }

        private void DrawWater(IWater water)
        {
            var notHit = ViewSettings.WaterNotHitSymbol;
            var hit = ViewSettings.HitSymbol;

            foreach (var element in water.Elements)
            {
                var elementPosition = CalculateDrawingPosition(element.Position);

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