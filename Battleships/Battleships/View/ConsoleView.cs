using System;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Bytes2you.Validation;

namespace Battleships.View
{
    public class ConsoleView : IView
    {
        private IPlayer firstPlayer;

        private IPlayer secondPlayer;

        private readonly IGameInfoSegment gameInfoSegment;

        private readonly IBattlefieldSegment playerBattlefieldSegment;

        private readonly IBattlefieldSegment enemyBattlefieldSegment;

        private readonly IInOutSegment inOutSegment;

        private readonly int width;

        private readonly int height;

        private readonly IPosition startingPosition;
        private IViewFactory factory;

        public ConsoleView(IViewFactory factory)
        {
            this.factory = factory;
            this.width = Constants.ViewDefaultWidth;
            this.height = Constants.ViewDefaultHeight;
            Console.SetWindowSize(Constants.ConsoleDefaultWidth, Constants.ConsoleDefaultHeight);
            Console.SetBufferSize(Constants.ConsoleDefaultWidth, Constants.ConsoleDefaultHeight);
            
            this.startingPosition = factory.CreatePosition(Constants.ViewDefaultStartingRow, Constants.ViewDefaultStartingCol);

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

        public ConsoleView(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            this.FirstPlayer = firstPlayer;
            this.SecondPlayer = secondPlayer;

            this.GameInfoSegment.SelectParticipants(firstPlayer, secondPlayer);
            this.PlayerBattlefieldSegment.SelectPlayer(firstPlayer);
            this.EnemyBattlefieldSegment.SelectPlayer(secondPlayer);
        }

        private int Width => this.width;

        private int Height => this.height;

        private IGameInfoSegment GameInfoSegment => this.gameInfoSegment;

        private IBattlefieldSegment PlayerBattlefieldSegment => this.playerBattlefieldSegment;

        private IBattlefieldSegment EnemyBattlefieldSegment => this.enemyBattlefieldSegment;

        private IInOutSegment InOutSegment => this.inOutSegment;

        private IPosition StartingPosition => this.startingPosition;

        public IPlayer FirstPlayer
        {
            get
            {
                return this.firstPlayer;
            }
            set
            {
                Guard.WhenArgument(value, "Human player").IsNull().Throw();
                this.PlayerBattlefieldSegment.SelectPlayer(value);
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
                Guard.WhenArgument(value, "Computer player").IsNull().Throw();
                this.EnemyBattlefieldSegment.SelectPlayer(value);
                this.secondPlayer = value;
            }
        }


        public string ReadLine()
        {
            return this.InOutSegment.ReadLine();
        }

        public void WriteLine(string message)
        {
            this.InOutSegment.WriteLine(message);
        }
        
        public void Update()
        {
            this.GameInfoSegment.Update();

            if (this.FirstPlayer != null)
            {
                this.PlayerBattlefieldSegment.Update();
            }
            if (this.SecondPlayer != null)
            {
                this.EnemyBattlefieldSegment.Update();
            }

            this.InOutSegment.Update();
        }

        public void Update(IPosition position)
        {
            this.GameInfoSegment.Update();
            this.PlayerBattlefieldSegment.Update(position);
            this.EnemyBattlefieldSegment.Update(position);
            this.InOutSegment.ClearLastReadMessage();
            this.InOutSegment.Update();
        }

        public void SelectParticipants(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            Guard.WhenArgument(firstPlayer, "First Player").IsNull().Throw();
            this.FirstPlayer = firstPlayer;

            Guard.WhenArgument(secondPlayer, "Second Player").IsNull().Throw();
            this.SecondPlayer = secondPlayer;

            this.GameInfoSegment.SelectParticipants(firstPlayer, secondPlayer);
        }
    }
}