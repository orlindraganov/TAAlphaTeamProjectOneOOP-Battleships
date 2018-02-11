using System;
using Battleships.Factory;
using Battleships.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.UnitTests.Factory
{
    [TestClass]
    public class BattleShipsFactoryShould
    {
        [TestMethod]
        public void ReturnArgumentNullExceptionOnCreateBattleFieldCommandByNull()
        {
            //Arrange
            var factory = new BattleShipFactory();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => factory.CreateBattleField(null));
        }

        [TestMethod]
        public void ReturnArgumentNullExceptionOnCreatePlayerCommandByNull()
        {
            //Arrange
            var factory = new BattleShipFactory();

            //Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => factory.CreatePlayer(null, null));
        }

        [TestMethod]
        public void ReturnArgumentNullExceptionOnCreateAircraftCarrierCommandByNull()
        {
            //Arrange
            var factory = new BattleShipFactory();

            //Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => factory.CreateAircraftCarrier(null, Enums.Direction.Up));
        }

        [TestMethod]
        public void ReturnArgumentNullExceptionOnCreateBattleCruiserCommandByNull()
        {
            //Arrange
            var factory = new BattleShipFactory();

            //Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => factory.CreateBattleCruiser(null, Enums.Direction.Up));
        }

        [TestMethod]
        public void ReturnArgumentNullExceptionOnCreateCreateDestroyerCommandByNull()
        {
            //Arrange
            var factory = new BattleShipFactory();

            //Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => factory.CreateDestroyer(null, Enums.Direction.Up));
        }

        [TestMethod]
        public void ReturnArgumentNullExceptionOnCreateCreateFrigateCommandByNull()
        {
            //Arrange
            var factory = new BattleShipFactory();

            //Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => factory.CreateFrigate(null, Enums.Direction.Up));
        }

        [TestMethod]
        public void ReturnArgumentNullExceptionOnCreateSubmarineCommandByNull()
        {
            //Arrange
            var factory = new BattleShipFactory();

            //Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => factory.CreateSubmarine(null, Enums.Direction.Up));
        }

        [TestMethod]
        public void ReturnArgumentNullExceptionOnCreateGameObjectElementCommandByNull()
        {
            //Arrange
            var factory = new BattleShipFactory();

            //Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => factory.CreateGameObjectElement(null, Enums.GameObjectElementType.Ship));
        }

    }
}
