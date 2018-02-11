using Battleships.Models.Contracts;

namespace Battleships.View.Contracts
{
    public interface IGameInfoSegment : IViewSegment
    {
        IPlayer FirstPlayer { get; set; }
        IPlayer SecondPlayer { get; set; }

        string GameInfo { get; set; }
    }
}