using System;
using System.Collections.Generic;
using Battleships.BattleShipsEngine;
using Battleships.Enums;
using Battleships.Models;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.View;
using Battleships.View.Common;

namespace StartUp
{
    internal class StartUp
    {
        private static void Main()
        {
            //BattleShipsEngine.Instance.Start();
            var width = 120;
            var height = 45;

            if (width > Console.LargestWindowWidth || height > Console.LargestWindowHeight)
            {
                throw new ConsoleFontTooLargeException("Your console font size is too large, please decrease it from Properties");
            }

            Console.SetWindowSize(120, 60);
            Console.SetBufferSize(120, 60);

            var h = new GameInfoSegment(5, 5, 10, 60);

            h.GameInfo = "Slava aleluq it works!";
            h.Update();

            var v1 = new PlayerBattlefieldSegment(10, 30, 10, 30);

            var m = new IGameObjectElement[10, 10];

            var b = new Battlefield(m);

            var s = new Frigate(new Position(2, 2), Direction.Down);

            var s1 = new Frigate(new Position(4, 4), Direction.Right);

            var v2 = new EnemyBattlefieldSegment(10,30,40,30);

            var io = new InOutSegment(40, 6, 10, 60);

            s1.Elements[1].IsHit = true;

            v1.DrawBattleField(b);
            v1.WriteIndexesOnBattlefield();
            v1.DrawShip(s);
            v1.DrawShip(s1);

            v2.DrawBattleField(b);
            v2.WriteIndexesOnBattlefield();
            v2.DrawShip(s);
            v2.DrawShip(s1);

            string message = string.Empty;

            io.WriteLine("Write your message");

            while (message != "exit")
            {
                message = io.ReadLine();
                io.WriteLine(message);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, Console.BufferHeight - 1);
        }
    }
}