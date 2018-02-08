using Battleships.BattleShipsEngine;

namespace Battleships.Factory
{
    public interface ICommandFactory1
    {
        ICommand Create(string cmdName);
    }
}