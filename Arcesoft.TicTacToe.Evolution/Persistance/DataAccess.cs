using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Models;
using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Evolution.Persistance.Entities;
using Arcesoft.TicTacToe.Evolution.Persistance.Mapping;
using Arcesoft.TicTacToe.Evolution.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance
{
    internal class DataAccess : IDataAccess
    {
        private IInternalEvolutionFactory EvolutionFactory { get; set; }
        private IRegionRepository RegionRepository { get; set; }
        private IPopulationRepository PopulationRepository { get; set; }
        private IGeneCache GeneCache { get; set; }

        public DataAccess(
            IInternalEvolutionFactory evolutionFactory, 
            IRegionRepository regionRepository,
            IPopulationRepository populationRepository, 
            IGeneCache geneCache)
        {
            EvolutionFactory = evolutionFactory;
            RegionRepository = regionRepository;
            PopulationRepository = populationRepository;
            GeneCache = geneCache;
        }

        public void SavePopulation(IPopulation population)
        {
            PopulationRepository.Insert(population.ToPopulationEntity());
        }

        public bool DeletePopulation(Guid id)
        {
            return PopulationRepository.Delete(id);
        }
        public void DeleteAllPopulations()
        {
            PopulationRepository.DeleteAll();
        }

        public List<IPopulation> FindPopulations(string name)
        {
            return PopulationRepository
                .FindByName(name)
                .Select(a => a.ToPopulation(EvolutionFactory, GeneCache))
                .ToList();
        }

        public IPopulation TryFindPopulation(Guid id)
        {
            return PopulationRepository.Find(id)?.ToPopulation(EvolutionFactory, GeneCache);
        }

        public void SaveRegion(IRegion region)
        {
            RegionRepository.Insert(region.ToRegionEntity());
        }

        public void DeleteAllRegions()
        {
            RegionRepository.DeleteAll();
        }

        public bool DeleteRegion(Guid id)
        {
            return RegionRepository.Delete(id);
        }

        public IRegion TryFindRegion(Guid id)
        {
            var regionEntity = RegionRepository.Find(id);

            if (regionEntity == null) return null;

            var region = regionEntity.ToRegion(EvolutionFactory);

            region.Populations = regionEntity.PopulationIds?
                .Select(a => TryFindPopulation(a))
                .ToList();

            return region;
        }

        public List<RegionSearchResult> SearchRegionsByName(string name)
        {
            return RegionRepository
                .FindByName(name)
                .ToRegionSearchResults();
        }

        public List<RegionSearchResult> SearchRegionsMostRecent(int maxDaysOld = 30, int limit = 100)
        {
            return RegionRepository
                .FindMostRecent(maxDaysOld, limit)
                .ToRegionSearchResults();
        }
    }
}
