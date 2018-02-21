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
using Arcesoft.TicTacToe.Evolution.Environs;

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
        [When(@"I save my population")]
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

        [Given(@"I evolve the populations '(.*)' times")]
        public void GivenIEvolveThePopulationsTimes(int p0)
        {
            Populations.ForEach(a => a.Evolve(p0));
        }

        [Given(@"I have the following region settings")]
        public void GivenIHaveTheFollowingRegionSettings(Table table)
        {
            RegionSettings = table.CreateInstance<RegionSettings>();
        }

        [Given(@"I have the following regions")]
        public void GivenIHaveTheFollowingRegions(Table table)
        {
            Regions = table.ToRegions(EvolutionFactory, RegionSettings).ToList();
        }

        [Given(@"I add the following given populations to region '(.*)'")]
        public void GivenIAddTheFollowingGivenPopulationsToRegion(Guid id, Table table)
        {
            var populationsToAdd = table
                .CreateDynamicSet()
                .Select(a => new Guid(a.Id))
                .Join(Populations, a => a, a => a.Id, (a, b) => b)
                .ToList();

            Regions.Single(a => a.Id == id).AddPopulations(populationsToAdd);
        }

        [Given(@"I save my regions")]
        [When(@"I save my regions")]
        public void WhenISaveMyRegions()
        {
            Regions.ForEach(a => Invoke(() => DataAccess.SaveRegion(a)));
        }

        [Then(@"I expect the saved region '(.*)' to contain")]
        public void ThenIExpectTheSavedRegionToContain(Guid id, Table table)
        {
            table.CompareToInstance(DataAccess.TryFindRegion(id));
        }

        [Then(@"I expect the saved region '(.*)' to contain the following populations")]
        public void ThenIExpectTheSavedRegionToContainTheFollowingPopulations(Guid id, Table table)
        {
            table.CompareToSet(DataAccess.TryFindRegion(id).Populations);
        }

        [Given(@"I delete all regions")]
        public void GivenIDeleteAllRegions()
        {
            DataAccess.DeleteAllRegions();
        }

        [When(@"I find regions by name '(.*)'")]
        public void WhenIFindRegionsByName(string name)
        {
            Invoke(() => RegionSearchResults = DataAccess.SearchRegionsByName(name));
        }

        [Then(@"I expect the search regions to only contain")]
        public void ThenIExpectTheSearchRegionsByNameToOnlyContain(Table table)
        {
            table.CompareToSet(RegionSearchResults);
        }

        [When(@"I find regions by most recent '(.*)' days with a limit of '(.*)'")]
        public void WhenIFindRegionsByMostRecentDaysWithALimitOf(int days, int limit)
        {
            Invoke(() => RegionSearchResults = DataAccess.SearchRegionsMostRecent(days, limit));
        }

    }
}
