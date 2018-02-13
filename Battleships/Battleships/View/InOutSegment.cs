using System;
using Battleships.Utilities;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;

namespace Battleships.View
{
    public class InOutSegment : ViewSegment, IViewSegment, IInOutSegment, IInput, IOutput
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

        private string InputPrompt => ViewSettings.InOutSegmentInputPrompt;

        private string OutputPrompt => ViewSettings.InOutSegmentOutputPrompt;

        private Position ReadStartingPosition { get; set; }

        private Position WriteStartingPosition { get; set; }

        private int LastReadMessageLength { get; set; }

        private int LastWriteMessageLength { get; set; }

        protected override int GetMinimumHeight()
        {
            return ViewSettings.InOutSegmentMinHeight;
        }

        protected override int GetMinimumWidth()
        {
            return ViewSettings.InOutSegmentMinWidth;
        }

        public override void Update()
        {
            this.SetConsole(ConsoleSettings.Text);
            Console.SetCursorPosition(ReadStartingPosition.Col, ReadStartingPosition.Row);
        }

        public string ReadLine()
        {
            var message = string.Empty;
            var limit = this.Width - this.ReadStartingPosition.Col + this.StartingCol - 2;

            while (true)
            {
                var c = Console.ReadKey(true).KeyChar;

               if (c == '\r')
                    break;
                if (c == '\b')
                {
                    if (message != "")
                    {
                        message = message.Substring(0, message.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (message.Length < limit)
                {
                    Console.Write(c);
                    message += c;
                }
            }

            this.LastReadMessageLength = message.Length;
            this.ClearLastReadMessage();
            Console.SetCursorPosition(ReadStartingPosition.Col, ReadStartingPosition.Row);
            return message;
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
    }
}