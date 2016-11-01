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

		public PopulationSettings Settings { get; private set; }
		public IEnumerable<Individual> GetIndividuals()
		{
			return Individuals;
		}

		private List<Individual> Individuals { get; set; }
		private Selector Selector { get; set; }
		private Culler Culler { get; set; }
		private Breeder Breeder { get; set; }

		public Int64 GenerationCount { get; private set; }

		public EvolveResult Evolve()
		{
			var result = new EvolveResult() { 
				Individuals = this.Individuals,
				GenerationNumber = GenerationCount,
				PopulationSettings = Settings 
				};

			//Evaluate the fitness of the individuals
			var fitnessResults = Selector.EvaluateFitness(Individuals);

			//Get the survivors
			var survivors = Culler.Cull(fitnessResults, Settings.MaximumSize);

			//breed based on the survivors
			this.Individuals = Breeder.Breed(survivors,this.Settings.MaximumSize, this.Settings.MaximumIndividualOffspring, this.Settings.MutationRate).ToList();

			if (fitnessResults.OrderByDescending(a => a.Score).First().Score > 100)
			{
				var yo = "yes";
			}

			this.GenerationCount++;
			fitnessResults.Sum(a => a.Score);

			result.FitnessResults = fitnessResults;

			return result;
			//make any environmental tweaks here??
			//EnvironmentalFactors.AdvanceEnvironment();

			//Set the next generation
			//PopulationHistory.Record(nextGeneration);
		}

		public Population(PopulationSettings settings, Selector selector, Culler culler, Breeder breeder)
		{
			this.GenerationCount = 0;
			this.Settings = settings;

			this.Selector = selector;
			this.Culler = culler;
			this.Breeder = breeder;

			this.Individuals = this.Breeder.NewIndividuals(this.Settings.MaximumSize);
		}
	}

	public class EvolveResult
	{
		public IEnumerable<Individual> Individuals {get;set;}
		public IEnumerable<FitnessResult> FitnessResults {get;set;}
		public PopulationSettings PopulationSettings {get;set;}
		public Int64 GenerationNumber { get; set; }
	}

	public class PopulationReportHistory
	{
		private List<PopulationReport> PopulationReportList = new List<PopulationReport>();

		public PopulationReport GetLatestReport() { return this.PopulationReportList.Last(); }

		public void AddReport(EvolveResult result)
		{
			var report = new PopulationReport()
			{
				Generation = result.GenerationNumber,
				MaximumSize = result.PopulationSettings.MaximumSize,
				MaximumIndividualOffspring = result.PopulationSettings.MaximumIndividualOffspring,
				MutationRate = result.PopulationSettings.MutationRate,
				PopulationSize = result.PopulationSettings.MaximumSize,
				AverageFitness = (result.FitnessResults.Sum(a=>a.Score))/result.FitnessResults.Count(),
				GeneDiversityIndex = CalculateGeneDiversity(result)
			};

			this.PopulationReportList.Add(report);
		}

		private Double CalculateGeneDiversity(EvolveResult result)
		{
			var results = result.Individuals.Select(a=>a.GetGenes().Select(b=>b.Key));
			Double total =0D;

			foreach (var i in result.Individuals)
			{
				var genes = i.GetGenes();

				var distinctKeys = genes.Select(a => a.Key).Distinct();
				total += Convert.ToDouble(distinctKeys.Count()) / genes.Count();
			}

			return total / result.Individuals.Count();
		}
	}
	public class PopulationReport
	{
		public Int64 Generation { get; set; }
		public Double AverageFitness { get; set; }
		public Int32 PopulationSize { get; set; }
		public Int32 MaximumSize { get; set; }
		public Double MutationRate { get; set; }
		public Int32 MaximumIndividualOffspring { get; set; }
		public Double GeneDiversityIndex { get; set; }//(count of DISTINCT genes within population)/(count of ALL genes in population)
	}
}
