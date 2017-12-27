using System;
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
        private ViewType type;

        public ViewSegment(int startingRow, int height, int startingCol, int width, ViewType type)
        {




            this.type = type;
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

        public ViewType Type
        {
            get
            {
                return this.type;
            }
            protected set
            {
                Guard.WhenArgument((int)value,"Type").IsLessThan(0).Throw();
                this.type = value;
            }
        }

        protected abstract int GetMinimumHeight();

        protected abstract int GetMinimumWidth();

        public abstract void Update();
    }
}
