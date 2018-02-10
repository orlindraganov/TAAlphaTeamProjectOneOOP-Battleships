using Battleships.Utilities;
using Battleships.Utilities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.View
{
    public class ViewFactory : IViewFactory
    {
        public IPosition CreatePosition(int row,int col)
        {
            return new Position(row,col);
        }
    }
}
