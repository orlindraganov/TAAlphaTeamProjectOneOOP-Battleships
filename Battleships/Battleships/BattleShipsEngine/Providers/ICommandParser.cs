using Battleships.BattleShipsEngine;

namespace Battleships.BattleshipsEngine
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandLine);
    }
}