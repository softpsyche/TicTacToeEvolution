using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection.Strategies
{
    /// <summary>
    /// Use only total wins as our scoring mechanism
    /// </summary>
    public class AllOrNothingFitnessEvaluator : IFitnessEvaluator
    {
        public IEnumerable<FitnessScore> Evaluate(IEnumerable<Individual> individuals, Ledger ledger)
        {
            //just the wins is all we care about here...
            return individuals
                .Join(
                    ledger.Entries.GroupBy(a => a.IndividualId),
                    a => a.Id,
                    a => a.Key,
                    (Individual, Entries) => new FitnessScore()
                    {
                        Individual = Individual,
                        Score = 1D - Entries.LossRatio()
                    }
                    );
        }
    }
}
