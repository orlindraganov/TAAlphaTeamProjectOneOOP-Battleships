using Battleships.Utilities.Contracts;

namespace Battleships.Utilities
{
    public struct Position : IPosition
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}