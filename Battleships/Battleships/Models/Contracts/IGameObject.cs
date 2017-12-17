using System.Collections.Generic;

namespace Battleships.Models.Contracts
{
    public interface IGameObject
    {
        IEnumerable<IGameObjectElement> Elements { get; set; }

        IGameObjectElement this[int index] { get; set; }

        /// <summary>
        /// Delegate should be sent in the Elements to know when element is hit
        /// </summary>
        void GetElementHit(IGameObjectElement hitGameObjectElement);
    }
}
