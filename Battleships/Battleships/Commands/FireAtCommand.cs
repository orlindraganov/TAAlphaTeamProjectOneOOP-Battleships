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
        private readonly IEngine engine;

        public FireAtCommand(IBattleShipFactory factory, IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            return this.engine.FireAt(int.Parse(parameters[0]), parameters[1][0] - 'A');
             
        }
    }
}

