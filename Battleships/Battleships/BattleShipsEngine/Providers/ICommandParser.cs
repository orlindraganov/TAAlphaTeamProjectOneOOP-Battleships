using Battleships.BattleShipsEngine;
using Battleships.Factory;

namespace Battleships.BattleshipsEngine
{
    public interface ICommandParser
    {
        ICommandFactory CmdFactory{ get; }
        ICommand ParseCommand(string commandLine);
    }
}