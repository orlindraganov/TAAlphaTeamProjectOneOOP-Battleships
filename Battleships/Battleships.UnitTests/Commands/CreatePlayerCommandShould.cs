using System;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Commands;
using Battleships.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Battleships.BattleShipsEngine;

namespace Battleships.UnitTests.Commands
{
    [TestClass]
    public class CreatePlayerCommandShould
    {
        [TestMethod]
        public void SetTheFieldFactory()
        {
            //Arrange
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var mockFactory = new FakeCreatePlayerCommand(fakeFactory.Object, fakeEngine.Object);
            //Act & Assert
            Assert.AreSame(fakeFactory.Object, mockFactory.Factory);

        }

        [TestMethod]
        public void SetTheFieldEngine()
        {
            //Arrange
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var mockFactory = new FakeCreatePlayerCommand(fakeFactory.Object, fakeEngine.Object);
            //Act & Assert
            Assert.AreSame(fakeEngine.Object, mockFactory.Engine);

        }
        [TestMethod]
        public void IsAnInstanceOfICommand()
        {
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var mockFactory = new FakeCreatePlayerCommand(fakeFactory.Object, fakeEngine.Object);
            Assert.IsInstanceOfType(mockFactory, typeof(ICommand));

        }

      
    }
}
