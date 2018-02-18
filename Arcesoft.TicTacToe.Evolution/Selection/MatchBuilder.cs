using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class MatchBuilder: IMatchBuilder
    {
        private IRandom Random { get; set; }

        public MatchBuilder(IRandom random)
        {
            Random = random;
        }

        public List<Match> Build(IEnumerable<Individual> individuals, int tournaments)
        {
            //no matches..
            if (individuals?.Count() < 2)
            {
                throw new ArgumentException($"Unable to build tournament for null population or one with less than 2 individuals", nameof(individuals));
            }
            if (tournaments < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(tournaments), $"This value must be a number greater than or equal to 1");
            }

            //if the max tournaments exceeds what we can build, knock it down...
            if (tournaments >= individuals.Count())
            {
                tournaments = individuals.Count() - 1;
            }

            var matchList = new List<Match>();
            var individualMatchCount = new Dictionary<Individual, int>();
            individuals.ForEach(a => individualMatchCount.Add(a, 0));

            var iList = individuals.ToList();
            var removeList = new List<Individual>();

            while (iList.Count > 1)
            {
                var individual = iList.First();
                iList.Remove(individual);

                removeList.Clear();

                var individualTournamentCount = individualMatchCount[individual] == 0 ? 0 : individualMatchCount[individual] / 2;
                var opponentIndexes = Random.RandomNonRepeating(iList.Count, Math.Min(tournaments - individualTournamentCount, iList.Count));

                foreach (var opponentIndex in opponentIndexes)
                {
                    var opponent = iList[opponentIndex];

                    AddMatches(individual, opponent, matchList,individualMatchCount);

                    if (individualMatchCount[opponent] >= (tournaments * 2))
                    {
                        removeList.Add(opponent);
                    }
                }

                //remove opponents if they have been matched to max already...
                removeList.ForEach(a => iList.Remove(a));
            }

            //In some cases, individuals will be missing matches. We must supplement these individuals
            //up the minimum number of matches
            AddMissingMatches(individuals, tournaments, matchList,individualMatchCount);
            
            var expectedMatches = individuals.Count() * tournaments;
            if (matchList.Count < expectedMatches)
            {
                throw new Exception($"Unable to generate expected number of matches {expectedMatches}. This should never happen.");
            }

            return matchList.Distinct().ToList();
        }

        private void AddMissingMatches(IEnumerable<Individual> individuals, int tournaments, List<Match> matchList, Dictionary<Individual, int> individualMatchCount)
        {
            //the first dude with less than needed matches if any
            Func<Individual> findLowest = () => individualMatchCount
                .Where(a => a.Value < tournaments * 2)
                .OrderBy(a => a.Value)
                .FirstOrDefault()
                .Key;
            var lowestCountIndividual = findLowest();

            while (lowestCountIndividual != null)
            {
                var tournamentsMissing = individualMatchCount[lowestCountIndividual] == 0 ? tournaments : tournaments - (individualMatchCount[lowestCountIndividual] / 2);

                individualMatchCount
                    .Where(a => a.Key != lowestCountIndividual)//filter himself out
                    .Where(a => matchList.Any(b => b.PlayerX == lowestCountIndividual && b.PlayerO == a.Key) == false)//filter matches he already hass out.
                    .OrderBy(a => a.Value)
                    .Take(tournamentsMissing)
                    .ForEach(a => AddMatches(lowestCountIndividual, a.Key, matchList, individualMatchCount));

                lowestCountIndividual = findLowest();
            }
        }

        private void AddMatches(Individual a, Individual b, List<Match> matchList, Dictionary<Individual, int> individualMatchCount)
        {
            matchList.Add(new Match()
            {
                PlayerX = a,
                PlayerO = b
            });
            matchList.Add(new Match()
            {
                PlayerX = b,
                PlayerO = a
            });

            individualMatchCount[a] = individualMatchCount[a] + 2;
            individualMatchCount[b] = individualMatchCount[b] + 2;
        }
    }
}
