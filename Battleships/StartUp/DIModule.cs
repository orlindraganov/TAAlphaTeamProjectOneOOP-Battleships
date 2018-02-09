﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Battleships.BattleshipsEngine;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.Models.Contracts;
using Battleships.Models;
using Battleships.Factory;
using Battleships.BattleShipsEngine;
using Battleships.BattleShipsEngine.Contracts;
using Battleships.BattleshipsEngine.Providers;
using Battleships.View;
using Battleships.View.Contracts;
using Battleships.Commands;

namespace StartUp
{
    public class DIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();

            builder.RegisterAssemblyTypes(typeof(Ship).Assembly)
                .Where(t => t.IsSubclassOf(typeof(Ship)))
                .As<Ship>();

            //builder.Register(c => new Player("name")).As<IPlayer>();
            builder.RegisterType<BattleShipFactory>().As<IBattleShipFactory>();
            builder.RegisterType<Player>().As<IPlayer>().WithParameter(new TypedParameter(typeof(string),"name"));

            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<ConsoleView>().As<IView>();
            builder.RegisterType<Battlefield>().As<IBattlefield>();
            builder.RegisterType<GameObjectElement>().As<IGameObjectElement>();
            builder.RegisterType<Water>().As<IWater>();





            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<BeginPlayCommand>().Named<ICommand>("Start");
            builder.RegisterType<CreateAircraftCarrierCommand>().Named<ICommand>("CreateAircraftCarrier");
            builder.RegisterType<CreateBattleCruiserCommand>().Named<ICommand>("CreateBattleCruiser");
            builder.RegisterType<CreateDestroyerCommand>().Named<ICommand>("CreateDestroyer");
            builder.RegisterType<CreateFrigateCommand>().Named<ICommand>("CreateFrigate");
            builder.RegisterType<CreatePlayerCommand>().Named<ICommand>("CreatePlayer");
            builder.RegisterType<CreateSubmarineCommand>().Named<ICommand>("CreateSubMarine");
            builder.RegisterType<FireAtCommand>().Named<ICommand>("FireAt");





        }
    }
}
