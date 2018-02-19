using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Organisms;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    [Binding]
    internal class OrganismsSteps : Steps
    {
        [Given(@"I have an individual")]
        public void GivenIHaveAnIndividual()
        {
            Individual = EvolutionFactory.CreateIndividual(0);
        }

        [When(@"I set the following genes on the individual")]
        public void WhenISetTheFollowingGenesOnTheIndividual(Table table)
        {
            Invoke(() => Individual.Genes = table.ToGenes());
        }

        [Then(@"The individual should contain the following genes")]
        public void ThenTheIndividualShouldContainTheFollowingGenes(Table table)
        {
            Individual.Genes.ShouldAllBeEquivalentTo(table.ToGenes());
        }

        [Given(@"I have an individual with the following genes")]
        public void GivenIHaveAnIndividualWithTheFollowingGenes(Table table)
        {
            Invoke(() =>
            {
                Individual = EvolutionFactory.CreateIndividual(0);

                Individual.Genes = table.ToGenes();
            });
        }

        [When(@"I make '(.*)' copies of the individual")]
        public void WhenIMakeCopiesOfTheIndividual(int p0)
        {
            Invoke(() => IndividualCopies = Individual.Copy(p0));
        }

        [Then(@"All individual copies should contain the following genes")]
        public void ThenAllIndividualCopiesShouldContainTheFollowingGenes(Table table)
        {
            var expected = table.ToGenes();

            IndividualCopies.ForEach(a => a.Genes.ShouldAllBeEquivalentTo(expected));
        }

        [Then(@"There should be exactly '(.*)' individual copies")]
        public void ThenThereShouldBeExactlyIndividualCopies(int p0)
        {
            IndividualCopies.Count().Should().Be(p0);
        }

        [Given(@"I have a new game in the following state")]
        public void GivenIStartANewGameInTheFollowingState(Table table)
        {
            Invoke(() => Game = TicTacToeFactory.NewGame(table.ToPlausibleMoveList()));
        }

        [Given(@"I add a gene to my individual for turn '(.*)' with priority '(.*)' and the following alleles")]
        public void GivenIAddAGeneToMyIndividualForTurnWithPriorityAndTheFollowingAlleles(Turn turn, int priority, Table table)
        {
            List<Gene> listy = new List<Gene>();
            listy.AddRange(Individual.Genes);
            listy.Add(new Gene(turn,priority, table.ToAlleles().ToArray()));
            Individual.Genes = listy;
        }


        [When(@"I try to find a move for the current game with my individual")]
        public void WhenITryToFindAMoveForTheCurrentGameWithMyIndividual()
        {
            Invoke(() => Move = Individual.TryFindMove(Game));
        }

        [Then(@"I expect the move to be '(.*)'")]
        public void ThenIExpectTheMoveToBe(Move move)
        {
            Move.Should().Be(move);
        }

        [Then(@"I expect the move to be null")]
        public void ThenIExpectTheMoveToBeNull()
        {
            Move.Should().BeNull();
        }


        [When(@"I find responses for the current game with my individual")]
        public void WhenIFindResponsesForTheCurrentGameWithMyIndividual()
        {
            Invoke(() => Responses = Individual.FindResponses(Game));
        }

        [Then(@"I expect the responses to contain in the following order")]
        public void ThenIExpectTheResponsesToContainInTheFollowingOrder(Table table)
        {
            Responses.Should().ContainInOrder(table.ToMoves());
        }



    }
}
