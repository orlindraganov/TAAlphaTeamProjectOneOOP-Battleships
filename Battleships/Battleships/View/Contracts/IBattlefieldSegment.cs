using Battleships.Models.Contracts;

namespace Battleships.View.Contracts
{
    public interface IBattlefieldSegment : IViewSegment
    {
        void SelectPlayer(IPlayer player);
    }
}