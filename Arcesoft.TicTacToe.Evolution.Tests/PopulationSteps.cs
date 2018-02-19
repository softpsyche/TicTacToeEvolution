using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Moq;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;
using Arcesoft.TicTacToe.Evolution.Environs;
using FluentAssertions;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    [Binding]
    internal class PopulationSteps : Steps
    {
        [Given(@"I have a population")]
        public void GivenIHaveAPopulation()
        {
            Population = EvolutionFactory.CreatePopulation(EvolutionSettings);
        }

        [When(@"I evolve the population '(.*)' times")]
        public void WhenIEvolveThePopulationTimes(int cycles)
        {
            Invoke(() => Population.Evolve(cycles));
        }

        [Given(@"I have an individual called '(.*)' with id '(.*)' and with the following genes")]
        public void GivenIHaveAnIndividualCalledWithIdAndWithTheFollowingGenes(string name, Guid id, Table table)
        {
            Invoke(() =>
            {
                Individual = EvolutionFactory.CreateIndividual(0);
                Individual.Name = name;
                Individual.Id = id;

                Individual.Genes = table.ToGenes();
            });
        }

        [Given(@"I add my individual to the population")]
        public void GivenIAddMyIndividualToThePopulation()
        {
            Population.AddIndividuals(new[] { Individual });
        }

        [Then(@"I expect the population to contain '(.*)' individuals with parent ids '(.*)' and the following genes")]
        public void ThenIExpectThePopulationToContainIndividualsWithParentIdsAndTheFollowingGenes(int count, string parentIds, Table table)
        {
            var subset = Population.Individuals.Where(a => a.ToParentIdsString() == parentIds).ToList();

            subset.Count.Should().Be(count);

            subset.ForEach(a => a.Genes.Should().Contain(table.ToGenes()));
        }

        [Then(@"I expect the entire population to contain the following genes")]
        public void ThenIExpectTheEntirePopulationToContainTheFollowingGenes(Table table)
        {
            Population.Individuals.ForEach(a => a.Genes.Should().Contain(table.ToGenes()));
        }


        [When(@"I have lots of fun")]
        public void WhenIHaveLotsOfFun()
        {
            while (true)
            {
                Population.Evolve(100);

                var yo = 34;

            }
        }


    }
}
