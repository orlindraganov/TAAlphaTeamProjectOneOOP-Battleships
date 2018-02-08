using System;
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

namespace StartUp
{
   public class DIModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandParser>().As<IParser>();
            builder.RegisterType<Ship>().As<IShip>();
            builder.RegisterType<BattleShipFactory>().As<IBattleShipFactory>();
            builder.RegisterType<ConsoleReader>().As<IReader>();
            builder.RegisterType<ConsoleWriter>().As<IWriter>();
            builder.RegisterType<ConsoleView>().As<IView>();

            builder.RegisterType<Engine>().As<IEngine>();



        }
    } 
}
