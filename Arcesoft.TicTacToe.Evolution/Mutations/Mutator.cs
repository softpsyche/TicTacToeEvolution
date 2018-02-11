using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Mutations
{
	public class Mutator
	{
		private IRandom RandomNumberGenerator {get;set;}
		private Double MutationRate {get;set;}

		public Mutator(IRandom rng,Double mutationRate)
		{
			RandomNumberGenerator = rng;
			MutationRate = mutationRate;
		}

		public void Mutate(IEnumerable<Individual> individuals)
		{
			individuals.ForEach(a=>MutateIndividual(a));
		}
		private void MutateIndividual(Individual individual)
		{
			var genes = individual.GetGenes().ToArray();
			for (int i = 0; i < genes.Length; i++)
			{
				genes[i] = MutateGene(genes[i]);
			}

			individual.SetGenes(genes);
		}

		public Gene MutateGene(Gene gene)
		{
			var mutationRoll = this.RandomNumberGenerator.NextDouble();

			//if we have a mutation
			if (mutationRoll <= this.MutationRate)
			{
				Int32 priority = gene.Priority;
				Int32 move = gene.Move;
				Allele[] alleles = gene.GetAlleles();

				//we use 11 to decide which element to mutate
				//0 = priority
				//1 = move
				//2-10 = the allele to mutate
				var whichToMutate = this.RandomNumberGenerator.Next(0, 11);

				switch(whichToMutate)
				{
					case 0:
						priority = this.RandomNumberGenerator.Next(100);
						break;
					case 1:
						move = this.RandomNumberGenerator.Next(9);
						break;
					default:
						alleles[whichToMutate-2] = RandomAllele();
						break;
				}

				return new Gene(move, priority, alleles);
			}

			//flyweight lets us do this
			return gene;
		}

		private static Array enumValues = Enum.GetValues(typeof(Allele));
		private Allele RandomAllele()
		{
			return (Allele)enumValues.GetValue(this.RandomNumberGenerator.Next(enumValues.Length));
		}
	}
}
