using System;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;
using Bytes2you.Validation;

namespace Battleships.View
{
    public abstract class ViewSegment : IViewSegment
    {
        private int startingRow;
        private int height;
        private int startingCol;
        private int width;

        public ViewSegment(int startingRow, int height, int startingCol, int width)
        {
            this.StartingRow = startingRow;
            this.Height = height;
            this.StartingCol = startingCol;
            this.Width = width;
        }

        public int StartingRow
        {
            get
            {
                return this.startingRow;
            }
            protected set
            {
                Guard.WhenArgument(value, "Starting row").IsLessThan(0).IsGreaterThan(Console.WindowHeight).Throw();
                this.startingRow = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                Guard.WhenArgument(value, "Height").IsLessThan(0).IsLessThan(this.GetMinimumHeight()).IsGreaterThan(Console.WindowHeight).Throw();

                var lastRow = startingRow + value - 1;
                Guard.WhenArgument(lastRow, "Last row").IsGreaterThan(Console.WindowHeight).Throw();

                this.height = value;
            }
        }

        public int StartingCol
        {
            get
            {
                return this.startingCol;
            }
            set
            {
                Guard.WhenArgument(value, "Starting col").IsLessThan(0).IsGreaterThanOrEqual(Console.WindowWidth).Throw();
                this.startingCol = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                Guard.WhenArgument(value, "Width").IsLessThan(0).Throw();
                Guard.WhenArgument(value, "Width").IsLessThan(this.GetMinimumWidth());

                var lastCol = startingCol + value - 1;
                Guard.WhenArgument(lastCol, "Last col").IsGreaterThan(Console.WindowWidth).Throw();

                this.width = value;
            }
        }

        public void DrawBorders()
        {
            this.SetConsole(ConsoleSettings.Text);
            this.DrawHorizontalLine(this.StartingRow, this.StartingCol, this.Width, ViewSettings.SegmentBorder);
            this.DrawVerticalLine(this.StartingCol, this.StartingRow, this.Height, ViewSettings.SegmentBorder);
            this.DrawVerticalLine(this.StartingCol + this.Width - 1, this.StartingRow, this.Height, ViewSettings.SegmentBorder);
            this.DrawHorizontalLine(this.StartingRow + this.Height - 1, this.StartingCol, this.Width, ViewSettings.SegmentBorder);
        }

        protected void SetConsole(ConsoleSettings settings)
        {
            switch (settings)
            {
                case ConsoleSettings.Text:
                    Console.BackgroundColor = ViewSettings.ConsoleDefaultBackgroundColor;
                    Console.ForegroundColor = ViewSettings.ConsoleDefaultForegroundColor;
                    return;

                case ConsoleSettings.WaterNotHit:
                    Console.BackgroundColor = ViewSettings.NotHitBackgroundColor;
                    Console.ForegroundColor = ViewSettings.WaterNotHitForegroundColor;
                    return;

                case ConsoleSettings.WaterHit:
                    Console.BackgroundColor = ViewSettings.HitBackgroundColor;
                    Console.ForegroundColor = ViewSettings.WaterHitForegroundColor;
                    return;

                case ConsoleSettings.ShipNotHit:
                    Console.BackgroundColor = ViewSettings.NotHitBackgroundColor;
                    Console.ForegroundColor = ViewSettings.ShipNotHitForegroundColor;
                    return;

                case ConsoleSettings.ShipHit:
                    Console.BackgroundColor = ViewSettings.HitBackgroundColor;
                    Console.ForegroundColor = ViewSettings.ShipHitForegroundColor;
                    return;

                case ConsoleSettings.EmptyMatrix:
                    Console.BackgroundColor = ViewSettings.ConsoleDefaultBorderBackgroundColor;
                    Console.ForegroundColor = ViewSettings.ConsoleDefaultBorderColor;
                    return;
            }
        }

        protected void DrawHorizontalLine(int row, int startingCol, int length, char symbol)
        {
            for (int i = 0; i < length; i++)
            {
                var currentCol = startingCol + i;
                Console.SetCursorPosition(currentCol, row);
                Console.Write(symbol);
            }
        }

        protected void DrawVerticalLine(int col, int startingRow, int length, char symbol)
        {
            for (int i = 0; i < length; i++)
            {
                var currentRow = startingRow + i;
                Console.SetCursorPosition(col, currentRow);
                Console.Write(symbol);
            }
        }

        protected abstract int GetMinimumHeight();

        protected abstract int GetMinimumWidth();

        public abstract void Update();
    }
}
