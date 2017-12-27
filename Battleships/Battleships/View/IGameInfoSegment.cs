using Battleships.View.Contracts;

namespace Battleships.View
{
    public interface IGameInfoSegment : IViewSegment
    {
        string GameInfo { get; set; }
    }
}