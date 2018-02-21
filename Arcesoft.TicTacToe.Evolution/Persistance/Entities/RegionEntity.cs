using Arcesoft.TicTacToe.Evolution.Environs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance.Entities
{
    internal class RegionEntity
    {
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public long Age { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public RegionSettings Settings { get; set; }

        public Guid[] PopulationIds { get; set; }
    }
}
