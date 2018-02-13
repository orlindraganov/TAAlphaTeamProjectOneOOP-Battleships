using System;
using Battleships.BattleShipsEngine;
using Battleships.Enums;
using Battleships.Models;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;
using Battleships.View;
using Battleships.View.Contracts;
using Autofac;
using Battleships.BattleShipsEngine.Contracts;
using System.Reflection;
using Battleships.View.Common;

namespace StartUp
{
    internal class StartUp
    {
        private static void Main()
        {
            //BattleShipsEngine.Instance.Start();
            //var v = new ConsoleView();
            //v.Update();
            //v.WriteLine("Just empty... Let's add players");
            //v.ReadLine();

            //var p1 = new Player("Pesho");
            //var p2 = new Player("Gosho");

            //v.SelectParticipants(p1, p2);
            //v.Update();


            //v.WriteLine("Now to add healthy ships to both players");
            //v.ReadLine();
            //var s1 = new Frigate(new Position(3, 3), Direction.Down);
            //var s2 = new Frigate(new Position(3, 3), Direction.Down);

            //p1.AddShip(s1);
            //p2.AddShip(s2);
            //v.Update();

            //var s3 = new AircraftCarrier(new Position(4, 4), Direction.Right);
            //var s4 = new AircraftCarrier(new Position(4, 4), Direction.Right);

            //p1.AddShip(s3);
            //p2.AddShip(s4);
            //v.Update();

            //v.WriteLine("Let's hit an element!");
            //v.ReadLine();
            //var pos = new Position(4, 3);
            //p1.Battlefield[pos].GetHit();
            //p2.Battlefield[pos].GetHit();
            //v.Update();


            //v.WriteLine("Note that the health changed? Let's hit another");
            //v.ReadLine();

            //pos.Row++;
            //pos.Row++;
            //p2.Battlefield[pos].GetHit();

            //v.Update();
            //v.WriteLine("Cool huh? How about a miss");
            //v.ReadLine();
            //pos = new Position(2, 2);
            //p1.Battlefield[pos].GetHit();
            //p2.Battlefield[pos].GetHit();
            //v.Update();
            Console.SetWindowSize(ViewSettings.ConsoleDefaultWidth, ViewSettings.ConsoleDefaultHeight);
            Console.SetBufferSize(ViewSettings.ConsoleDefaultWidth, ViewSettings.ConsoleDefaultHeight);

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();

            var v = container.Resolve<IView>();

            engine.Started += () => v.DrawBorders();
            engine.Started += () => v.WriteLine("Engine strted");
            engine.Start();
        }
    }
}