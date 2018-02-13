using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Factory;
using System;
using System.Collections.Generic;

namespace Battleships.Commands
{
    public class CreatePlayerCommand : ICommand
    {
        protected readonly IBattleShipFactory factory;
        protected readonly IEngine engine;

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
                name = parameters[1];
            }
            catch
            {
                throw new ArgumentException("Invalid parameters");
            }

            var battlefield = this.factory.CreateBattleField();
            var water = this.factory.CreateWater(battlefield.RowsCount, battlefield.ColsCount);
            var player = this.factory.CreatePlayer(name, water, battlefield);
            this.engine.AddPlayer(player);
            return $"Welcome Player {name}";
        }
    }
}
