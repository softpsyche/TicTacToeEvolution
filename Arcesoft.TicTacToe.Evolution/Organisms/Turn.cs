using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    [Serializable]
    [Flags]
    public enum Turn : int
    {
        First = 0,
        Second = 2,
        Third = 4,
        Fourth = 8,
        Fifth = 16,
        Sixth = 32,
        Seventh = 64,
        Eigth = 128,
        Ninth = 256
    }
}
