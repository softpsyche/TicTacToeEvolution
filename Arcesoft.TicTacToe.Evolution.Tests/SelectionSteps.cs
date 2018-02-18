using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Evolution.Selection;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;
using Arcesoft.TicTacToe.Evolution.Selection.Strategies;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    [Binding]
    public class SelectionSteps:Steps
    {
        [Given(@"I have a match builder")]
        public void GivenIHaveAMatchBuilder()
        {
            MatchBuilder = Container.GetInstance<MatchBuilder>();
        }

        [Given(@"I have the following individuals")]
        public void GivenIHaveTheFollowingIndividuals(Table table)
        {
            Individuals = table.CreateSetWithContainer<Individual>(Container).ToArray();
        }

        [When(@"I build matches with '(.*)' tournaments for my given individuals")]
        public void WhenIBuildMatchesWithTournamentsForMyGivenIndividuals(int p0)
        {
            Invoke(() => Matches = MatchBuilder.Build(Individuals, p0));
        }

        [Then(@"I expect all given individuals to have at least '(.*)' tournaments each")]
        public void ThenIExpectAllGivenIndividualsToHaveAtLeastTournamentsEach(int tournaments)
        {
            var matchCount = Matches.Count;

            Individuals.ForEach(a =>
            {
                var xCount = Matches.Count(b => b.PlayerX == a);
                var oCount = Matches.Count(b => b.PlayerO == a);

                xCount.Should().BeGreaterOrEqualTo(tournaments);
                oCount.Should().BeGreaterOrEqualTo(tournaments);
            });
        }

        [Then(@"I expect the number of matches to be at least '(.*)'")]
        public void ThenIExpectTheNumberOfMatchesToBeAtLeast(int p0)
        {
            Matches.Count.Should().BeGreaterOrEqualTo(p0);
        }


        [Given(@"I have '(.*)' individuals")]
        public void GivenIHaveIndividuals(int total)
        {
            List<Individual> listy = new List<Individual>();
            for (int i = 0; i < total; i++)
            {
                listy.Add(Container.GetInstance<Individual>());
            }

            Individuals = listy.ToArray();
        }

        [When(@"I repeat the test '(.*)' times using '(.*)' tournaments and '(.*)' individuals")]
        public void WhenIRepeatTheTestTimesUsingTournamentsAndIndividuals(int times, int tournaments,int individuals)
        {
            int errorCount = 0;

            for (int i = 0; i < times; i++)
            {
                try
                {
                    WhenIBuildMatchesWithTournamentsForMyGivenIndividuals(tournaments);
                    ThenIExpectAllGivenIndividualsToHaveAtLeastTournamentsEach(tournaments);
                    ThenIExpectTheNumberOfMatchesToBeAtLeast(tournaments * individuals);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);

                    errorCount++;
                }
            }

            errorCount.Should().Be(0);
        }

        [Given(@"I add a gene to individual '(.*)' for turn '(.*)' with priority '(.*)' and the following alleles")]
        public void GivenIAddAGeneToIndividualForTurnWithPriorityAndTheFollowingAlleles(string name, Turn turn, int priority, Table table)
        {
            var indy = Individuals.Single(a => a.Name.Equals(name));
            List<Gene> listy = new List<Gene>();
            listy.AddRange(indy.Genes);
            listy.Add(new Gene(turn, priority, table.ToAlleles().ToArray()));
            indy.Genes = listy;
        }

        [Given(@"I create matches for the following individuals")]
        public void GivenICreateMatchesForTheFollowingIndividuals(Table table)
        {
            var set = table.CreateDynamicSet();
            var matches = new List<Match>();

            foreach (var item in set)
            {
                matches.Add(new Match()
                {
                    PlayerX = Individuals.Single(a => a.Name == item.PlayerXName),
                    PlayerO = Individuals.Single(a => a.Name == item.PlayerOName),
                });
            }

            Matches = matches;
        }

        [Given(@"I have a match evaluator")]
        public void GivenIHaveAMatchEvaluator()
        {
            MatchEvaluator = Container.GetInstance<MatchEvaluator>();
        }


        [When(@"I evaluate the matches")]
        public void WhenIEvaluateTheMatches()
        {
            Invoke(() => Ledger = MatchEvaluator.Evaluate(Matches.ToArray()));
        }

        [Then(@"I expect the ledger to contain")]
        public void ThenIExpectTheLedgerToContain(Table table)
        {
            table.CompareToSet(Ledger.Entries);
        }

        [Given(@"I have a fitness evaluator of type '(.*)'")]
        public void GivenIHaveAFitnessEvaluatorOfType(FitnessEvaluatorType evaluatorType)
        {
            FitnessEvaluator = Container.GetInstance<AllOrNothingFitnessEvaluator>();
        }

        [Given(@"I have the following ledger")]
        public void GivenIHaveTheFollowingLedger(Table table)
        {
            Ledger = new Ledger()
            {
                Entries = table.CreateSet<LedgerEntry>().ToList()
            };
        }

        [When(@"I evaluate fitness")]
        public void WhenIEvaluateFitness()
        {
            Invoke(() => FitnessScores = FitnessEvaluator.Evaluate(Individuals, Ledger).ToList());
        }

        [Then(@"I expect the fitness scores to contain the following")]
        public void ThenIExpectTheFitnessScoresToContainTheFollowing(Table table)
        {
            var anonType = FitnessScores.Select(a => new { IndividualId = a.Individual.Id, a.Score,a.PercentageOfAllScores });

            table.CompareToSet(anonType);
        }



    }
}
