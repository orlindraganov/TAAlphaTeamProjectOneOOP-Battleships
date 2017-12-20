using Battleships.Enums;

namespace Battleships.Models.Contracts
{
    public interface IShip : IGameObject
    {
        bool IsAlive { get; set; }
        int Health { get; set; }
        ShipType ShipType { get; set; }
    }
}
