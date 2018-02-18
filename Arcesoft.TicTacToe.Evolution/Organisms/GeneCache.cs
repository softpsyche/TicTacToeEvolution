using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    public class GeneCache
    {
        //for now this does nothing but later on we can use this to effectively 
        public Gene CreateOrGet(Turn turn, Int32 priority, Allele[] alleles)
        {
            return new Gene(turn, priority, alleles);
        }
    }
}
