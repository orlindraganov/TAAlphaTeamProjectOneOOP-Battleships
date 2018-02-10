using System;
using System.Collections.Generic;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.Models.Contracts;
using Battleships.View.Contracts;
using Battleships.BattleshipsEngine;
using Battleships.BattleshipsEngine.Providers;

namespace Battleships.BattleShipsEngine.Contracts
{
    public interface IEngine
    {
        void Start();

        ICommandParser Parser { get; set; }
        ICommandProcessor Processor { get; set; }

        void AddPlayer(IPlayer player);

        void AddShip(IShip ship);

        void BeginPlay();

        string FireAt(int row, int column);

        event Action Started;

        event Action Stopped;
    }
}
