using System;
using Battleships.Factory;
using Battleships.Models.Contracts;
using Battleships.View;
using Battleships.View.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleships.UnitTests.View
{
    [TestClass]
    public class ConsoleViewTests
    {
        [TestMethod]
        public void ConstructorShouldThrowArgumentNullExceptionWhenGameInfoSegmentIsNull()
        {
            //Arrange
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ConsoleView(null, battlefieldSegmentStub, battlefieldSegmentStub, inOutSegmentStub));
        }

        [TestMethod]
        public void ConstructorShouldThrowArgumentNullExceptionWhenPlayerBattlefieldSegmentIsNull()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ConsoleView(gameInfoSegmentStub, null, battlefieldSegmentStub, inOutSegmentStub));
        }

        [TestMethod]
        public void ConstructorShouldThrowArgumentNullExceptionWhenEnemyBattlefieldSegmentIsNull()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, null, inOutSegmentStub));
        }

        [TestMethod]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInOutSegmentIsNull()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub, null));
        }

        [TestMethod]
        public void UpdateShouldInvokeGameInfoUpdate()
        {
            //Arrange
            var gameInfoSegmentMockContext = new Mock<IGameInfoSegment>();
            var gameInfoSegmentMock = gameInfoSegmentMockContext.Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentMock, battlefieldSegmentStub, battlefieldSegmentStub, inOutSegmentStub);

            //Act
            view.Update();

            //Assert
            gameInfoSegmentMockContext.Verify(x => x.Update(), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateShouldInvokePlayerBattlefieldUpdate()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;

            var playerBattlefieldMockContext = new Mock<IBattlefieldSegment>();
            var playerBattlefieldMock = playerBattlefieldMockContext.Object;

            var enemyBattlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, playerBattlefieldMock, enemyBattlefieldSegmentStub, inOutSegmentStub);

            //Act
            view.Update();

            //Assert
            playerBattlefieldMockContext.Verify(x => x.Update(), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateShouldInvokeEnemyBattlefieldUpdate()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var playerBattlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            var enemyBattlefieldMockContext = new Mock<IBattlefieldSegment>();
            var enemyBattlefieldMock = enemyBattlefieldMockContext.Object;

            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, playerBattlefieldSegmentStub, enemyBattlefieldMock,
                inOutSegmentStub);

            //Act
            view.Update();

            //Assert
            enemyBattlefieldMockContext.Verify(x => x.Update(), Times.Exactly(1));
        }

        [TestMethod]
        public void ReadLineShouldReturnInOutReadLine()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            var input = "Never gonna give you up";
            var inOutSegmentMockContext = new Mock<IInOutSegment>();
            inOutSegmentMockContext.Setup(inOut => inOut.ReadLine()).Returns(input);

            var inOuSegmentMock = inOutSegmentMockContext.Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub, inOuSegmentMock);
            //Act
            var output = view.ReadLine();

            //Assert
            Assert.AreSame(input, output);
        }

        [TestMethod]
        public void WriteLineShouldInvokeInOutWriteLineWithCorrectParameter()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            var inOutSegmentMockContext = new Mock<IInOutSegment>();

            var inOuSegmentMock = inOutSegmentMockContext.Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub, inOuSegmentMock);

            var input = "Never gonna give you up";
            //Act
            view.WriteLine(input);

            //Assert
            inOutSegmentMockContext.Verify(x => x.WriteLine(input), Times.Once);
        }

        [TestMethod]
        public void FirstPlayerSetShouldSetCorrectParameter()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentStub);

            var playerStub = new Mock<IPlayer>().Object;

            //Act
            view.FirstPlayer = playerStub;

            //Assert
            Assert.AreSame(playerStub, view.FirstPlayer);
        }

        [TestMethod]
        public void FirstPlayerSetterShouldThrowArgumentNullExceptionWhenNullPassed()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentStub);

            IPlayer player = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => view.FirstPlayer = player);
        }

        [TestMethod]
        public void FirstPlayerSetterShouldThrowArgumentExceptionWhenAlreadySet()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentStub);

            var factory= new BattleShipFactory();

            var playerStub = new Mock<IPlayer>().Object;

            view.FirstPlayer = playerStub;

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => view.FirstPlayer = playerStub);
        }
    }
}