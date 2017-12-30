using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
    public interface IParticipant
    {
        IList<Element> GameObjects { get; }

        void GetObjectHit(IGameObject hitGameObject);
    }
}
