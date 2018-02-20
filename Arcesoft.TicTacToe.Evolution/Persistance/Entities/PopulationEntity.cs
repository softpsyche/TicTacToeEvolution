using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance.Entities
{
    internal class PopulationEntity
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public long Generation { get; set; }

        public PopulationSettings Settings { get; set; }
        public IndividualEntity[] Individuals { get; set; }

    }
}
