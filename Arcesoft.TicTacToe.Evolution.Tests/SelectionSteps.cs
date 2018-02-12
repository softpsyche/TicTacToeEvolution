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

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    [Binding]
    public class SelectionSteps:Steps
    {
        protected MatchBuilder MatchBuilder
        {
            get
            {
                return GetScenarioContextItemOrDefault<MatchBuilder>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Individual[] Individuals
        {
            get
            {
                return GetScenarioContextItemOrDefault<Individual[]>(nameof(Individuals));
            }
            set
            {
                CurrentContext.Set(value,nameof(Individuals));
            }
        }

        protected List<Match> Matches
        {
            get
            {
                return GetScenarioContextItemOrDefault<List<Match>>(nameof(Matches));
            }
            set
            {
                CurrentContext.Set(value, nameof(Matches));
            }
        }

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





    }
}
