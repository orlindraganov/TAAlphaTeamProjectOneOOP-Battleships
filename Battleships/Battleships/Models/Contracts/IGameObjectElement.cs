using System;
using Battleships.Enums;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;

namespace Battleships.Models.Contracts
{
    public interface IGameObjectElement
    {
        bool IsHit { get; set; }
        IPosition Position { get; }
        GameObjectElementType Type { get; }
        event EventHandler WasHitEvent;

        /// <summary>
        /// Maybe object should send delegate in GetHit()
        /// Maybe also the object owner
        /// </summary>
        void GetHit();
    }
}