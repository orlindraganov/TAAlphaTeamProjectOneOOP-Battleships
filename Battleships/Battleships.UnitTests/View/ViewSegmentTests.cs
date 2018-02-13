using System;
using Battleships.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.UnitTests.View
{
    [TestClass]
    public class ViewSegmentTests
    {
        [TestMethod]
        public void ConstructorShouldSetTheCorrectParameters()
        {
            //Arrange
            var startingRow = 0;
            var startingCol = 0;
            var height = 10;
            var width = 40;

            //Act
            var segment = new GameInfoSegment(startingRow, height, startingCol, width);

            //Assert
            Assert.AreEqual(startingRow, segment.StartingRow);
            Assert.AreEqual(startingCol, segment.StartingCol);
            Assert.AreEqual(height, segment.Height);
            Assert.AreEqual(width, segment.Width);
        }

        [TestMethod]
        public void ConstructorShouldThrowArgumentOutOfRangeExceptionWhenInvalidStartingRowIsPassed()
        {
            //Arrange
            var startingRow = -5;
            var startingCol = 0;
            var height = 10;
            var width = 40;

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GameInfoSegment(startingRow, height, startingCol, width));
        }

        [TestMethod]
        public void ConstructorShouldThrowArgumentOutOfRangeExceptionWhenInvalidStartingColIsPassed()
        {
            //Arrange
            var startingRow = 0;
            var startingCol = -5;
            var height = 10;
            var width = 40;

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GameInfoSegment(startingRow, height, startingCol, width));
        }

        [TestMethod]
        public void ConstructorShouldThrowArgumentOutOfRangeExceptionWhenInvalidHeightIsPassed()
        {
            //Arrange
            var startingRow = 0;
            var startingCol = 0;
            var height = -10;
            var width = 40;

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GameInfoSegment(startingRow, height, startingCol, width));
        }

        [TestMethod]
        public void ConstructorShouldThrowArgumentOutOfRangeExceptionWhenInvalidWidthIsPassed()
        {
            //Arrange
            var startingRow = 0;
            var startingCol = 0;
            var height = 10;
            var width = -40;

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GameInfoSegment(startingRow, height, startingCol, width));
        }
    }
}