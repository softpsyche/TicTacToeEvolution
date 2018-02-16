using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class MatchResult
    {
        public Match Match { get; set; }
        public double XScore { get; set; }
        public double OScore { get; set; }

        public bool HasScoreLedger => Ledger != null;
        public Ledger Ledger { get; set; }
    }
}
