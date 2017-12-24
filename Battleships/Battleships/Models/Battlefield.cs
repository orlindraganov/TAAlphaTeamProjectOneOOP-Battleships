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
        public void PlaceShip(IShip ship, IPosition position)
        {
            ship.Elements[0].ElementPosition.X = position.X;
            ship.Elements[0].ElementPosition.Y = position.Y;
            ///Trqbva da se dovurshi za celta trqbva da se napravi View class koito da ima informaciq za simvola na koraba
            ///BattleField trqbva da ima opcii za placevane na ship i proverqvane na cell-a kakvo ima v nego...

        }
        public void GetCell(IPosition position)
        {
            //.......
        }
    }
}
