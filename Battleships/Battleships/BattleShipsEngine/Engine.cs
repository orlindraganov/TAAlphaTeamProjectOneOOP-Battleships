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
        private IList<IShip> ships;
        private IBattleShipFactory factory;
        private ICommandParser parser;
        private ICommandProcessor processor;
        private IView view;
        private IViewFactory factoryForView;


        public Engine(
        ICommandParser parser,
        ICommandProcessor processor,
        IPlayer humanPlayer,
        IPlayer computerPlayer,
        IPlayer currentPlayer,
        IList<IShip> ships,
        IBattleShipFactory factory,
        IViewFactory factoryForView

            )
        {
            this.Parser = parser;
            this.processor = processor;
            this.ships = new List<IShip>();
            this.factory = factory;
            this.humanPlayer = humanPlayer;
            this.computerPlayer = computerPlayer;
            this.currentPlayer = currentPlayer;
            this.factoryForView = factoryForView;
            this.view = factory.CreateConsoleView(factoryForView);
        }



        public ICommandParser Parser { get { return this.parser; } set { this.parser = value; } }
        public ICommandProcessor Processor { get { return this.processor; } set { this.processor = value; } }

        public IBattleShipFactory BattleShipFactory1 { get { return this.factory; } set { this.factory = value; } }

        public IList<IShip> Ships { get { return this.ships; } private set { this.ships = value; } }
      public IView View { get {return this.view; } set { this.view = value; } }



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
            this.view.SelectParticipants(this.humanPlayer, this.computerPlayer);
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

                        this.Processor.ProcessSingleCommand(command, commandAsString);
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
