using System;
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

        private IPlayer firstPlayer;
        private IPlayer secondPlayer;

        public GameInfoSegment(int startingRow, int height, int startingCol, int width) : base(startingRow, height, startingCol, width)
        {
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

        public IPlayer FirstPlayer
        {
            get
            {
                return this.firstPlayer;
            }
            set
            {
                Guard.WhenArgument(this.firstPlayer, "First player").IsNotNull().Throw();
                Guard.WhenArgument(value, "First player").IsNull().Throw();
                this.firstPlayer = value;
            }
        }

        public IPlayer SecondPlayer
        {
            get
            {
                return this.secondPlayer;
            }
            set
            {
                Guard.WhenArgument(this.secondPlayer, "Second player").IsNotNull().Throw();
                Guard.WhenArgument(value, "Second player").IsNull().Throw();
                this.secondPlayer = value;
            }
        }

        private int PrintedInfoRow { get; set; }

        private int PrintedInfoCol { get; set; }

        private int PrintedInfoLength { get; set; }

        protected override int GetMinimumHeight()
        {
            return ViewSettings.GameInfoSegmentMinHeight;
        }

        protected override int GetMinimumWidth()
        {
            return ViewSettings.GameInfoSegmentMinWidth;
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
            this.GenerateInfo();
            this.WriteInfo();
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

        private void GenerateInfo()
        {
            if (this.FirstPlayer == null || this.SecondPlayer == null)
            {
                this.GameInfo = ViewSettings.GameName;
            }
            else
            {
                this.GameInfo =
                $"{this.FirstPlayer.Name} {this.FirstPlayer.Health} : {this.SecondPlayer.Health} {this.SecondPlayer.Name}";
            }
        }

        private void ClearInfo()
        {
            this.SetConsole(ConsoleSettings.Text);
            Console.SetCursorPosition(this.PrintedInfoCol, this.PrintedInfoRow);

            for (int i = 0; i < this.PrintedInfoLength; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
