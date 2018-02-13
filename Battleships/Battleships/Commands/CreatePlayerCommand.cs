using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Factory;
using System;
using System.Collections.Generic;
using Bytes2you.Validation;

namespace Battleships.Commands
{
    public class CreatePlayerCommand : ICommand
    {
        protected readonly IBattleShipFactory factory;
        protected readonly IEngine engine;

        public CreatePlayerCommand(IBattleShipFactory factory, IEngine engine)
        {
            Guard.WhenArgument(factory, "Factory").IsNull().Throw();
            this.factory = factory;

            Guard.WhenArgument(engine, "Engine").IsNull().Throw();
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "Parameters").IsNullOrEmpty().Throw();

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

            foreach (var el in water.Elements)
            {
                battlefield[el.Position] = el;
            }

            var player = this.factory.CreatePlayer(name, water, battlefield);
            this.engine.AddPlayer(player);
            return $"Welcome Player {name}";
        }
    }
}
