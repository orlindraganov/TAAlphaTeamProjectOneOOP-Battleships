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
    public class CreateBattleCruiserCommand:ICommand
    {
 
            private readonly IBattleShipFactory factory;
            private readonly IEngine engine;

            public CreateBattleCruiserCommand(IBattleShipFactory factory, IEngine engine)
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
                    col = int.Parse(parameters[1]);
                    direction = (Direction)Enum.Parse(typeof(Direction), parameters[2]);
                    pos.Row = row;
                    pos.Col = col;


                }
                catch 
                {

                throw new ArgumentException("Invalid parameters");
                }
                var BattleCruiser = this.factory.CreateAircraftCarrier(pos, direction);
            this.engine.Ships.Add(BattleCruiser);

            return $"BattleCruiser with position {pos} and direction {direction} was created ";
            }

        
    }

}

