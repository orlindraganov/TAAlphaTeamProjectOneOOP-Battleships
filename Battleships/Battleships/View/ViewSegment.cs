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
                Guard.WhenArgument(value, "Starting row").IsLessThan(0).IsGreaterThanOrEqual(Console.WindowHeight).Throw();
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
                Guard.WhenArgument(value, "Height").IsLessThan(0).IsGreaterThan(GetMinimumHeight()).Throw();

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

                var lastCol = startingCol + value - 1;
                Guard.WhenArgument(lastCol, "Last col").IsGreaterThan(Console.WindowWidth).Throw();

                this.width = value;
            }
        }

        protected void SetConsole(ConsoleSettings settings)
        {
            switch (settings)
            {
                case ConsoleSettings.Text:
                    Console.BackgroundColor = Constants.ConsoleDefaultBackgroundColor;
                    Console.ForegroundColor = Constants.ConsoleDefaultForegroundColor;
                    return;

                case ConsoleSettings.WaterNotHit:
                    Console.BackgroundColor = Constants.NotHitBackgroundColor;
                    Console.ForegroundColor = Constants.WaterNotHitForegroundColor;
                    return;

                case ConsoleSettings.WaterHit:
                    Console.BackgroundColor = Constants.HitBackgroundColor;
                    Console.ForegroundColor = Constants.WaterHitForegroundColor;
                    return;

                case ConsoleSettings.ShipNotHit:
                    Console.BackgroundColor = Constants.NotHitBackgroundColor;
                    Console.ForegroundColor = Constants.ShipNotHitForegroundColor;
                    return;

                case ConsoleSettings.ShipHit:
                    Console.BackgroundColor = Constants.HitBackgroundColor;
                    Console.ForegroundColor = Constants.ShipHitForegroundColor;
                    return;

                case ConsoleSettings.EmptyMatrix:
                    Console.BackgroundColor = Constants.ConsoleDefaultBackgroundColor;
                    Console.ForegroundColor = Constants.ConsoleDefaultBorderColor;
                    return;
            }
        }

        protected abstract int GetMinimumHeight();

        protected abstract int GetMinimumWidth();

        public abstract void Update();
    }
}
