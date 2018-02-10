using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.View.Contracts
{
    public interface IBattlefieldSegment : IViewSegment
    {
        IPlayer Player { get; set; }

        void Update(IPosition position);
    }
}