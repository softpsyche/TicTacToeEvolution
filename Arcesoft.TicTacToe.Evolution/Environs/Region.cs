using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Environs
{
    internal class Region : IRegion
    {
        public Guid Id { get; internal set; } = Guid.NewGuid();

        public string Name { get; set; }
    }
}
