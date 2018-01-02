using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using System;

namespace Battleships.BattleshipsEngine.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
