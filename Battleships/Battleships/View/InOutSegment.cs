using System;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.Utilities;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;
using Bytes2you.Validation;

namespace Battleships.View
{
    public class InOutSegment : ViewSegment, IViewSegment, IInOutSegment, IReader, IWriter
    {
        public InOutSegment(int startingRow, int height, int startingCol, int width) : base(startingRow, height, startingCol, width)
        {
            var promptsCol = startingCol + 2;
            var outPropmtRow = startingRow + height / 2 - 1;
            var inPromptRow = startingRow + height / 2 + 1;

            this.SetConsole(ConsoleSettings.Text);
            Console.SetCursorPosition(promptsCol, outPropmtRow);
            Console.Write(this.OutputPrompt);
            Console.SetCursorPosition(promptsCol, inPromptRow);
            Console.Write(this.InputPrompt);

            var offset = Math.Max(this.InputPrompt.Length, this.OutputPrompt.Length) + 1;

            this.ReadStartingPosition = new Position(inPromptRow, promptsCol + offset);
            this.WriteStartingPosition = new Position(outPropmtRow, promptsCol + offset);
        }

        private string InputPrompt => Constants.InOutSegmentInputPrompt;

        private string OutputPrompt => Constants.InOutSegmentOutputPrompt;

        private Position ReadStartingPosition { get; set; }

        private Position WriteStartingPosition { get; set; }

        private int LastReadMessageLength { get; set; }

        private int LastWriteMessageLength { get; set; }

        protected override int GetMinimumHeight()
        {
            return Constants.InOutSegmentMinHeight;
        }

        protected override int GetMinimumWidth()
        {
            return Constants.InOutSegmentMinWidth;
        }

        public override void Update()
        {
            Console.SetCursorPosition(ReadStartingPosition.Col, ReadStartingPosition.Row);
        }

        public string ReadLine()
        {
            var message = Console.ReadLine();
            Guard.WhenArgument(message, "Message").IsNull().Throw();
            this.LastReadMessageLength = message.Length;
            Console.SetCursorPosition(ReadStartingPosition.Col, ReadStartingPosition.Row);
            this.ClearLastReadMessage();
            return message;
        }

        public void Write(string message)
        {
            throw new System.NotImplementedException();
        }

        private void ClearLastReadMessage()
        {
            this.SetConsole(ConsoleSettings.Text);
            Console.SetCursorPosition(ReadStartingPosition.Col, ReadStartingPosition.Row);

            for (int i = 0; i < LastReadMessageLength; i++)
            {
                Console.Write(" ");
            }
        }

        private void ClearLastWriteMessage()
        {
            this.SetConsole(ConsoleSettings.Text);
            Console.SetCursorPosition(WriteStartingPosition.Col, WriteStartingPosition.Row);

            for (int i = 0; i < LastWriteMessageLength; i++)
            {
                Console.Write(" ");
            }

            this.LastWriteMessageLength = 0;
        }

        public void WriteLine(string message)
        {
            this.ClearLastWriteMessage();
            this.SetConsole(ConsoleSettings.Text);
            Console.SetCursorPosition(WriteStartingPosition.Col, WriteStartingPosition.Row);
            Console.WriteLine(message);
            this.LastWriteMessageLength = message.Length;
            Console.SetCursorPosition(ReadStartingPosition.Col, ReadStartingPosition.Row);
        }
    }
}