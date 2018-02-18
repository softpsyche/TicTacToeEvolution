using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe
{
    /// <summary>
    /// Defines a common interface for container registrations
    /// </summary>
    public interface IBinder
    {
        /// <summary>
        /// Bind dependencies for given container
        /// </summary>
        /// <param name="container"></param>
        void BindDependencies(Container container);
    }
}
