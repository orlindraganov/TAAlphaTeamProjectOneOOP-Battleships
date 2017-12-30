using Battleships.Models.Contracts;
using Battleships.View.Contracts;

namespace Battleships.View
{
    public class View : IView
    {
        private IGameInfoSegment GameInfoSegment { get; set; }

        private IPlayerBattlefieldSegment PlayerBattlefieldSegment { get; set; }

        private IEnemyBattlefieldSegment EnemyBattlefieldSegment { get; set; }

        private IInOutSegment InOutSegment { get; set; }

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

        public IPlayer HumanPlayer { get; }
        public IPlayer ComputerPlayer { get; }
        public IParticipant Enviroment { get; }

        public void Update()
        {
            this.GameInfoSegment.Update();
            this.PlayerBattlefieldSegment.Update();
            this.EnemyBattlefieldSegment.Update();
            this.InOutSegment.Update();
        }
    }
}