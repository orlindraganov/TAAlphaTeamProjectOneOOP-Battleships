using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Battleships.Factory;

namespace Battleships.UnitTests.Factory
{
    public class MockedCommandFactory : CommandFactory
    {
        public MockedCommandFactory(global::Autofac.IComponentContext container) : base(container)
        {
        }
        public IComponentContext Container
        {
            get { return base.container; }
        }
    }
}
