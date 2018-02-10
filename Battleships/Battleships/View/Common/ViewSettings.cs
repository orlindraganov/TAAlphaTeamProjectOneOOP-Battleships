using System;

namespace Battleships.View.Common
{
    public static class ViewSettings
    {
        public const string GameName = "INVEST IMPEX INTL BATTLESHIPS";

        public const ConsoleColor ConsoleDefaultBackgroundColor = ConsoleColor.Black;
        public const ConsoleColor ConsoleDefaultForegroundColor = ConsoleColor.White;
        public const ConsoleColor ConsoleDefaultBorderColor = ConsoleColor.DarkGray;
        public const ConsoleColor ConsoleDefaultBorderBackgroundColor = ConsoleColor.DarkBlue;

        public const ConsoleColor NotHitBackgroundColor = ConsoleColor.DarkBlue;
        public const ConsoleColor HitBackgroundColor = ConsoleColor.White;

        public const ConsoleColor WaterNotHitForegroundColor = ConsoleColor.Black;
        public const ConsoleColor WaterHitForegroundColor = ConsoleColor.DarkBlue;

        public const ConsoleColor ShipNotHitForegroundColor = ConsoleColor.Yellow;
        public const ConsoleColor ShipHitForegroundColor = ConsoleColor.Red;

        public const char SegmentBorder = '*';

        public const char BattlefieldVerticalBorder = '|';
        public const char BattlefieldHorizontalBorder = '-';
        public const char BattlefieldCrossBorder = '+';

        public const char WaterNotHitSymbol = 'O';
        public const char HitSymbol = 'X';

        public const char HorizontalShipLeftEnd = '<';
        public const char HorizontalShipMiddle = '=';
        public const char HorizontalShipRightEnd = '>';

        public const char VerticalShipUpperEnd = '^';
        public const char VerticalShipMiddle = '|';
        public const char VerticalShipLowerEnd = 'v';

        public const int ConsoleDefaultHeight = 43;
        public const int ConsoleDefaultWidth = 62;

        public const int ConsoleViewDefaultHeight = 41;
        public const int ConsoleViewDefaultWidth = 60;

        public const int ConsoleViewDefaultStartingRow = 1;
        public const int ConsoleViewDefaultStartingCol = 1;

        public const int ConsoleViewMinHeight = 29;
        public const int ConsoleViewMinWidth = 44;

        public const int GameInfoSegmentMinHeight = 3;
        public const int GameInfoSegmentMinWidth = 30;
        public const int GameInfoSegmentDefaultHeight = 5;
        public const int GameInfoSegmentDefaultWidth = 60;

        public const int BattlefieldSegmentMinHeight = 22;
        public const int BattlefieldSegmentMinWidth = 22;
        public const int BattlefieldSegmentDefaultHeight = 30;
        public const int BattlefieldSegmentDefaultWidth = 30;

        public const int InOutSegmentMinHeight = 4;
        public const int InOutSegmentMinWidth = 30;
        public const int InOutSegmentDefaultHeight = 6;
        public const int InOutSegmentDefaultWidth = 60;

        public const string InOutSegmentInputPrompt = "Input:";
        public const string InOutSegmentOutputPrompt = "Output:";

        public static int GameInfoStartingRow => ConsoleViewDefaultStartingRow;
        public static int GameInfoStartingCol => ConsoleViewDefaultStartingCol;

        public static int PlayerBattlefieldStartingRow => GameInfoStartingRow + GameInfoSegmentDefaultHeight;
        public static int PlayerBattlefieldStartingCol => ConsoleViewDefaultStartingCol;

        public static int EnemyBattlefieldStartingRow => GameInfoStartingRow + GameInfoSegmentDefaultHeight;
        public static int EnemyBattlefieldStartingCol => ConsoleViewDefaultStartingCol + BattlefieldSegmentDefaultWidth;

        public static int InOutSegmentStartingRow => PlayerBattlefieldStartingRow + BattlefieldSegmentDefaultHeight;
        public static int InOutSegmentStartingCol => ConsoleViewDefaultStartingCol;
    }
}