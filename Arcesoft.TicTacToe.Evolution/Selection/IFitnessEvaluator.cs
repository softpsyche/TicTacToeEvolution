﻿using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public interface IFitnessEvaluator
    {
        IEnumerable<FitnessScore> Evaluate(IEnumerable<Individual> individuals, IFitnessSettings settings);
    }
}
