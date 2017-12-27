using System;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;

namespace Battleships.View
{
    public class GameInfo : ViewSegment, IViewSegment, IGameInfo
    {
        public GameInfo(int startingRow, int height, int startingCol, int width, ViewType type) : base(startingRow, height, startingCol, width, type)
        {
            this.BorderSymbol = '*';
        }

        public int StartingRow { get; }

        public int Height { get; }

        public int StartingCol { get; }

        public int Width { get; }

        public ViewType Type { get; }

        public string FirstPlayerName { get; }

        public int FistPlayerScore { get; }

        public string SecondPlayerName { get; }

        public int SecondPlayerScore { get; }

        private int ContentRow { get; }
        
        private int ContentStartingCol { get; }

        private char BorderSymbol;

        protected override int GetMinimumHeight()
        {
            return Constants.GameInfoMinHeight;
        }

        protected override int GetMinimumWidth()
        {
            return Constants.GameInfoMinWidth;
        }

        public override void Update()
        {
            
        }

        private void DrawHorizontalLine(int row, int startingCol, int length, char symbol)
        {
            for (int i = 0; i < length; i++)
            {
                var currentCol = startingCol + i;
                Console.SetCursorPosition(currentCol, row);
                Console.Write(symbol);
            }
        }

        private void DrawVerticalLine(int col, int startingRow, int length, char symbol)
        {
            for (int i = 0; i < length; i++)
            {
                var currentRow = startingRow + i;
                Console.SetCursorPosition(currentRow, col);
                Console.Write(symbol);
            }
        }
    }
}
