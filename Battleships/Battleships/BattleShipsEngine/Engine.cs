using System;
using System.Collections.Generic;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.BattleshipsEngine.Providers;
using Battleships.BattleshipsEngine;
using Battleships.Factory;
using Battleships.Models.Contracts;

namespace Battleships.BattleShipsEngine
{
	public sealed class Engine : IEngine
	{
		private static IEngine instanceHolder;
		private const string TerminationCommand = "exit";
		private const string NullProvidersExceptionMessage = "cannot be null.";

		//private IPlayer humanPlayer;
		//private IPlayer computerPlayer;
		//private IPlayer currentPlayer;

		private Engine()
		{
			this.Reader = new ConsoleReader();
			this.Writer = new ConsoleWriter();
			this.Parser = new CommandParser();
			this.Ships = new List<IShip>();
			this.BattleShipFactory = Factory.BattleShipFactory.Instance;
		}

		public IReader Reader { get; set; }

		public IWriter Writer { get; set; }

		public IParser Parser { get; set; }

		public IBattleShipFactory BattleShipFactory { get; set; }

		public IList<IShip> Ships { get; private set; }

		public void AddShip(IShip ship)
		{
			throw new NotImplementedException();
		}

		public void FireAt(int row, int column)
		{
			throw new NotImplementedException();
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
			while (true)
			{
				try
				{
					var commandAsString = this.Reader.ReadLine();

					if (commandAsString.ToLower() == TerminationCommand)
					{
						break;
					}

					this.ProcessCommand(commandAsString);
					//this.currentPlayer = this.currentPlayer == this.humanPlayer ? this.computerPlayer : this.humanPlayer;
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
				throw new ArgumentNullException(nameof(commandAsString), "Command cannot be null or empty.");
			}

			var command = this.Parser.ParseCommand(commandAsString);
			var parameters = this.Parser.ParseParameters(commandAsString);

			var executionResult = command.Execute(parameters);
			this.Writer.WriteLine(executionResult);

		}


		private IShip[] QueryHumanPlayerShips()
		{
			// TODO: Validate ships against battlefield and for overlapping!
			throw new NotImplementedException();
		}
	}
}
