using System;
using System.Collections.Generic;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Battleships.BattleShipsEngine;
using Battleships.Commands;
using Battleships.Models.Contracts;

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

        [TestMethod]
        public void ShouldThrowArgumentNullExceptionWhenFactoryNull()
        {
            var engineStub = new Mock<IEngine>().Object;

            Assert.ThrowsException<ArgumentNullException>(() => new CreatePlayerCommand(null, engineStub));
        }

        [TestMethod]
        public void ShouldThrowArgumentNullExceptionWhenEngineNull()
        {
            var factoryStub = new Mock<IBattleShipFactory>().Object;

            Assert.ThrowsException<ArgumentNullException>(() => new CreatePlayerCommand(factoryStub, null));
        }

        [TestMethod]
        public void ExecuteShouldThrowArgumentExceptionWhenParametersIsEmpty()
        {
            var factoryStub = new Mock<IBattleShipFactory>().Object;
            var engineStub = new Mock<IEngine>().Object;

            var parameters = new List<string>();

            var cmd = new CreatePlayerCommand(factoryStub, engineStub);

            Assert.ThrowsException<ArgumentException>(() => cmd.Execute(parameters));
        }

        [TestMethod]
        public void ExecuteShouldThrowArgumentNullExceptionWhenParametersIsNull()
        {
            var factoryStub = new Mock<IBattleShipFactory>().Object;
            var engineStub = new Mock<IEngine>().Object;

            var cmd = new CreatePlayerCommand(factoryStub, engineStub);

            Assert.ThrowsException<ArgumentNullException>(() => cmd.Execute(null));
        }
    }
}
