using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
    public interface IParticipant
    {
        IEnumerable<IGameObject> GameObjects { get; set; }

        IGameObject this[int index] { get; set; }
    }
}
