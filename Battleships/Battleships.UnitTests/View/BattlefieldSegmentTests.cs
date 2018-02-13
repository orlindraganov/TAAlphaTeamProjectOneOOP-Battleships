using System;
using Battleships.Models.Contracts;
using Battleships.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleships.UnitTests.View
{
    [TestClass]
    public class BattlefieldSegmentTests
    {
        [TestMethod]
        public void PlayerSetterShouldSetCorrectParameter()
        {
            var segment = new PlayerBattlefieldSegment(0, 30, 0, 30);

            var playerStub = new Mock<IPlayer>().Object;

            segment.Player = playerStub;

            Assert.AreSame(playerStub, segment.Player);
        }

        [TestMethod]
        public void PlayerSetterShouldThrowArgumentNullExceptionWhenNullPassed()
        {
            var segment = new PlayerBattlefieldSegment(0, 30, 0, 30);

            Assert.ThrowsException<ArgumentNullException>(() => segment.Player = null);
        }

        [TestMethod]
        public void PlayerSetterShouldThrowArgumentExceptionWhenAlreadySet()
        {
            var segment = new PlayerBattlefieldSegment(0, 30, 0, 30);

            var playerStub = new Mock<IPlayer>().Object;

            segment.Player = playerStub;

            Assert.ThrowsException<ArgumentException>(() => segment.Player = playerStub);
        }
    }
}