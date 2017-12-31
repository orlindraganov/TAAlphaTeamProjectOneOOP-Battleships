using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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

            
            var p1 = new Player("Pesho");
            var p2 = new Player("Gosho");

            var v = new View(p1,p2);
            v.Update();
            

            v.WriteLine("Now to add a healthy ship to both players");
            v.ReadLine();
            var s1 = new Frigate(new Position(3, 3), Direction.Down);
            
            p1.AddShip(s1);
            p2.AddShip(s1);
            v.Update();

            v.WriteLine("Also a hit ship...");
            v.ReadLine();
            var s2 = new AircraftCarrier(new Position(4, 4), Direction.Right);
            s2.Elements[1].IsHit = true;
            p1.AddShip(s2);
            p2.AddShip(s2);
            v.Update();

            v.WriteLine("Ooops, let's miss!");
            v.ReadLine();
            var pos = new Position(2,2);
            p1.Battlefield[pos].GetHit();
            p2.Battlefield[pos].GetHit();
            v.Update();

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

           // var engine = Engine.Instance;
           //
           // engine.OnStart += () => Console.WriteLine("Engine strted");
           // 
           //
           // engine.Start();
        }
    }
}