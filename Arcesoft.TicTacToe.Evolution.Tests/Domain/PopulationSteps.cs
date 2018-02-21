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

namespace Arcesoft.TicTacToe.Evolution.Tests.Domain
{
    [Binding]
    internal class PopulationSteps : Steps
    {
        [Given(@"I have a population")]
        public void GivenIHaveAPopulation()
        {
            Population = EvolutionFactory.CreatePopulation(PopulationSettings);
        }

        [Given(@"I have the following population")]
        public void GivenIHaveTheFollowingPopulation(Table table)
        {
            Population = EvolutionFactory.CreatePopulation(PopulationSettings);

            table.FillInstance(Population);
        }

        [Given(@"I delete the following populations")]
        public void GivenIDeleteTheFollowingPopulations(Table table)
        {
            var set = table.CreateDynamicSet();

            set.ForEach(a => DataAccess.DeletePopulation(new Guid(a.Id)));
        }

        [Given(@"I evolve the population '(.*)' times")]
        [When(@"I evolve the population '(.*)' times")]
        public void WhenIEvolveThePopulationTimes(int cycles)
        {
            Invoke(() => Population.Evolve(cycles));
        }

        [Given(@"I add an individual called '(.*)' with id '(.*)' and with the following genes to my population")]
        public void GivenIAddAnIndividualCalledWithIdAndWithTheFollowingGenesToMyPopulation(string name, Guid id, Table table)
        {
            Invoke(() =>
            {
                Individual = EvolutionFactory.CreateIndividual(0);
                Individual.Name = name;
                Individual.Id = id;

                Individual.Genes = table.ToGenes();

                Population.AddIndividuals(new[] { Individual });
            });
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


    }
}
