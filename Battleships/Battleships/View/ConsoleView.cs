//using System;
//using System.Collections.Generic;
//using Battleships.Models;
//using Battleships.Models.Contracts;
//using Battleships.View.Common;
//using Battleships.View.Contracts;
//using Bytes2you.Validation;

//namespace Battleships.View
//{
//    public class ConsoleView : IView
//    {
//        private readonly IPlayer humanPlayer;
//        private readonly IPlayer computerPlayer;
//        private readonly IParticipant enviroment;

//        public ConsoleView(IPlayer humanPlayer, IPlayer computerPlayer, IParticipant enviroment)
//        {
//            Guard.WhenArgument(humanPlayer, "Human Player").IsNull().Throw();
//            this.humanPlayer = humanPlayer;

//            Guard.WhenArgument(computerPlayer, "Computer player").IsNull().Throw();
//            this.computerPlayer = computerPlayer;

//            Guard.WhenArgument(enviroment, "Enviroment").IsNull().Throw();
//            this.enviroment = enviroment;

//            Console.SetWindowSize(Constants.ConsoleDefaultWidth, Constants.ConsoleDefaultHeight);
//            Console.BackgroundColor = Constants.ConsoleDefaultBackgroundColor;
//            Console.ForegroundColor = Constants.ConsoleDefaultForegroundColor;

//            this.Header = new GameInfoSegment(0, Constants.GameInfoSegmentDefaultHeight, 0, Constants.GameInfoSegmentMinWidth);
//        }

//        public IPlayer HumanPlayer
//        {
//            get
//            {
//                return new Player(this.humanPlayer.Name, new List<IGameObject>(this.humanPlayer.GameObjects));
//            }
//        }

//        public IPlayer ComputerPlayer
//        {
//            get
//            {
//                return new Player(this.computerPlayer.Name, new List<IGameObject>(this.computerPlayer.GameObjects));
//            }
//        }

//        public IParticipant Enviroment
//        {
//            get
//            {
//                return new Enviroment(new List<IGameObject>(this.enviroment.GameObjects));
//            }
//        }

//        private IGameInfoSegment Header{ get; set; }

//        private IViewSegment PlayerMatrix { get; set; }
        
//        private IViewSegment ComputerMatrix { get; set; }

//        private IViewSegment InOut { get; }      

//        public void Update()
//        {
//            var result = $"{this.HumanPlayer.Name} {this.HumanPlayer.Health} : {this.ComputerPlayer.Health} {this.ComputerPlayer.Name}";
//            this.Header.GameInfo = result;
//            this.Header.Update();
//        }

//        public string ReadLine()
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(string message)
//        {
//            throw new NotImplementedException();
//        }

//        public void WriteLine(string message)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}