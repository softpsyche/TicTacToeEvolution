using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Arcesoft.TicTacToe.Evolution.Mutations;

namespace Arcesoft.TicTacToe.Evolution.DependencyInjection
{
    public class Binder : IBinder
    {
        public void BindDependencies(Container container)
        {
            //general
            container.RegisterSingleton(new FactoryContainer(container));

            //mutations
            container.Register<IMutator, Mutator>();

            //organisms
        }
    }
}
