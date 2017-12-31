﻿using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.View.Contracts
{
    public interface IView : IReader, IWriter
    {
        IPlayer HumanPlayer { get; }

        IPlayer ComputerPlayer { get; }
        
        void Update();

        void Update(IPosition position);
    }
}