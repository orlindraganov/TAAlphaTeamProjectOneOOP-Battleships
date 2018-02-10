using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.BattleShipsEngine;
using Battleships.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Battleships.BattleshipsEngine.CommandParser;

namespace Battleships.BattleshipsEngine
{

        public class CommandParser : ICommandParser
    {
            private readonly ICommandFactory cmdFactory;

            public CommandParser(ICommandFactory cmdFactory)
            {
                this.cmdFactory = cmdFactory ?? throw new ArgumentNullException();
            }

            public ICommandFactory CmdFactory => cmdFactory;

            public ICommand ParseCommand(string commandLine)
            {
                var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var commandName = lineParameters[0];

                var command = this.CmdFactory.Create(commandName);

                // command do something

                return command;
            }
        }
    }
