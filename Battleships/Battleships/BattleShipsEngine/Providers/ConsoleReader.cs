﻿using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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