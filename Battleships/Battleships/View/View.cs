using System;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Bytes2you.Validation;

namespace Battleships.View
{
    public class View : IView
    {
        private IPlayer humanPlayer;

        private IPlayer computerPlayer;

        private readonly IGameInfoSegment gameInfoSegment;

        private readonly IBattlefieldSegment playerBattlefieldSegment;

        private readonly IBattlefieldSegment enemyBattlefieldSegment;

        private readonly IInOutSegment inOutSegment;

        private readonly int width;

        private readonly int height;

        private readonly IPosition startingPosition;

        public View()
        {
            this.width = Constants.ViewDefaultWidth;
            this.height = Constants.ViewDefaultHeight;
            Console.SetWindowSize(Constants.ConsoleDefaultWidth, Constants.ConsoleDefaultHeight);

            this.startingPosition = new Position(Constants.ViewDefaultStartingRow, Constants.ViewDefaultStartingCol);

            var nextSegmentStartingPosition = new Position(this.StartingPosition);

            this.gameInfoSegment = new GameInfoSegment(nextSegmentStartingPosition.Row, Constants.GameInfoSegmentDefaultHeight, nextSegmentStartingPosition.Col, Constants.GameInfoSegmentDefaultWidth);
            nextSegmentStartingPosition.Row += this.GameInfoSegment.Height;

            this.playerBattlefieldSegment = new PlayerBattlefieldSegment(nextSegmentStartingPosition.Row, Constants.BattlefieldSegmentDefaultHeight, nextSegmentStartingPosition.Col, Constants.BattlefieldSegmentDefaultWidth);
            nextSegmentStartingPosition.Col += this.PlayerBattlefieldSegment.Width;

            this.enemyBattlefieldSegment = new EnemyBattlefieldSegment(nextSegmentStartingPosition.Row, Constants.BattlefieldSegmentDefaultHeight, nextSegmentStartingPosition.Col, Constants.BattlefieldSegmentDefaultWidth);
            nextSegmentStartingPosition.Col -= this.EnemyBattlefieldSegment.Width;
            nextSegmentStartingPosition.Row += Math.Max(this.PlayerBattlefieldSegment.Height, this.EnemyBattlefieldSegment.Height);

            this.inOutSegment = new InOutSegment(nextSegmentStartingPosition.Row, Constants.InOutSegmentDefaultHeight, nextSegmentStartingPosition.Col, Constants.InOutSegmentDefaultWidth);
        }

        public View(IPlayer humanPlayer, IPlayer computerPlayer) : this()
        {
            this.HumanPlayer = humanPlayer;
            this.ComputerPlayer = computerPlayer;

            this.GameInfoSegment.SelectParticipants(humanPlayer, computerPlayer);
            this.PlayerBattlefieldSegment.SelectPlayer(humanPlayer);
            this.EnemyBattlefieldSegment.SelectPlayer(computerPlayer);
        }

        public IPlayer HumanPlayer
        {
            get
            {
                return this.humanPlayer;
            }
            set
            {
                Guard.WhenArgument(value, "Human player").IsNull().Throw();
                this.PlayerBattlefieldSegment.SelectPlayer(value);
                this.humanPlayer = value;
            }
        }

        public IPlayer ComputerPlayer
        {
            get
            {
                return this.computerPlayer;
            }
            set
            {
                Guard.WhenArgument(value, "Computer player").IsNull().Throw();
                this.EnemyBattlefieldSegment.SelectPlayer(value);
                this.computerPlayer = value;
            }
        }


        private int Width => this.width;

        private int Height => this.height;

        private IGameInfoSegment GameInfoSegment => this.gameInfoSegment;

        private IBattlefieldSegment PlayerBattlefieldSegment => this.playerBattlefieldSegment;

        private IBattlefieldSegment EnemyBattlefieldSegment => this.enemyBattlefieldSegment;

        private IInOutSegment InOutSegment => this.inOutSegment;

        private IPosition StartingPosition => this.startingPosition;

        public string ReadLine()
        {
            return this.InOutSegment.ReadLine();
        }

        public void Write(string message)
        {
            this.InOutSegment.Write(message);
        }

        public void WriteLine(string message)
        {
            this.InOutSegment.WriteLine(message);
        }


        public void Update()
        {
            this.GameInfoSegment.Update();
            this.PlayerBattlefieldSegment.Update();
            this.EnemyBattlefieldSegment.Update();
            this.InOutSegment.Update();
        }
    }
}