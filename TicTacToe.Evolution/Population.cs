using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	public class Population
	{
		public String Name { get; set; }
		public Int32 Size { get; set; }
		public IEnumerable<Individual> GetIndividuals()
		{
			return Individuals;
		}

		private IEvolutionContext Context { get; set; }


		private List<Individual> Individuals { get; set; }
		private Selector FitnessProvider { get; set; }
		private Culler Culler { get; set; }
		private Breeder Breeder { get; set; }

		//private PopulationHistory PopulationHistory { get; set; }

		public void Evolve()
		{
			//Evaluate the fitness of the individuals
			var fitnessResults = FitnessProvider.EvaluateFitness(Individuals);

			//Get the survivors
			var survivors = Culler.Cull(fitnessResults);

			//breed based on the survivors
			this.Individuals = Breeder.Breed(survivors).ToList();

			if (fitnessResults.OrderByDescending(a => a.Score).First().Score > 100)
			{
				var yo = "yes";
			}

			//make any environmental tweaks here??
			//EnvironmentalFactors.AdvanceEnvironment();

			//Set the next generation
			//PopulationHistory.Record(nextGeneration);
		}

		public Population(IEvolutionContext context)
		{
			this.Context = context;

			this.FitnessProvider = this.Context.CreateFitnessProvider();
			this.Culler = this.Context.CreateCuller();
			this.Breeder = this.Context.CreateBreeder();
			this.Size = this.Context.EvolutionSettings.MaximumPopulationSize;

			this.Individuals = this.Breeder.NewIndividuals(this.Size);
		}


	}
}
