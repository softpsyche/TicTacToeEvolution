using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	public class Population
	{
		public String Name
		{
			get;
			set;
		}
		public Int32 MaximumSize
		{
			get;
			set;
		}
		public Double MutationRate
		{
			get;
			set;
		}

		private PopulationSettings Settings { get; set; }
		public IEnumerable<Individual> GetIndividuals()
		{
			return Individuals;
		}

		private List<Individual> Individuals { get; set; }
		private Selector Selector { get; set; }
		private Culler Culler { get; set; }
		private Breeder Breeder { get; set; }

		public void Evolve()
		{
			//Evaluate the fitness of the individuals
			var fitnessResults = Selector.EvaluateFitness(Individuals);

			//Get the survivors
			var survivors = Culler.Cull(fitnessResults, Settings.MaximumSize);

			//breed based on the survivors
			this.Individuals = Breeder.Breed(survivors,this.Settings.MaximumSize, this.Settings.MutationRate).ToList();

			if (fitnessResults.OrderByDescending(a => a.Score).First().Score > 100)
			{
				var yo = "yes";
			}

			//make any environmental tweaks here??
			//EnvironmentalFactors.AdvanceEnvironment();

			//Set the next generation
			//PopulationHistory.Record(nextGeneration);
		}

		public Population(PopulationSettings settings, Selector selector, Culler culler, Breeder breeder)
		{
			this.Settings = settings;

			this.Selector = selector;
			this.Culler = culler;
			this.Breeder = breeder;

			this.Individuals = this.Breeder.NewIndividuals(this.Settings.MaximumSize);
		}


	}
}
