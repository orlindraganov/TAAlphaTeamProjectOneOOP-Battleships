using Battleships.BattleShipsEngine;
using System.Collections.Generic;


namespace Battleships.BattleshipsEngine.Providers.ContractsOfProviders
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
