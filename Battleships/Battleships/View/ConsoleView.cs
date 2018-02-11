using System;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Bytes2you.Validation;

namespace Battleships.View
{
    public class ConsoleView : IView, IInput, IOutput
    {
        private IPlayer firstPlayer;

        private IPlayer secondPlayer;

        private readonly IGameInfoSegment gameInfoSegment;

        private readonly IBattlefieldSegment playerBattlefieldSegment;

        private readonly IBattlefieldSegment enemyBattlefieldSegment;

        private readonly IInOutSegment inOutSegment;

        public ConsoleView(IGameInfoSegment gameInfoSegment, IBattlefieldSegment playerBattlefieldSegment, IBattlefieldSegment enemyBattlefieldSegment, IInOutSegment inOutSegment)
        {
            Guard.WhenArgument(gameInfoSegment, "Game Info Segment").IsNull().Throw();
            this.gameInfoSegment = gameInfoSegment;

            Guard.WhenArgument(playerBattlefieldSegment, "Player Battlefield Segment").IsNull().Throw();
            this.playerBattlefieldSegment = playerBattlefieldSegment;

            Guard.WhenArgument(enemyBattlefieldSegment, "Enemy Battlefield Segment").IsNull().Throw();
            this.enemyBattlefieldSegment = enemyBattlefieldSegment;

            Guard.WhenArgument(inOutSegment, "In Out Segment").IsNull().Throw();
            this.inOutSegment = inOutSegment;
        }

        public IPlayer FirstPlayer
        {
            get
            {
                return this.firstPlayer;
            }
            set
            {
                Guard.WhenArgument(this.FirstPlayer, "Human player").IsNotNull().Throw();
                Guard.WhenArgument(value, "Human player").IsNull().Throw();
                this.GameInfoSegment.FirstPlayer = value;
                this.PlayerBattlefieldSegment.Player = value;
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
                Guard.WhenArgument(this.SecondPlayer, "Computer player").IsNotNull().Throw();
                Guard.WhenArgument(value, "Computer player").IsNull().Throw();
                this.GameInfoSegment.SecondPlayer = value;
                this.EnemyBattlefieldSegment.Player = value;
                this.secondPlayer = value;
            }
        }

        private IGameInfoSegment GameInfoSegment => this.gameInfoSegment;

        private IBattlefieldSegment PlayerBattlefieldSegment => this.playerBattlefieldSegment;

        private IBattlefieldSegment EnemyBattlefieldSegment => this.enemyBattlefieldSegment;

        private IInOutSegment InOutSegment => this.inOutSegment;

        public string ReadLine()
        {
            return this.InOutSegment.ReadLine();
        }

        public void WriteLine(string message)
        {
            this.InOutSegment.WriteLine(message);
        }

        public void DrawBorders()
        {
            this.GameInfoSegment.DrawBorders();
            this.PlayerBattlefieldSegment.DrawBorders();
            this.EnemyBattlefieldSegment.DrawBorders();
            this.InOutSegment.DrawBorders();
        }

        public void Update()
        {
            this.GameInfoSegment.Update();
            this.PlayerBattlefieldSegment.Update();
            this.EnemyBattlefieldSegment.Update();
            this.InOutSegment.Update();
        }

        public void Update(IPosition position)
        {
            this.GameInfoSegment.Update();
            this.PlayerBattlefieldSegment.Update(position);
            this.EnemyBattlefieldSegment.Update(position);
            this.InOutSegment.Update();
        }
    }
}