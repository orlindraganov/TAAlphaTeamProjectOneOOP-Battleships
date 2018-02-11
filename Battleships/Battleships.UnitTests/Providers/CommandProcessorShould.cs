using System;
using System.Collections;
using Battleships.BattleshipsEngine.Providers;
using Battleships.BattleShipsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleships.UnitTests.Providers
{
    [TestClass]
    public class CommandProcessorShould
    {
        [TestMethod]
        public void SetPropertyCommandWhenInitialised()
        {
            //Arrange
            var processor = new CommandProcessor();
            //Act & Assert
            Assert.IsInstanceOfType(processor.Commands, typeof(IList));
        }

        [TestMethod]
        public void ProcessSingleCommand()
        {
            //Arrange
            var processor = new Mock<ICommandProcessor>();
            var command = new Mock<ICommand>();
            processor.Setup(x => x.ProcessSingleCommand(command.Object, "CraeteSomethingCommand"))
                .Returns("SomeCommandCreated");
            //Act
            var result = processor.Object.ProcessSingleCommand(command.Object, "CraeteSomethingCommand");

            //Assert
            Assert.IsInstanceOfType(result, typeof(System.String));
        }
    }
}
