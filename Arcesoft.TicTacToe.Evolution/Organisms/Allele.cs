using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    /// <summary>
    /// Represents a basic bit of information for a gene
    /// </summary>
    [Serializable]
    public enum Allele : int
    {
        DontCare = 0,
        Empty = 1,
        OccupiedAny = 2,
        OccupiedX = 3,
        OccupiedO = 4,
        Response = 5
    }
}
