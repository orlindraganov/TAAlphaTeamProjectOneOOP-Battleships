using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using System;

namespace Battleships.BattleshipsEngine.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
