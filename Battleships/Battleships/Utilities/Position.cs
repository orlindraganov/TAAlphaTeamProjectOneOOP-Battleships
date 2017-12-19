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
<<<<<<< HEAD
=======

      
>>>>>>> 0fc0c61f4577d5a143887c1649b7baf129f091e6
    }
}