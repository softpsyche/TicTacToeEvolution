using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Arcesoft.TicTacToe.Evolution.Mutations;
using Arcesoft.TicTacToe.Evolution.Selection;
using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Evolution.Persistance;
using Arcesoft.TicTacToe.Evolution.Persistance.Repositories;

namespace Arcesoft.TicTacToe.Evolution.DependencyInjection
{
    public class Binder : IBinder
    {
        public void BindDependencies(Container container)
        {
            //for internal stuff
            container.RegisterSingleton(new FactoryContainer(container));
            container.Register<IInternalEvolutionFactory, EvolutionFactory>();

            //mutations
            container.Register<IMutator, Mutator>();

            //organisms
            container.RegisterSingleton<IGeneCache, GeneCache>();

            //reproduction

            //selection
            container.Register<IMatchBuilder, MatchBuilder>();
            container.Register<IMatchEvaluator, MatchEvaluator>();

            //persistance
            container.Register<IRegionRepository, RegionRepository>();
            container.Register<IPopulationRepository, PopulationRepository>();
            container.Register<IDataAccess, DataAccess>();

            //public
            container.Register<IEvolutionFactory, EvolutionFactory>();
            
        }
    }
}
