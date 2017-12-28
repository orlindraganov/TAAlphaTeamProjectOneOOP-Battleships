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
            Console.SetWindowSize(45, 45);
            Console.SetBufferSize(45, 45);

            var v = new BattlefieldSegment(10, 30, 10, 30);

            var m = new IGameObjectElement[10, 10];

            var b = new Battlefield(m);

            var el = new List<IGameObjectElement>();

            for (int i = 0; i < 3; i++)
            {
                el.Add(new Element(false, GameObjectElementType.Ship, new Position(3,3+i)));
            }

            var s = new Frigate(el, Direction.Down);

            v.DrawBattleField(b);
            v.DrawShip(s);

        }
    }
}