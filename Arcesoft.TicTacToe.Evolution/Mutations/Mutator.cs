using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Mutations
{
    public class Mutator : IMutator
    {
        private IRandom RandomNumberGenerator { get; set; }

        public Mutator(IRandom rng)
        {
            RandomNumberGenerator = rng;
        }

        public void Mutate(IEnumerable<Individual> individuals, MutationSettings mutationSettings)
        {
            individuals.ForEach(a => MutateIndividual(a, mutationSettings));
        }

        public void MutateIndividual(Individual individual, MutationSettings mutationSettings)
        {
            //point mutations...
            ApplyPointMutations(individual, mutationSettings);

            //copy mutations
        }

        private void ApplyPointMutations(Individual individual, MutationSettings mutationSettings)
        {
            var genes = individual.Genes.ToArray();
            for (int i = 0; i < genes.Length; i++)
            {
                genes[i] = MutateGene(genes[i], mutationSettings);
            }

            individual.Genes = genes;
        }

        public Gene MutateGene(Gene gene, MutationSettings mutationSettings)
        {
            var mutationRoll = RandomNumberGenerator.NextDouble();

            //if we have a mutation
            if (mutationRoll <= mutationSettings.PointMutationRate)
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
                        priority = RandomNumberGenerator.Next(100);
                        break;
                    case 1:
                        turn = RandomNumberGenerator.Next(9).ToTurn();
                        break;
                    default:
                        alleles[whichToMutate - 2] = RandomAllele();
                        break;
                }

                return new Gene(turn, priority, alleles);
            }

            //flyweight lets us do this
            return gene;
        }

        private static Array enumValues = Enum.GetValues(typeof(Allele));

        private Allele RandomAllele()
        {
            return (Allele)enumValues.GetValue(RandomNumberGenerator.Next(enumValues.Length));
        }
    }
}
