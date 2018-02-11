using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Enums;
using Battleships.Factory;
using Battleships.Utilities.Contracts;
using System;
using System.Collections.Generic;
using Battleships.Utilities;

namespace Battleships.Commands
{
    public class CreateAircraftCarrierCommand : ICommand
    {
        protected readonly IBattleShipFactory factory;
        protected readonly IEngine engine;

        public CreateAircraftCarrierCommand(IBattleShipFactory factory, IEngine engine)
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
                row = int.Parse(parameters[1]);
                col = parameters[2][0] - 'A';
                direction = (Direction)Enum.Parse(typeof(Direction), parameters[3]);
                pos.Row = row;
                pos.Col = col;
            }
            catch 
            {
                throw new ArgumentException("Invalid parameters");
            }

            var aircraftCarrier = this.factory.CreateAircraftCarrier(pos,direction);
            this.engine.AddShip(aircraftCarrier);
            
            return  $"AircraftCarrier with position {pos} and direction {direction} was created ";
        }
    }
}
