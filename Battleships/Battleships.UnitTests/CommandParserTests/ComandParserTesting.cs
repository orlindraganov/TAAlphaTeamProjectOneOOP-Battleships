using System;
using Battleships.BattleshipsEngine;
using Battleships.Factory;
using Moq;
using NUnit.Framework;

namespace Battleships.UnitTests.CommandParserTests
{
    [TestFixture]
    public class ComandParserTesting
    {
        [Test]
        public void ParserShouldThrowExWhenCmdFactoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CommandParser(null));
        }
        [Test]
        public void SetsTheRightFactoryToProperty()
        {
            var factory = new Mock<ICommandFactory>();
            var parser = new Mock<ICommandParser>();

            Assert.AreSame(factory.Object, parser.Object.CmdFactory);
        }
    }
}
