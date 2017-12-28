using Battleships.Enums;

namespace Battleships.Models.Contracts
{
    public interface IShip : IGameObject
    {
        bool IsAlive { get; }
        int Health { get; set; }
    }
}
