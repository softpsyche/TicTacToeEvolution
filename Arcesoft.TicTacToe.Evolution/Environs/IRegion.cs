using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Environs
{
    public interface IRegion
    {
        Guid Id { get; }

        string Name { get; set; }

        long Age { get; }

        DateTimeOffset DateCreated { get;}

        RegionSettings Settings { get; set; }

        IEnumerable<IPopulation> Populations { get; }
    }
}
