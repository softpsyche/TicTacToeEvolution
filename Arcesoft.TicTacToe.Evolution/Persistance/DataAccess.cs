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
        IInternalEvolutionFactory EvolutionFactory { get; set; }
        IPopulationRepository PopulationRepository { get; set; }
        IGeneCache GeneCache { get; set; }

        public DataAccess(IInternalEvolutionFactory evolutionFactory, IPopulationRepository populationRepository, IGeneCache geneCache)
        {
            EvolutionFactory = evolutionFactory;
            PopulationRepository = populationRepository;
            GeneCache = geneCache;
        }

        public void SavePopulation(IPopulation population)
        {
            PopulationRepository.Insert(population.ToPopulationEntity());
        }

        public List<IPopulation> FindPopulations(string name)
        {
            return PopulationRepository
                .FindByName(name)
                .Select(a => a.ToPopulation(EvolutionFactory, GeneCache))
                .ToList();
        }
    }
}
