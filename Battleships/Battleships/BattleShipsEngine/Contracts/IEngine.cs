using System;
using System.Collections.Generic;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.Models.Contracts;
using Battleships.View.Contracts;

namespace Battleships.BattleShipsEngine.Contracts
{
    public interface IEngine
    {
        void Start();

        IParser Parser { get; set; }

        IList<IShip> Ships { get; }

        void AddPlayer(IPlayer player);

        void AddShip(IShip ship);

        void BeginPlay();

        string FireAt(int row, int column);

        event Action Started;

        event Action Stopped;
    }
}
