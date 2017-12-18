using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;
using Bytes2you.Validation;

namespace Battleships.Models
{
    public class Battlefield : IBattlefield
    {
        private IGameObjectElement[,] map;

        public Battlefield(IGameObjectElement[,] map)
        {
             Guard.WhenArgument(map, "Battlefield map").IsNull().Throw();
        }

        public IGameObjectElement this[IPosition position]
        {
            get
            {
                return this.Map[position.X, position.Y];
            }
            set
            {
                this.Map[position.X, position.Y] = value;
            }
        }

        public IGameObjectElement[,] Map
        {
            get
            {
                return this.map;
            }
        }
    }
}
