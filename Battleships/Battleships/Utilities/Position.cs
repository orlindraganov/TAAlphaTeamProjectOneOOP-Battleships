using Battleships.Utilities.Contracts;

namespace Battleships.Utilities
{
    public class Position : IPosition
    {

        public Position(int x, int y) 
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        //No methods in structs. We'll calculate this in the input parser 
        //or we can tweek the matrix to be [A1] iteratable
        //
        //public Position GetFromMatrix(char row, int col)
        //{
        //    X = row - 65;
        //    Y = col - 1;
        //    var position = new Position(X, Y);
        //    return position;
        //}
    }
}
