using Battleships.View.Enums;

namespace Battleships.View.Contracts
{
    public interface IViewSegment
    {
        int StartingRow { get; }

        int Height { get; }

        int StartingCol { get; }

        int Width { get; }

        void DrawBorders();

        void Update();
    }
}