using System;
using System.Collections.Generic;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;
using Bytes2you.Validation;

namespace Battleships.View
{
    public class GameInfoSegment : ViewSegment, IViewSegment, IGameInfoSegment
    {
        private string gameInfo;

        public GameInfoSegment(int startingRow, int height, int startingCol, int width) : base(startingRow, height, startingCol, width)
        {
            this.SetConsole(ConsoleSettings.Text);
            this.DrawHorizontalLine(startingRow, startingCol, width, Constants.SegmentBorder);
            this.DrawVerticalLine(startingCol, startingRow, height, Constants.SegmentBorder);
            this.DrawVerticalLine(startingCol + width - 1, startingRow, height, Constants.SegmentBorder);
            this.DrawHorizontalLine(startingRow + height - 1, startingCol, width, Constants.SegmentBorder);
        }

        public string GameInfo
        {
            get
            {
                return this.gameInfo;
            }
            set
            {
                Guard.WhenArgument(value, "Game Info").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Game Info Length").IsGreaterThanOrEqual(this.Width - 2).Throw();
                this.GameInfo = value;
            }
        }

        private int PrintedInfoRow { get; set; }
        private int PrintedInfoCol { get; set; }
        private int PrintedInfoLength { get; set; }

        private void DrawHorizontalLine(int row, int startingCol, int length, char symbol)
        {
            for (int i = 0; i < length; i++)
            {
                var currentCol = startingCol + i;
                Console.SetCursorPosition(currentCol, row);
                Console.Write(symbol);
            }
        }

        private void DrawVerticalLine(int col, int startingRow, int length, char symbol)
        {
            for (int i = 0; i < length; i++)
            {
                var currentRow = startingRow + i;
                Console.SetCursorPosition(col, currentRow);
                Console.Write(symbol);
            }
        }

        protected override int GetMinimumHeight()
        {
            return Constants.GameInfoSegmentMinHeight;
        }

        protected override int GetMinimumWidth()
        {
            return Constants.GameInfoSegmentMinWidth;
        }

        public int CalculateGameInfoRow()
        {
            return this.StartingRow + this.Height / 2;
        }

        public int CalculateGameInfoCol()
        {
            return (this.StartingCol + this.Width - this.GameInfo.Length) / 2;
        }

        public override void Update()
        {
            this.SetConsole(ConsoleSettings.Text);
            this.ClearInfo();
            this.WriteInfo();
        }

        private void WriteInfo()
        {
            var row = this.CalculateGameInfoRow();
            var col = this.CalculateGameInfoCol();

            Console.SetCursorPosition(col, row);
            Console.Write(this.GameInfo);

            this.PrintedInfoRow = row;
            this.PrintedInfoCol = col;
            this.PrintedInfoLength = this.GameInfo.Length;
        }

        private void ClearInfo()
        {

            for (int i = 0; i < this.PrintedInfoLength; i++)
            {
                Console.SetCursorPosition(this.PrintedInfoCol + i, this.PrintedInfoRow);
                Console.Write(string.Empty);
            }
        }
    }
}
