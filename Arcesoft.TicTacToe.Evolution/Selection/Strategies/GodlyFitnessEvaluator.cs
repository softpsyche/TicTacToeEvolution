using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection.Strategies
{
    internal class GodlyFitnessEvaluator : IFitnessEvaluator
    {
        private ITicTacToeFactory TicTacToeFactory { get; set; }
        private IMatchEvaluator MatchEvaluator { get; set; }

        private IArtificialIntelligence _artificialIntelligence;
        private IArtificialIntelligence ArtificialIntelligence
        {
            get
            {
                if (_artificialIntelligence == null)
                {
                    _artificialIntelligence = TicTacToeFactory.NewArtificialIntelligence(ArtificialIntelligenceTypes.LightningGod);
                }

                return _artificialIntelligence;
            }
        }

        public GodlyFitnessEvaluator(ITicTacToeFactory ticTacToeFactory, IMatchEvaluator matchEvaluator)
        {
            TicTacToeFactory = ticTacToeFactory;
            MatchEvaluator = matchEvaluator;
        }

        public IEnumerable<FitnessScore> Evaluate(IEnumerable<Individual> individuals, IFitnessSettings settings)
        {
            //build the matches...
            var matches = individuals.Select(a => new Match() {PlayerX = a, PlayerO = ArtificialIntelligence }).ToList();
            matches.AddRange(individuals.Select(a => new Match() { PlayerX = ArtificialIntelligence, PlayerO = a }));

            //evaluate the matches..
            var ledger = MatchEvaluator.Evaluate(matches);

            //get the scores for this ledger
            return GetScores(individuals, ledger);
        }

        private IEnumerable<FitnessScore> GetScores(IEnumerable<Individual> individuals, Ledger ledger)
        {
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
