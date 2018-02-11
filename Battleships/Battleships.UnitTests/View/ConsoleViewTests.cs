using System;
using Battleships.Factory;
using Battleships.Models.Contracts;
using Battleships.Utilities;
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
        public void UpdateShouldInvokeInOutUpdate()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            var inOutSegmentMockContext = new Mock<IInOutSegment>();
            var inOutSegmentMock = inOutSegmentMockContext.Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentMock);

            //Act
            view.Update();

            //Assert
            inOutSegmentMockContext.Verify(x => x.Update(), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateWithPositionShouldInvokeGameInfoUpdate()
        {
            //Arrange
            var gameInfoSegmentMockContext = new Mock<IGameInfoSegment>();
            var gameInfoSegmentMock = gameInfoSegmentMockContext.Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentMock, battlefieldSegmentStub, battlefieldSegmentStub, inOutSegmentStub);

            var position = new Position(3, 3);
            //Act
            view.Update(position);

            //Assert
            gameInfoSegmentMockContext.Verify(x => x.Update(), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateWithPositionShouldInvokePlayerBattlefieldUpdate()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;

            var playerBattlefieldMockContext = new Mock<IBattlefieldSegment>();
            var playerBattlefieldMock = playerBattlefieldMockContext.Object;

            var enemyBattlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, playerBattlefieldMock, enemyBattlefieldSegmentStub, inOutSegmentStub);

            var position = new Position(3, 3);

            //Act
            view.Update(position);

            //Assert
            playerBattlefieldMockContext.Verify(x => x.Update(position), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateWithPositionShouldInvokeEnemyBattlefieldUpdate()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var playerBattlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            var enemyBattlefieldMockContext = new Mock<IBattlefieldSegment>();
            var enemyBattlefieldMock = enemyBattlefieldMockContext.Object;

            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, playerBattlefieldSegmentStub, enemyBattlefieldMock, inOutSegmentStub);

            var position = new Position(3, 3);

            //Act
            view.Update(position);

            //Assert
            enemyBattlefieldMockContext.Verify(x => x.Update(position), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateWithPositionShouldInvokeInOutUpdate()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            var inOutSegmentMockContext = new Mock<IInOutSegment>();
            var inOutSegmentMock = inOutSegmentMockContext.Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub, inOutSegmentMock);

            var position = new Position(3, 3);

            //Act
            view.Update(position);

            //Assert
            inOutSegmentMockContext.Verify(x => x.Update(), Times.Exactly(1));
        }

        [TestMethod]
        public void DrawBordersShouldInvokeGameInfoDrawBorders()
        {
            //Arrange
            var gameInfoSegmentMockContext = new Mock<IGameInfoSegment>();
            var gameInfoSegmentMock = gameInfoSegmentMockContext.Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentMock, battlefieldSegmentStub, battlefieldSegmentStub, inOutSegmentStub);

            //Act
            view.DrawBorders();

            //Assert
            gameInfoSegmentMockContext.Verify(x => x.DrawBorders(), Times.Exactly(1));
        }

        [TestMethod]
        public void DrawBordersShouldInvokePlayerBattlefieldDrawBorders()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;

            var playerBattlefieldMockContext = new Mock<IBattlefieldSegment>();
            var playerBattlefieldMock = playerBattlefieldMockContext.Object;

            var enemyBattlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, playerBattlefieldMock, enemyBattlefieldSegmentStub, inOutSegmentStub);

            //Act
            view.DrawBorders();

            //Assert
            playerBattlefieldMockContext.Verify(x => x.DrawBorders(), Times.Exactly(1));
        }

        [TestMethod]
        public void DrawBordersShouldInvokeEnemyBattlefieldDrawBorders()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var playerBattlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            var enemyBattlefieldMockContext = new Mock<IBattlefieldSegment>();
            var enemyBattlefieldMock = enemyBattlefieldMockContext.Object;

            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, playerBattlefieldSegmentStub, enemyBattlefieldMock, inOutSegmentStub);

            //Act
            view.DrawBorders();

            //Assert
            enemyBattlefieldMockContext.Verify(x => x.DrawBorders(), Times.Exactly(1));
        }

        [TestMethod]
        public void DrawBordersShouldInvokeInOutDrawBorders()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;

            var inOutSegmentMockContext = new Mock<IInOutSegment>();
            var inOutSegmentMock = inOutSegmentMockContext.Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub, inOutSegmentMock);

            //Act
            view.DrawBorders();

            //Assert
            inOutSegmentMockContext.Verify(x => x.DrawBorders(), Times.Exactly(1));
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

            var playerStub = new Mock<IPlayer>().Object;

            view.FirstPlayer = playerStub;

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => view.FirstPlayer = playerStub);
        }

        [TestMethod]
        public void FirstPlayerSetterShouldCallPlayerBattlerfieldSegmentPlayerSetterWithCorrectParameter()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;

            var playerBattlefieldSegmentMockContext = new Mock<IBattlefieldSegment>();
            var playerBattlefieldSegmentMock = playerBattlefieldSegmentMockContext.Object;

            var enemyBattlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, playerBattlefieldSegmentMock, enemyBattlefieldSegmentStub,
                inOutSegmentStub);

            var playerStub = new Mock<IPlayer>().Object;

            //Act
            view.FirstPlayer = playerStub;

            //Assert
            playerBattlefieldSegmentMockContext.VerifySet(x => x.Player = playerStub);
        }

        [TestMethod]
        public void FirstPlayerSetterShouldCallGameInfoSegmentFirstPlayerSetterWithCorrectParameter()
        {
            //Arrange
            var gameInfoSegmentMockContext = new Mock<IGameInfoSegment>();
            var gameInfoSegmentMock = gameInfoSegmentMockContext.Object;

            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentMock, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentStub);

            var playerStub = new Mock<IPlayer>().Object;

            //Act
            view.FirstPlayer = playerStub;

            //Assert
            gameInfoSegmentMockContext.VerifySet(x => x.FirstPlayer = playerStub);
        }

        [TestMethod]
        public void SecondPlayerSetShouldSetCorrectParameter()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentStub);

            var playerStub = new Mock<IPlayer>().Object;

            //Act
            view.SecondPlayer = playerStub;

            //Assert
            Assert.AreSame(playerStub, view.SecondPlayer);
        }

        [TestMethod]
        public void SecondPlayerSetterShouldThrowArgumentNullExceptionWhenNullPassed()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentStub);

            IPlayer player = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => view.SecondPlayer = player);
        }

        [TestMethod]
        public void SecondPlayerSetterShouldThrowArgumentExceptionWhenAlreadySet()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;
            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentStub);

            var playerStub = new Mock<IPlayer>().Object;

            view.SecondPlayer = playerStub;

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => view.SecondPlayer = playerStub);
        }

        [TestMethod]
        public void SecondPlayerSetterShouldCallEnemyBattlerfieldSegmentPlayerSetterWithCorrectParameter()
        {
            //Arrange
            var gameInfoSegmentStub = new Mock<IGameInfoSegment>().Object;

            var enemyBattlefieldSegmentMockContext = new Mock<IBattlefieldSegment>();
            var enemyBattlefieldSegmentMock = enemyBattlefieldSegmentMockContext.Object;

            var playerBattlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentStub, playerBattlefieldSegmentStub, enemyBattlefieldSegmentMock,
                inOutSegmentStub);

            var playerStub = new Mock<IPlayer>().Object;

            //Act
            view.SecondPlayer = playerStub;

            //Assert
            enemyBattlefieldSegmentMockContext.VerifySet(x => x.Player = playerStub);
        }

        [TestMethod]
        public void SecondPlayerSetterShouldCallGameInfoSegmentSecondPlayerSetterWithCorrectParameter()
        {
            //Arrange
            var gameInfoSegmentMockContext = new Mock<IGameInfoSegment>();
            var gameInfoSegmentMock = gameInfoSegmentMockContext.Object;

            var battlefieldSegmentStub = new Mock<IBattlefieldSegment>().Object;
            var inOutSegmentStub = new Mock<IInOutSegment>().Object;

            var view = new ConsoleView(gameInfoSegmentMock, battlefieldSegmentStub, battlefieldSegmentStub,
                inOutSegmentStub);

            var playerStub = new Mock<IPlayer>().Object;

            //Act
            view.SecondPlayer = playerStub;

            //Assert
            gameInfoSegmentMockContext.VerifySet(x => x.SecondPlayer = playerStub);
        }
    }
}