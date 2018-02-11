using System;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Commands;
using Battleships.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Battleships.BattleShipsEngine;
using System.Collections.Generic;

namespace Battleships.UnitTests.Commands
{
    [TestClass]
    public class CreateFireAtCommandShould
    {
        [TestMethod]
        public void SetTheFieldEngine()
        {
            //Arrange
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var mockFactory = new FakeCreateFireAtCommand(fakeFactory.Object, fakeEngine.Object);
            //Act & Assert
            Assert.AreSame(fakeEngine.Object, mockFactory.Engine);

        }
        [TestMethod]
        public void IsAnInstanceOfICommand()
        {
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var mockFactory = new FakeCreateFireAtCommand(fakeFactory.Object, fakeEngine.Object);
            Assert.IsInstanceOfType(mockFactory, typeof(ICommand));

        }
    
    }
}
