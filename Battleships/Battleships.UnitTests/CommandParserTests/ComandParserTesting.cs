using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Battleships.BattleshipsEngine;
using Battleships.Factory;
using Moq;

namespace OlympicGamesUnitTests.CommandParserTests
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
            
            Assert.AreSame(factory.Object,parser.Object.CmdFactory);
        }
    }
}
