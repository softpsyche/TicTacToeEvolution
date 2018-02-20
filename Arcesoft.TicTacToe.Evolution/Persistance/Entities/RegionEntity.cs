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

        public DateTimeOffset DateCreated { get; set; }
    }
}
