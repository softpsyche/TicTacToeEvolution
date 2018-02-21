using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Moq;
using TechTalk.SpecFlow.Assist;
using Arcesoft.TicTacToe.Evolution.Persistance;
using Arcesoft.TicTacToe.Evolution.Organisms;
using FluentAssertions;

namespace Arcesoft.TicTacToe.Evolution.Tests.Integration
{
    [Binding]
    internal class PersistenceSteps : Steps
    {
        [Given(@"I have a data access")]
        public void GivenIHaveADataAccess()
        {
            DataAccess = Container.GetInstance<IDataAccess>();
        }

        [Given(@"I clear all individuals from my population")]
        public void GivenIClearAllIndividualsFromMyPopulation()
        {
            Population.AddIndividuals(Enumerable.Empty<Individual>(), true);
        }

        [Given(@"I save my population")]
        public void GivenISaveMyPopulation()
        {
            Invoke(() => DataAccess.SavePopulation(Population));
        }

        [Given(@"I save my populations")]
        public void GivenISaveMyPopulations()
        {
            Invoke(() => Populations.ForEach(a=> DataAccess.SavePopulation(a)));
        }


        [Then(@"I expect the saved population to contain the following individuals")]
        public void ThenIExpectTheSavedPopulationToContainTheFollowingIndividuals(Table table)
        {
            var loadedPopulation = DataAccess.TryFindPopulation(Population.Id);

            var projectedIndividuals = loadedPopulation
                .Individuals.SelectMany(a => a.Genes, (individual, gene) => new
                {
                    individual.Id,
                    individual.Name,
                    gene.Priority,
                    gene.Turn,
                    Alleles = gene.GetAlleles().ToAlleleString()
                }).ToList();

            table.CompareToSet(projectedIndividuals);
        }

        [Then(@"I expect the saved population to contain")]
        public void ThenIExpectTheSavedPopulationToContain(Table table)
        {
            var loadedPopulation = DataAccess.TryFindPopulation(Population.Id);

            table.CompareToInstance(loadedPopulation);
        }

        [Then(@"I expect the saved population to contain the following evolution settings")]
        public void ThenIExpectTheSavedPopulationToContainTheFollowingEvolutionSettings(Table table)
        {
            var loadedPopulation = DataAccess.TryFindPopulation(Population.Id);

            table.CompareToInstance(loadedPopulation.Settings);
        }

        [Given(@"I have the following populations")]
        public void GivenIHaveTheFollowingPopulations(Table table)
        {
            Populations = table.ToPopulations(EvolutionFactory, PopulationSettings);
        }

        [When(@"I find populations by name '(.*)'")]
        public void WhenIFindPopulationsByName(string name)
        {
            Invoke(() => PopulationSearchResults = DataAccess.FindPopulations(name));
        }

        [Then(@"I expect the find populations search results to only contain")]
        public void ThenIExpectTheFindPopulationsSearchResultsToOnlyContain(Table table)
        {
            table.CompareToSet(PopulationSearchResults);

            PopulationSearchResults.Count.Should().Be(table.RowCount);
        }

        [Given(@"I delete all individuals")]
        public void GivenIDeleteAllIndividuals()
        {
            DataAccess.DeleteAllPopulations();
        }

    }
}
