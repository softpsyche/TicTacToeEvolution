using Arcesoft.TicTacToe.Evolution.Mutations;
using Arcesoft.TicTacToe.Evolution.Reproduction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
    public class EvolutionSettings : IMutationSettings, IReproductionSettings
    {
        public double MutationRate { get; set; }

        public int MaximumPopulationSize { get; set; }

        public int IndividualChildBearingLimit { get; set; }
    }
}
