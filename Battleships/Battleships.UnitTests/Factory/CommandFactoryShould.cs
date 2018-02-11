﻿using System;
using System.ComponentModel;
using Autofac;
using Battleships.BattleShipsEngine;
using Battleships.Commands;
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
        public void InvokeCreateMethodInMockedFactory()
        {
            //Arrange
            var stubContainer = new Mock<IComponentContext>();
            var mockedCommandFactory = new Mock<ICommandFactory>();
            mockedCommandFactory.Setup(x => x.Create(It.IsAny<string>())).Returns(value: It.IsAny<ICommand>());
            //Act
            mockedCommandFactory.Object.Create("Test");
            //Assert
            mockedCommandFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Once);
        }

        //[TestMethod]
        //public void InvokeCreateMethodInOriginalFacory()
        //{
        //    //Arrange
        //    var stubContainer = new Mock<IComponentContext>();
        //    var mockICommand = new Mock<ICommand>();
        //    stubContainer.Setup(x => x.ResolveNamed<ICommand>(It.IsAny<string>())).Returns(mockICommand.Object);

        //    var commandFactory = new CommandFactory(stubContainer.Object);
        //    var command = commandFactory.Create("Start");
             
         
        //    //Act & Assert
        //    //Assert.IsInstanceOfType(command, typeof(ICommand));
        //    stubContainer.Verify(x => x.ResolveNamed<ICommand>("Start"), Times.Once);
          
        //}
    }
}
