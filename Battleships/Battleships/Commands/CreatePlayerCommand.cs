using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Factory;
using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Battleships.Commands
{
    public class CreatePlayerCommand : ICommand
    {
        private readonly IBattleShipFactory factory;
        private readonly IEngine engine;

        public CreatePlayerCommand(IBattleShipFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute(IList<string> parameters)
        {
            string name;
            IList<IShip> ships;

            try
            {
                name = parameters[0].ToString();
                ships = new List<IShip>();



            }
            catch
            {

                throw new ArgumentException("Invalid parameters");
            }
            var AircraftCarrier = this.factory.CreatePlayer(name, ships);
            return $"Welcome Player {name}";


        }
    }
}
