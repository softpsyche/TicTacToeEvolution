﻿using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class FitnessScore
    {
        public Individual Individual { get; set; }
        public double Score { get; set; }
        public double PercentageOfAllScores { get; set; }

        public override string ToString()
        {
            return $"{PercentageOfAllScores.ToString("P", CultureInfo.InvariantCulture)} - ({Individual})";
        }
    }
}
