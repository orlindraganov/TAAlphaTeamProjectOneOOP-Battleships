using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
    public interface IGameObject
    {
        IEnumerable<IGameObjectElement> Elements { get; set; }

        IGameObjectElement this[int index] { get; set; }
    }
}
