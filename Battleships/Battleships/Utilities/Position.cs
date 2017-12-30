using Battleships.Utilities.Contracts;

namespace Battleships.Utilities
{
    public struct Position : IPosition
    {
        public Position(IPosition position)
        {
            this.Row = position.Row;
            this.Col = position.Col;
        }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}