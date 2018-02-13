using System;
using Battleships.Models.Contracts;
using Battleships.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleships.UnitTests.View
{
    [TestClass]
    public class GameInfoSegmentTests
    {
        [TestMethod]
        public void GameInfoSetterShouldSetCorrectParameter()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);
            var info = "Never gonna give you up";

            //Act
            segment.GameInfo = info;

            //Assert
            Assert.AreEqual(info, segment.GameInfo);
        }

        [TestMethod]
        public void GameInfoSetterShouldThrowArgumentNullExceptionWhenNullIsPassed()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => segment.GameInfo = null);
        }

        [TestMethod]
        public void GameInfoSetterShouldThrowArgumentOutOfRangeExceptionWhenTooLongStringIsPassed()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);
            var info = "123456789012345678901234567890123456789012";

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => segment.GameInfo = info);
        }

        [TestMethod]
        public void FirstPlayerSetterShouldThrowArgumentNullExceptionWhenNullIsPassed()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => segment.FirstPlayer = null);
        }

        [TestMethod]
        public void FirstPlayerSetterShouldThrowArgumentExceptionWhenAlreadySet()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);
            var playerStub = new Mock<IPlayer>().Object;
            segment.FirstPlayer = playerStub;

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => segment.FirstPlayer = playerStub);
        }

        [TestMethod]
        public void FirstPlayerSetterShouldSetCorrectParameter()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);
            var playerStub = new Mock<IPlayer>().Object;

            //Act
            segment.FirstPlayer = playerStub;

            //Assert
            Assert.AreSame(playerStub, segment.FirstPlayer);
        }

        [TestMethod]
        public void SecondPlayerSetterShouldThrowArgumentNullExceptionWhenNullIsPassed()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => segment.SecondPlayer = null);
        }

        [TestMethod]
        public void SecondPlayerSetterShouldThrowArgumentExceptionWhenAlreadySet()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);
            var playerStub = new Mock<IPlayer>().Object;
            segment.SecondPlayer = playerStub;

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => segment.SecondPlayer = playerStub);
        }

        [TestMethod]
        public void SecondPlayerSetterShouldSetCorrectParameter()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);
            var playerStub = new Mock<IPlayer>().Object;

            //Act
            segment.SecondPlayer = playerStub;

            //Assert
            Assert.AreSame(playerStub, segment.SecondPlayer);
        }

        [TestMethod]
        public void CalculateGameInfoRowShouldCalculateCorrectly()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);
            var expected = 2;

            //Act & Assert
            Assert.AreEqual(expected, segment.CalculateGameInfoRow());
        }

        [TestMethod]
        public void CalculateGameInfoColShouldCalculateCorrectly()
        {
            //Arrange
            var segment = new GameInfoSegment(0, 5, 0, 40);
            var gameInfo = "1234";
            var expected = 18;
            segment.GameInfo = gameInfo;

            //Act & Assert
            Assert.AreEqual(expected, segment.CalculateGameInfoCol());
        }
    }
}