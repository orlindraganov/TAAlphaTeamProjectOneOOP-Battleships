using System.Collections.Generic;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.Models.Contracts;

namespace Battleships.View.Contracts
{
    public interface IView : IReader, IWriter
    {
        IPlayer HumanPlayer { get; }
        IPlayer ComputerPlayer { get; }
        IParticipant Enviroment { get; }

        void Update();
    }
}