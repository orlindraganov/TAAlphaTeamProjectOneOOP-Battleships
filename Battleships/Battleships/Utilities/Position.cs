using Battleships.Utilities.Contracts;

namespace Battleships.Utilities
{
    public struct Position : IPosition
    {

        public Position(int x, int y) 
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

      
    }
}
