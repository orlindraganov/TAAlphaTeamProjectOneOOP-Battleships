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

            try
            {
                name = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Invalid parameters");
            }

            var player = this.factory.CreatePlayer(name);
            this.engine.AddPlayer(player);
            return $"Welcome Player {name}";
        }
    }
}
