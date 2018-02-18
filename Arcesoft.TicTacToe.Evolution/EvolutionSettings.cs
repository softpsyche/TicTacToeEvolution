using Arcesoft.TicTacToe.Evolution.Mutations;
using Arcesoft.TicTacToe.Evolution.Reproduction;
using Arcesoft.TicTacToe.Evolution.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
    public class EvolutionSettings : IMutationSettings, IReproductionSettings,IFitnessSettings
    {
        public double MutationRate { get; set; }

        public int MaximumPopulationSize { get; set; }

        public int IndividualChildBearingLimit { get; set; }

        public int MaximumGenesPerIndividual { get; set; }

        public BreederType BreederType { get; set; }

        public FitnessEvaluatorType FitnessEvaluatorType { get; set; }

        public int MatchTournaments { get; set; }
    }
}
