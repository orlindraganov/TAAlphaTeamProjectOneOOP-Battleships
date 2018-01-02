using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
    public interface IGameObject
    {
        IList<IGameObjectElement> Elements { get; set; }
    }
}
