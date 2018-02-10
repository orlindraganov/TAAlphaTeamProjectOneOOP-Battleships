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
		private static IEngine instanceHolder;
		private const string TerminationCommand = "exit";
		private const string NullProvidersExceptionMessage = "cannot be null.";

        public event Action Started;
        public event Action Stopped;

        private IPlayer humanPlayer;
        private IPlayer computerPlayer;
        private IPlayer currentPlayer;

        private Engine()
		{
			this.Parser = new CommandParser();
			this.Ships = new List<IShip>();
			this.BattleShipFactory = Factory.BattleShipFactory.Instance;
        }



        public IParser Parser { get; set; }

		public IBattleShipFactory BattleShipFactory { get; set; }

		public IList<IShip> Ships { get; private set; }

        private IView view = new ConsoleView();



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

			while (true)
			{
				try
				{
					var commandAsString = this.view.ReadLine();

					if (commandAsString.ToLower() == TerminationCommand)
					{
						break;
					}

					this.ProcessCommand(commandAsString);
                    //this.currentPlayer = this.currentPlayer == this.humanPlayer ? this.computerPlayer : this.humanPlayer;
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

        private void ProcessCommand(string commandAsString)
		{
			if (string.IsNullOrWhiteSpace(commandAsString))
			{
				throw new ArgumentNullException(nameof(commandAsString), "Command cannot be null or empty.");
			}

			var command = this.Parser.ParseCommand(commandAsString);
			var parameters = this.Parser.ParseParameters(commandAsString);

			var executionResult = command.Execute(parameters);
			this.view.WriteLine(executionResult);

		}

       
    }
}
