using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.Factory;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.BattleshipsEngine.Providers;
using Battleships.BattleshipsEngine;
using Battleships.Models.Contracts;
using Battleships.Models;

namespace Battleships.BattleShipsEngine
{
    public sealed class Engine : IEngine
    {
        private static IEngine instanceHolder;
        private const string TerminationCommand = "exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();
            this.Ships = new List<IShip>();

        }
        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public IParser Parser { get; set; }

        public IList<IShip> Ships { get; private set; }

        public static IEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new Engine();
                }

                return instanceHolder;
            }
        }
        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                  
                }
            }
        }
        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
          
        }



    }
}



