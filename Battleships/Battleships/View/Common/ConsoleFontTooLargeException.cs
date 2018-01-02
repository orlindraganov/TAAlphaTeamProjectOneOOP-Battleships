using System;

namespace Battleships.View.Common
{
    public class ConsoleFontTooLargeException : Exception
    {
        public ConsoleFontTooLargeException()
        {
        }

        public ConsoleFontTooLargeException(string message) : base(message)
        {
        }

        public ConsoleFontTooLargeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}