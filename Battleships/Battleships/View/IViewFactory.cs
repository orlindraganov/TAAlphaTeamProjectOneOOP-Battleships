using Battleships.Utilities.Contracts;

namespace Battleships.View
{
    public interface IViewFactory
    {
        IPosition CreatePosition(int row, int col);
    }
}