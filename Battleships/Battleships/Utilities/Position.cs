using Battleships.Utilities.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Utilities
{
    public struct Position:IPosition
    {
       
        public Position(int x,int y):this()
        {
           
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public Position GetFromMatrix(char Row,int Col)
        {
            X = (int)Row - 65;
            Y = Col-1;
            var position = new Position(X,Y);
            return position;

        }

    }
}
