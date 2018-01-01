using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Enums;
using Battleships.Factory;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;
using System;
using System.Collections.Generic;

namespace Battleships.Commands
{
    public class CreateDestroyerCommand: ICommand
    {
        private readonly IBattleShipFactory factory;
        private readonly IEngine engine;

        public CreateDestroyerCommand(IBattleShipFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute(IList<string> parameters)
        {
            int row;
            int col;
            Direction direction;
            IPosition pos = new Position();


            try
            {
                row = int.Parse(parameters[0]);
                col = parameters[1][0] - 'A';
                direction = (Direction)Enum.Parse(typeof(Direction), parameters[2]);
                pos.Row = row;
                pos.Col = col;


            }
            catch
            {
                throw new ArgumentException("Invalid parameters");
            }

            var destroyer = this.factory.CreateDestroyer(pos, direction);
            this.engine.AddShip(destroyer);

            return $"Destroyer with position {pos} and direction {direction} was created ";
        }
    }
}
