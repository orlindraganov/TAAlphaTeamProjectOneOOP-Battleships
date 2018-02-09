using Battleships.Utilities.Contracts;

namespace Battleships.Models.Contracts
{
    public interface IBattlefield
    {
        IGameObjectElement this[IPosition position] { get; set; }

        IGameObjectElement[,] Map { get; set; }

        int RowsCount { get; }
        int ColsCount { get; }
    }
}