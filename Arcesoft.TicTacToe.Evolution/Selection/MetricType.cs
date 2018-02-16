using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    [Serializable]
    public enum MetricType
    {

        Moved = 0,
        LostDueToNoMoves,
        LostDueToInvalidMove,
        Lost,
        WonDueToNoMoves,
        WonDueToInvalidMove,
        Won,
        Tied
    }
}
