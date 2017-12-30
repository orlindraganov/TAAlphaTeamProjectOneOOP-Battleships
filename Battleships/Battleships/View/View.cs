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
        private readonly IPlayer humanPlayer;

        private readonly IPlayer computerPlayer;

        private readonly IParticipant enviroment;

        private readonly IGameInfoSegment gameInfoSegment;

        private readonly IPlayerBattlefieldSegment playerBattlefieldSegment;

        private readonly IEnemyBattlefieldSegment enemyBattlefieldSegment;

        private readonly IInOutSegment inOutSegment;

        private readonly int width;

        private readonly int height;

        private readonly IPosition startingPosition;

        public View(IPlayer humanPlayer, IPlayer computerPlayer, IParticipant enviroment)
        {
            Guard.WhenArgument(humanPlayer, "Human player").IsNull().Throw();
            this.humanPlayer = humanPlayer;

            Guard.WhenArgument(computerPlayer, "Computer player").IsNull().Throw();
            this.computerPlayer = computerPlayer;

            Guard.WhenArgument(enviroment, "Enviroment").IsNull().Throw();
            this.enviroment = enviroment;

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
            nextSegmentStartingPosition.Row += Math.Max(this.PlayerBattlefieldSegment.Height,this.EnemyBattlefieldSegment.Height);
            this.inOutSegment = new InOutSegment(nextSegmentStartingPosition.Row, Constants.InOutSegmentDefaultHeight, nextSegmentStartingPosition.Col, Constants.InOutSegmentDefaultWidth);
        }

        public IPlayer HumanPlayer => this.humanPlayer;

        public IPlayer ComputerPlayer => this.computerPlayer;

        public IParticipant Enviroment => this.enviroment;

        private int Width => this.width;

        private int Height => this.height;

        private IGameInfoSegment GameInfoSegment => this.gameInfoSegment;

        private IPlayerBattlefieldSegment PlayerBattlefieldSegment => this.playerBattlefieldSegment;

        private IEnemyBattlefieldSegment EnemyBattlefieldSegment => this.enemyBattlefieldSegment;

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