using System;
using Battleships.Enums;
using Battleships.Utilities.Contracts;

namespace Battleships.Models.Contracts
{
    public interface IGameObjectElement
    {
        bool IsHit { get; set; }
        IPosition Position { get; }
        GameObjectElementType Type { get; }
        event EventHandler WasHitEvent;

        void GetHit();
    }
}