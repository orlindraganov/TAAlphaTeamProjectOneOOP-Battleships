﻿using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Models;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.Factory
{
	public class BattleShipFactory : IBattleShipFactory
	{
		public BattleShipFactory()
		{

		}


		public IBattlefield CreateBattleField(IGameObjectElement[,] map)
		{
			return new Battlefield(map);
		}

		public IPlayer CreatePlayer(string name)
		{
			return new Player(name);
		}


		public IShip CreateAircraftCarrier(IPosition origin, Direction direction)
		{
			return new AircraftCarrier(origin, direction);
		}
		public IShip CreateBattleCruiser(IPosition origin, Direction direction)
		{
			return new Battlecruiser(origin, direction);
		}
		public IShip CreateDestroyer(IPosition origin, Direction direction)
		{
			return new Destroyer(origin, direction);
		}
		public IShip CreateFrigate(IPosition origin, Direction direction)
		{
			return new Frigate(origin, direction);
		}
		public IShip CreateSubmarine(IPosition origin, Direction direction)
		{
			return new Submarine(origin, direction);
		}
	}
}
