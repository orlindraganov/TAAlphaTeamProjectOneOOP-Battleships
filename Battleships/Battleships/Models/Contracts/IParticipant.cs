using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
    public interface IParticipant
    {
        IEnumerable<IGameObject> GameObjects { get; set; }

        void GetObjectHit(IGameObject hitGameObject);
    }
}
