using System;
using System.Collections.Generic;
using Battleships.Models.Contracts;
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
            this.GameInfo = "BATTLESHIPS";
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
                this.gameInfo = value;
            }
        }

        private int PrintedInfoRow { get; set; }

        private int PrintedInfoCol { get; set; }

        private int PrintedInfoLength { get; set; }

        private IPlayer SecondPlayer { get; set; }

        private IPlayer FirstPlayer { get; set; }

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
            return this.StartingCol + (this.Width - this.GameInfo.Length) / 2;
        }

        public override void Update()
        {
            this.ClearInfo();
            this.CalculateResult();
            this.WriteInfo();
        }

        public void SelectParticipants(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            Guard.WhenArgument(firstPlayer, "First Player").IsNull().Throw();
            this.FirstPlayer = firstPlayer;
            
            Guard.WhenArgument(secondPlayer, "Second Player").IsNull().Throw();
            this.SecondPlayer = secondPlayer;
        }

        private void WriteInfo()
        {
            var row = this.CalculateGameInfoRow();
            var col = this.CalculateGameInfoCol();

            this.SetConsole(ConsoleSettings.Text);

            Console.SetCursorPosition(col, row);
            Console.Write(this.GameInfo);

            this.PrintedInfoRow = row;
            this.PrintedInfoCol = col;
            this.PrintedInfoLength = this.GameInfo.Length;
        }

        private void CalculateResult()
        {
            this.GameInfo =
                $"{this.FirstPlayer.Name} {this.FirstPlayer.Health} : {this.SecondPlayer.Health} {this.SecondPlayer.Name}";
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
