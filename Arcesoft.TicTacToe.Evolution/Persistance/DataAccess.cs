using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Organisms;
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

        public IPopulation FindPopulation(Guid id)
        {
            return PopulationRepository.Find(id).ToPopulation(EvolutionFactory, GeneCache);
        }

        public void SaveRegion(IRegion region)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllRegions()
        {
            throw new NotImplementedException();
        }

        public bool DeleteRegion(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IRegion FindRegion(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<IRegion> FindRegions(string name)
        {
            throw new NotImplementedException();
        }
    }
}
