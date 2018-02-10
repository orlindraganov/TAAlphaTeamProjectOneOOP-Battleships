using Autofac;
using Battleships.BattleShipsEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Factory
{
        public class CommandFactory : ICommandFactory
    {
            protected readonly IComponentContext container;

            public CommandFactory(IComponentContext container)
            {
                this.container = container;
            }

            public ICommand Create(string cmdName)
            {
                return this.container.ResolveNamed<ICommand>(cmdName);
            }
    }
    
}
