using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;
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

        private readonly int width;

        private readonly int height;

        private readonly IPosition startingPosition;

        public ConsoleView(IGameInfoSegment gameInfoSegment, IBattlefieldSegment playerBattlefieldSegment, IBattlefieldSegment enemyBattlefieldSegment, IInOutSegment inOutSegment, int width, int height)
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
                this.EnemyBattlefieldSegment.Player = value;
                this.secondPlayer = value;
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

        public void Update(IPosition position)
        {
            this.GameInfoSegment.Update();
            this.PlayerBattlefieldSegment.Update(position);
            this.EnemyBattlefieldSegment.Update(position);
            this.InOutSegment.Update();
        }
    }
}