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
        private IMatchBuilder MatchBuilder { get; set; }
        private IMatchEvaluator MatchEvaluator { get; set; }

        public AllOrNothingFitnessEvaluator(IMatchBuilder matchBuilder, IMatchEvaluator matchEvaluator)
        {
            MatchBuilder = matchBuilder;
            MatchEvaluator = matchEvaluator;
        }

        public IEnumerable<FitnessScore> Evaluate(IEnumerable<Individual> individuals, IFitnessSettings settings)
        {
            //create the matches
            var matches = MatchBuilder.Build(individuals, settings.MatchTournaments);

            //evaluate matches and dump results to a ledger
            var ledger = MatchEvaluator.Evaluate(matches.ToArray());

            //just the wins is all we care about here...
            //extract from the ledger to build the scores
            var scores = individuals
                .Join(
                    ledger.Entries.GroupBy(a => a.IndividualId),
                    a => a.Id,
                    a => a.Key,
                    (Individual, Entries) => new FitnessScore()
                    {
                        Individual = Individual,
                        Score = 1D - Entries.LossRatio()
                    }
                    ).ToList();

            var scoreTotal = scores.Sum(a => a.Score);
            //should never happen but hey...wtf..code defensively, I always say
            if (scoreTotal == 0)
            {
                scores.ForEach(a => a.PercentageOfAllScores = Math.Round(1D / scores.Count(), 6));
            }
            else
            {
                scores.ForEach(a => a.PercentageOfAllScores = Math.Round(a.Score / scoreTotal, 6));
            }

            return scores;
        }

    }
}
