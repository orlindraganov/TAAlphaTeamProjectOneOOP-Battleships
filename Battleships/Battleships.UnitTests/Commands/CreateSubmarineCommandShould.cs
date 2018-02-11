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
    public class CreateSubmarineCommandShould
    {
        [TestMethod]
        public void SetTheFieldFactory()
        {
            //Arrange
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var mockFactory = new FakeCreateSubmarineCommand(fakeFactory.Object, fakeEngine.Object);
            //Act & Assert
            Assert.AreSame(fakeFactory.Object, mockFactory.Factory);

        }

        [TestMethod]
        public void SetTheFieldEngine()
        {
            //Arrange
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var mockFactory = new FakeCreateSubmarineCommand(fakeFactory.Object, fakeEngine.Object);
            //Act & Assert
            Assert.AreSame(fakeEngine.Object, mockFactory.Engine);

        }
        [TestMethod]
        public void IsAnInstanceOfICommand()
        {
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var mockFactory = new FakeCreateSubmarineCommand(fakeFactory.Object, fakeEngine.Object);
            Assert.IsInstanceOfType(mockFactory, typeof(ICommand));

        }
        [TestMethod]
        public void ThrowsArgumentExWithTheRightMessageIfInvalidParamatersArePassed()
        {
            var fakeFactory = new Mock<IBattleShipFactory>();
            var fakeEngine = new Mock<IEngine>();
            var command = new CreateSubmarineCommand(fakeFactory.Object, fakeEngine.Object);
            var list = new List<string>();
            list.Add("c");
            list.Add("justone");
            var message = "";
            var expected = "Invalid parameters";
            try
            {
                command.Execute(list);
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            Assert.AreEqual(expected, message);

        }
    }
}
