using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Factory;

namespace Battleships.Commands
{
    public class FireAtCommand : ICommand
    {
        protected readonly IEngine engine;

        public FireAtCommand(IBattleShipFactory factory, IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            return this.engine.FireAt(int.Parse(parameters[1]) - 1, parameters[2][0] - 'A');
        }
    }
}

