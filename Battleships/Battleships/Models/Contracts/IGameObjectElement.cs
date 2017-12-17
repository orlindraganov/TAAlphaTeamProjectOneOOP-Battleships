using Battleships.Utilities.Contracts;

namespace Battleships.Models.Contracts
{
    public interface IGameObjectElement
    {
        bool IsHit { get; set; }
        IPosition Position { get; set; }

        void GetHit();
    }
}
