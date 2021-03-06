﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public interface IMatchEvaluator
    {
        Ledger Evaluate(IEnumerable<Match> matches);
    }
}
