using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Models;
using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Evolution.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance.Mapping
{
    internal static class MapperExtensions
    {
        #region Population in
        public static IEnumerable<PopulationEntity> ToPopulationEntities(this IEnumerable<IPopulation> populations)
        {
            return populations.Select(a => a.ToPopulationEntity());
        }

        public static PopulationEntity ToPopulationEntity(this IPopulation population)
        {
            return new PopulationEntity()
            {
                Id = population.Id,
                Name = population.Name,
                Generation = population.Generation,
                Settings = population.Settings,
                Individuals = population.Individuals?.ToIndividualEntities().ToArray()
            };
        }

        public static IEnumerable<IndividualEntity> ToIndividualEntities(this IEnumerable<Individual> individuals)
        {
            if (individuals == null) return null;

            return individuals.Select(a => a.ToIndividualEntity());
        }

        public static IndividualEntity ToIndividualEntity(this Individual individual)
        {
            if (individual == null) return null;

            return new IndividualEntity()
            {
                Id = individual.Id,
                Name = individual.Name,
                ParentIds = individual.ParentIds.ToArray(),
                Genes = individual.Genes.ToCompactGeneStrings().ToArray()
            };
        }

        public static IEnumerable<string> ToCompactGeneStrings(this IEnumerable<Gene> genes)
        {
            return genes.Select(a => a.ToCompactGeneString());
        }

        public static string ToCompactGeneString(this Gene gene)
        {
            return $"{gene.Turn.ToInteger()}{gene.GetAlleles().ToAlleleString()}{gene.Priority.ToString("00")}";
        }
        #endregion

        #region Population out
        public static IPopulation ToPopulation(this PopulationEntity populationEntity, IInternalEvolutionFactory factory, IGeneCache geneCache)
        {
            var population = factory.CreatePopulation(populationEntity.Settings) as Population;
            population.Id = populationEntity.Id;
            population.Name = populationEntity.Name;
            population.Generation = populationEntity.Generation;

            population.Individuals = populationEntity.Individuals.ToIndividuals(factory, geneCache);

            return population;
        }

        public static List<Individual> ToIndividuals(this IEnumerable<IndividualEntity> individualEntities, IInternalEvolutionFactory factory, IGeneCache geneCache)
        {
            if (individualEntities == null) return null;

            return individualEntities.Select(a => a.ToIndividual(factory, geneCache)).ToList();
        }

        public static Individual ToIndividual(this IndividualEntity individualEntity, IInternalEvolutionFactory factory, IGeneCache geneCache)
        {
            if (individualEntity == null) return null;

            var individual = factory.CreateIndividual(0);

            individual.Id = individualEntity.Id;
            individual.Name = individualEntity.Name;
            individual.ParentIds = individualEntity.ParentIds;
            individual.Genes = individualEntity.Genes.ToGeneFromCompactStrings(geneCache);

            return individual;
        }

        public static IEnumerable<Gene> ToGeneFromCompactStrings(this IEnumerable<string> geneStrings, IGeneCache geneCache)
        {
            return geneStrings.Select(a => a.ToGeneFromCompactString(geneCache));
        }

        public static Gene ToGeneFromCompactString(this string geneString, IGeneCache geneCache)
        {
            return geneCache.CreateOrGet(
                Convert.ToInt32(geneString.Substring(0, 1)).ToTurn(),
                Convert.ToInt32(geneString.Substring(10, 2)),
                geneString.Substring(1, 9).ToAlleles());
        }
        #endregion

        #region Region
        public static RegionEntity ToRegionEntity(this IRegion region)
        {
            return null;
        }

        public static Region ToRegion(this RegionEntity regionEntity)
        {
            return null;
        }

        public static List<RegionSearchResult> ToRegionSearchResults(this IEnumerable<RegionEntity> regionEntity)
        {
            return null;
        }

            #endregion
        }
}
