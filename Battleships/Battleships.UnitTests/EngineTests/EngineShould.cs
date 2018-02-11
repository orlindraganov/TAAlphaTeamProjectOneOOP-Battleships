using Battleships.BattleshipsEngine;
using Battleships.BattleshipsEngine.Providers;
using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Factory;
using Battleships.View.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.UnitTests.EngineTests
{
    [TestClass]
    public class EngineShould
    {
        [TestMethod]
        public void StartsAtleastOnce()
        {

            var engineMOck = new Mock<IEngine>();
            engineMOck.Setup(x => x.Start()).Verifiable();
            engineMOck.Object.Start();

            engineMOck.Verify(x => x.Start(), Times.AtLeastOnce);

        }
 
    }
}
