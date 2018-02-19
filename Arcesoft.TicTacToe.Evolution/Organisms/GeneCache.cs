using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    /// <summary>
    /// This class is threadsafe.
    /// </summary>
    internal class GeneCache : IGeneCache
    {
        //for now this does nothing but later on we can use this to effectively 
        public Gene CreateOrGet(Turn turn, Int32 priority, Allele[] alleles)
        {
            return new Gene(turn, priority, alleles);
        }
    }
}
