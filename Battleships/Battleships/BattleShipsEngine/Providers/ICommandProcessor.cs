
using Battleships.BattleShipsEngine;
using System.Collections.Generic;

namespace Battleships.BattleshipsEngine.Providers
{
    public interface ICommandProcessor
    {
         ICollection<ICommand> Commands { get;  set; }

        void ProcessSingleCommand(ICommand command, string commandParameters);
    }
}