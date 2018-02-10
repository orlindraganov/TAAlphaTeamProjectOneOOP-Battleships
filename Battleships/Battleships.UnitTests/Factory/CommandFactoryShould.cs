using System;
using System.ComponentModel;
using Autofac;
using Battleships.BattleShipsEngine;
using Battleships.Factory;
using Battleships.UnitTests.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleships.UnitTests.BattleshipsFactoryTests
{
    [TestClass]
    public class CommandFactoryShould
    {
        [TestMethod]
        public void SetFieldContainerToTheConstructorValuePassed()
        {
            //Arrange & Act
            var stubContainer = new Mock<IComponentContext>(); 
            var mockedCommandFactory = new MockedCommandFactory(stubContainer.Object);
            //Assert
            Assert.AreSame(mockedCommandFactory.Container, stubContainer.Object);
        }

        [TestMethod]
        public void InvokeCreateMethod()
        {
            //Arrange & Act
            var stubContainer = new Mock<IComponentContext>();
            var mockedCommandFactory = new Mock<ICommandFactory>();
            mockedCommandFactory.Setup(x => x.Create(It.IsAny<string>())).Returns(value: It.IsAny<ICommand>());
            //Assert
            //mockedCommandFactory.Create(cmName).Verify(x => x.Create(It.IsAny<string>()), Times.Once);
            mockedCommandFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Once);
        }
    }
}
