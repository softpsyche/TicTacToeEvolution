using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Mutations
{
    /// <summary>
    /// See this site https://ghr.nlm.nih.gov/primer/mutationsanddisorders/possiblemutations
    /// for some ideas on types of mutations
    /// </summary>
    public class Mutator : IMutator
    {
        private IRandom RandomNumberGenerator { get; set; }

        private GeneCache GeneCache { get; set; }

        public Mutator(IRandom rng, GeneCache geneCache)
        {
            RandomNumberGenerator = rng;
            GeneCache = geneCache;
        }

        public void Mutate(IEnumerable<Individual> individuals, IMutationSettings mutationSettings)
        {
            individuals.ForEach(a => MutateIndividual(a, mutationSettings));
        }

        public void MutateIndividual(Individual individual, IMutationSettings mutationSettings)
        {
            var newGenes = individual.Genes.ToList();

            for (int i = 0; i < newGenes.Count; i++)
            {
                if (MutationOccurred(mutationSettings.MutationRate))
                {
                    //for now we will just allow point mutations..
                    newGenes[i] = ApplyPointMutation(newGenes[i]);
                }
            }

            individual.Genes = newGenes;
        }

        private bool MutationOccurred(double mutationRate) => RandomNumberGenerator.NextDouble() <= mutationRate;

        #region Point mutation (Missense or nonsense)

        public Gene ApplyPointMutation(Gene gene)
        {
            Int32 priority = gene.Priority;
            Turn turn = gene.Turn;
            Allele[] alleles = gene.GetAlleles();

            //we use 11 to decide which element to mutate
            //0 = priority
            //1 = move
            //2-10 = the allele to mutate
            var whichToMutate = RandomNumberGenerator.Next(0, 11);

            switch (whichToMutate)
            {
                case 0:
                    priority = RandomNumberGenerator.NextExcept(100, priority);
                    break;
                case 1:
                    turn = RandomNumberGenerator.NextExcept(9, turn.ToInteger()).ToTurn();
                    break;
                default:
                    alleles[whichToMutate - 2] = (Allele)RandomNumberGenerator.NextExcept(enumValues.Length, (int)alleles[whichToMutate - 2]);
                    break;
            }

            var newGene = GeneCache.CreateOrGet(turn, priority, alleles);

            return newGene;
        }

        private static Array enumValues = Enum.GetValues(typeof(Allele));

        #endregion
    }
}
