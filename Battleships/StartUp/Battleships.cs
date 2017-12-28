using System;
using System.Collections.Generic;
using Battleships.BattleShipsEngine;
using Battleships.Enums;
using Battleships.Models;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.View;

namespace StartUp
{
    internal class StartUp
    {
        private static void Main()
        {
            //BattleShipsEngine.Instance.Start();
            Console.SetWindowSize(120, 45);
            Console.SetBufferSize(120, 45);

            var h = new GameInfoSegment(5, 5, 10, 60);

            h.GameInfo = "Slava aleluq it works!";
            h.Update();

            var v = new BattlefieldSegment(10, 30, 10, 30);

            var m = new IGameObjectElement[10, 10];

            var b = new Battlefield(m);

            var el = new List<IGameObjectElement>();

            for (int i = 0; i < 3; i++)
            {
                el.Add(new Element(false, GameObjectElementType.Ship, new Position(3 + i, 3)));
            }
            var s = new Frigate(el, Direction.Down);

            el.Clear();

            for (int i = 0; i < 5; i++)
            {
                el.Add(new Element(false, GameObjectElementType.Ship, new Position(5, 5+i)));
            }

            el[3].IsHit = true;

            var s1 = new Frigate(el, Direction.Right);

            v.DrawBattleField(b);
            v.WriteIndexesOnBattlefield();
            v.DrawShip(s);
            v.DrawShip(s1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, Console.BufferHeight -1);
            //Console.WriteLine($"W: {Console.BufferWidth} {Console.WindowWidth} H: {Console.BufferHeight} {Console.WindowHeight}");
            //Console.WriteLine();
        }
    }
}