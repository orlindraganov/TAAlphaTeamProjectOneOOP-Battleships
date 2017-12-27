using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
    public interface IParticipant
    {
        IEnumerable<IGameObject> GameObjects { get; }

        void GetObjectHit(IGameObject hitGameObject);
    }
}
