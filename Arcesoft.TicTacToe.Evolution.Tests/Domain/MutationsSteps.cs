using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Moq;
using FluentAssertions;
using Arcesoft.TicTacToe.Evolution.Mutations;
using TechTalk.SpecFlow.Assist;
using Arcesoft.TicTacToe.Evolution.Organisms;

namespace Arcesoft.TicTacToe.Evolution.Tests.Domain
{
    [Binding]
    internal class MutationsSteps : Steps
    {
        [Given(@"I have a mutator")]
        public void GivenIHaveAMutator()
        {
            Mutator = Container.GetInstance<Mutator>();
        }

        [Given(@"I have the following population settings")]
        public void GivenIHaveTheFollowingMutationSettings(Table table)
        {
            PopulationSettings = table.CreateInstance<PopulationSettings>();
        }

        [When(@"I mutate my given individual")]
        public void WhenIMutateMyGivenIndividual()
        {
            Invoke(() => Mutator.MutateIndividual(Individual, PopulationSettings));
        }

        [Then(@"I expect the individual to not contain any of the following genes")]
        public void ThenIExpectTheIndividualToNotContainAnyOfTheFollowingGenes(Table table)
        {
            Individual.Genes.Should().NotContain(table.ToGenes());
        }
        [Then(@"I expect the individual to contain the following genes")]
        public void ThenIExpectTheIndividualToContainTheFollowingGenes(Table table)
        {
            Individual.Genes.Should().Contain(table.ToGenes());
        }

        [Then(@"I expect the individual to contain '(.*)' genes")]
        public void ThenIExpectTheIndividualToContainGenes(int count)
        {
            Individual.Genes.Count().Should().Be(count);
        }
    }
}
