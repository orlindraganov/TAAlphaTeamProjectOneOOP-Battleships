using Battleships.Enums;
using Battleships.Utilities.Contracts;

namespace Battleships.Models.Contracts
{
    public interface IGameObjectElement
    {
        bool IsHit { get; set; }
        IPosition Position { get; set; }
        GameObjectElementType Type { get; }

        /// <summary>
        /// Maybe object should send delegate in GetHit()
        /// Maybe also the object owner
        /// </summary>
        void GetHit();
    }
}
