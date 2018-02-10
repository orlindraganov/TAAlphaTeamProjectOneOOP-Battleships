using Battleships.Models.Contracts;

namespace Battleships.View.Contracts
{
    public interface IGameInfoSegment : IViewSegment
    {
        string GameInfo { get; set; }
    }
}