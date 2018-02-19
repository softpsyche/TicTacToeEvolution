using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    internal interface IGeneCache
    {
        Gene CreateOrGet(Turn turn, Int32 priority, Allele[] alleles);
    }
}
