using Battleships.BattleShipsEngine;

namespace Battleships.Factory
{
    public interface ICommandFactory
    {
        ICommand Create(string cmdName);
    }
}