using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Factory;
using Battleships.Models;
using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IList<Element> gameObjects;

            try
            {
                name = parameters[0].ToString();
                gameObjects = new List<Element>();



            }
            catch
            {

                throw new ArgumentException("Invalid parameters");
            }
            var AircraftCarrier = this.factory.CreatePlayer(name, gameObjects);
            return $"Welcome Player {name}";


        }
    }
}
