﻿using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;

namespace Battleships.View.Contracts
{
    public interface IInOutSegment : IViewSegment, IReader, IWriter
    {
    }
}