using System.Collections.Generic;

namespace Battleships.BattleShipsEngine
{
   public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
