using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Commands;
using Battleships.Factory;

namespace Battleships.UnitTests.Commands
{
    class FakeBeginPlayCommand : BeginPlayCommand
    {
        public FakeBeginPlayCommand(IBattleShipFactory factory, IEngine engine)
            :base(factory, engine)
        {

        }
        public IEngine Engine { get { return base.engine; } }
    }
}
