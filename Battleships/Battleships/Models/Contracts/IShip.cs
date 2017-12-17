namespace Battleships.Models.Contracts
{
    public interface IShip : IGameObject
    {
        bool IsAlive { get; set; }
        int Health { get; set; }
        char SymbolOfShip { get; set; }
    }
}
