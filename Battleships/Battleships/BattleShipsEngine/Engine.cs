using System;
using System.Collections.Generic;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.BattleshipsEngine.Providers;
using Battleships.BattleshipsEngine;
using Battleships.Factory;
using Battleships.Models.Contracts;
using Battleships.View.Contracts;
using Battleships.View;

namespace Battleships.BattleShipsEngine
{
    public sealed class Engine : IEngine
    {
        private const string TerminationCommand = "exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        public event Action Started;
        public event Action Stopped;

        private IPlayer humanPlayer;
        private IPlayer computerPlayer;
        private IPlayer currentPlayer;
        private IBattleShipFactory factory;
        private ICommandParser parser;
        private ICommandProcessor processor;
        private IView view;


        public Engine(
        ICommandParser parser,
        ICommandProcessor processor,
        IBattleShipFactory factory,
        IView view
        )
        {
            this.Parser = parser;
            this.processor = processor;
            this.factory = factory;
            this.view = view;
        }



        public ICommandParser Parser { get { return this.parser; } set { this.parser = value; } }
        public ICommandProcessor Processor { get { return this.processor; } set { this.processor = value; } }

        public IBattleShipFactory BattleShipFactory1 { get { return this.factory; } set { this.factory = value; } }

        public IView View { get { return this.view; } set { this.view = value; } }



        public void AddPlayer(IPlayer player)
        {
            if (this.humanPlayer == null)
            {
                this.humanPlayer = player;
            }
            else
            {
                this.computerPlayer = player;
            }

            this.currentPlayer = player;
        }


        public void AddShip(IShip ship)
        {
            this.currentPlayer.AddShip(ship);
        }

        public string FireAt(int row, int column)
        {
            this.currentPlayer = this.currentPlayer == this.humanPlayer ? this.computerPlayer : this.humanPlayer;
            this.currentPlayer.Battlefield.Map[row, column].GetHit();
            return $"You had a shot at position {row + 1} {(char)(column + 'A')}";
        }

        public void BeginPlay()
        {
            this.view.FirstPlayer = this.humanPlayer;
            this.view.SecondPlayer = this.computerPlayer;
            this.currentPlayer = this.humanPlayer;
        }



        public void Start()
        {
            //this.humanPlayer = this.BattleShipFactory.CreatePlayer("Human", null);
            //// Human player enters the fleet.
            //var humanShips = this.QueryHumanPlayerShips();
            //foreach (var humanShip in humanShips)
            //{
            //	this.humanPlayer.AddShip(humanShip);
            //}

            //this.computerPlayer = this.BattleShipFactory.CreatePlayer("Computer", null);
            //// Generate computer fleet

            //this.currentPlayer = this.humanPlayer;

            this.OnStarted();

            string commandAsString = null;

            while ((commandAsString = this.view.ReadLine()) != TerminationCommand)
            {
              
            
                try
                {
                    var command = this.Parser.ParseCommand(commandAsString);

                    if (command != null)
                    {
                        var commandResult = this.Processor.ProcessSingleCommand(command, commandAsString);
                        this.view.WriteLine(commandResult);
                    }

                    this.view.Update();
                }
                catch (Exception ex)
                {
                    this.view.WriteLine(ex.Message);
                }
            }

            this.OnStopped();
        }

        private void OnStarted()
        {
            if (this.Started != null)
            {
                this.Started();
            }
        }

        private void OnStopped()
        {
            if (this.Stopped != null)
            {
                this.Stopped();
            }
        }



    }
}
