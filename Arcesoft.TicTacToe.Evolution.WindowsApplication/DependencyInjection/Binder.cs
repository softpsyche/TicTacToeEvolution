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

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.DependencyInjection
{
    public class Binder : IBinder
    {
        public void BindDependencies(Container container)
        {
            //for internal stuff
            container.RegisterSingleton(new FactoryContainer(container));          
        }
    }
}
