using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;
using Bytes2you.Validation;

namespace Battleships.Models
{
    public class Battlefield : IBattlefield
    {
        public const int DefaultWidth = 10;
        public const int DefaultHeight = 10;

        private IGameObjectElement[,] map;

        public Battlefield(IGameObjectElement[,] map)
        {
            this.Map = map;
        }

        public IGameObjectElement this[IPosition position]
        {
            get
            {
                return this.Map[position.Row, position.Col];
            }
            set
            {
                this.Map[position.Row, position.Col] = value;
            }
        }

        public IGameObjectElement[,] Map
        {
            set
            {
                Guard.WhenArgument(value,"Battlefield map").IsNull().Throw();
                this.map = value;
            }
            get
            {
                return this.map;
            }
        }

        public int RowsCount
        {
            get
            {
                return this.Map.GetLength(0);
            }
        }

        public int ColsCount
        {
            get
            {
                return this.Map.GetLength(1);
            }
        }

        public void PlaceShip(IShip ship, IPosition position)
        {
            ship.Elements[0].Position.Row = position.Row;
            ship.Elements[0].Position.Col = position.Col;
            ///Trqbva da se dovurshi za celta trqbva da se napravi View class koito da ima informaciq za simvola na koraba
            ///BattleField trqbva da ima opcii za placevane na ship i proverqvane na cell-a kakvo ima v nego...

        }
        public void GetCell(IPosition position)
        {
            //.......
        }
    }
}
