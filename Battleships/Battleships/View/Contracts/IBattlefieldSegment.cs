using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.View.Contracts
{
    public interface IBattlefieldSegment : IViewSegment
    {
        void SelectPlayer(IPlayer player);

        void Update(IPosition position);
    }
}