﻿using System;

namespace Battleships.View.Common
{
    public static class Constants
    {
        public const int ConsoleDefaultHeight = 45;
        public const int ConsoleDefaultWidth = 60;

        public const ConsoleColor ConsoleDefaultBackgroundColor = ConsoleColor.DarkBlue;
        public const ConsoleColor ConsoleDefaultForegroundColor = ConsoleColor.White;
        public const ConsoleColor ConsoleDefaultBorderColor = ConsoleColor.DarkGray;

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

        public const char NotHitSymbol = 'O';
        public const char HitSymbol = 'X';

        public const char HorizontalShipLeftEnd = '<';
        public const char HorizontalShipMiddle = '=';
        public const char HorizontalShipRightEnd = '>';

        public const char VerticalShipUpperEnd = '^';
        public const char VerticalShipMiddle = '|';
        public const char VerticalShipLowerEnd = 'v';

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
        public const int InOutSegmentDefaultHeight = 10;
        public const int InOutSegmentDefaultWidth = 60;
    }
}
