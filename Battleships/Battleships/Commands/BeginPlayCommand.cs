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
    public class BeginPlayCommand : ICommand
    {
        protected readonly IEngine engine;

        public BeginPlayCommand(IBattleShipFactory factory, IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            this.engine.BeginPlay();
            return "Play has begun";
        }
    }
}
