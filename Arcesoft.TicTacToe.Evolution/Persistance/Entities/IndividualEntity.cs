using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance.Entities
{
    internal class IndividualEntity
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid[] ParentIds { get; set; }
        public String[] Genes { get; set; }
    }
}
