using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.DependencyInjection
{
    internal class FactoryContainer : AssemblyContainer
    {
        public FactoryContainer(Container container) : base(container) { }
    }
}
