﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	public class Breeder
	{
		private IEvolutionContext Context { get; set; }
		private Dictionary<Int64, Double> GenerationAverageFitnessDictionary
		{
			get;
			set;
		}

		public Breeder(IEvolutionContext context)
		{
			this.Context = context;

			this.GenerationAverageFitnessDictionary = new Dictionary<long, double>();
		}

		public IEnumerable<Individual> Breed(IEnumerable<FitnessResult> scores)
		{
			List<Individual> nextGeneration = new List<Individual>();
			var totalScore = scores.Sum(a => a.Score);

			foreach (var score in scores)
			{
				nextGeneration.AddRange(BreedIndividual(score.Individual, GetBreedCount(totalScore, score.Score)));
			}

			GenerationAverageFitnessDictionary.Add(GenerationAverageFitnessDictionary.Count, totalScore / scores.Count());

			return nextGeneration;
		}
		private Int32 GetBreedCount(Double totalScore, Double individualScore)
		{
			if (totalScore == 0)
				return 1;
			else
				return Convert.ToInt32(Math.Ceiling((individualScore / totalScore) * Context.EvolutionSettings.MaximumPopulationSize));
		}
		public IEnumerable<Individual> BreedIndividual(Individual individual, Int32 count)
		{
			var children = individual.Copy(count);
			var mutator = new Mutator(this.Context.CreateRandom(), this.Context.EvolutionSettings.MutationRate);

			mutator.Mutate(children);

			return children;
		}

		public List<Individual> NewIndividuals(params String[] ids)
		{
			List<Individual> listy = new List<Individual>();

			if (ids != null)
			{
				for (Int32 i = 0; i < ids.Length; i++)
				{
					listy.Add(NewIndividual(ids[i]));
				}
			}

			return listy;
		}
		public List<Individual> NewIndividuals(Int32 count)
		{
			List<Individual> listy = new List<Individual>();

			for (Int32 i = 0; i < count; i++)
			{
				listy.Add(NewIndividual());
			}

			return listy;
		}
		private Individual NewIndividual(String id = null)
		{
			id = id ?? Guid.NewGuid().ToString();

			var individual = new Individual(id);

			individual.SetGenes(CreateGenes());
			
			return individual;
		}

		private Gene[] CreateGenes()
		{
			List<Gene> geneList = new List<Gene>();

			geneList.AddRange(CreateGenesForMove(0, 20));
			geneList.AddRange(CreateGenesForMove(1, 20));
			geneList.AddRange(CreateGenesForMove(2, 20));
			geneList.AddRange(CreateGenesForMove(3, 20));
			geneList.AddRange(CreateGenesForMove(4, 20));
			geneList.AddRange(CreateGenesForMove(5, 20));
			geneList.AddRange(CreateGenesForMove(6, 20));
			geneList.AddRange(CreateGenesForMove(7, 20));
			geneList.AddRange(CreateGenesForMove(8, 20));

			return geneList.ToArray();
		}
		private Gene[] CreateGenesForMove(Int32 move, Int32 count)
		{
			Gene[] genes = new Gene[count];

			for (Int32 i = 0; i < count; i++)
			{
				genes[i] = BaseGenes[move];
			}

			return genes;
		}

		private static Object SynchronizingObject = new object();
		private static Gene[] _baseGenes = null;
		private static Gene[] BaseGenes
		{
			get
			{
				if (_baseGenes == null)
				{
					lock (SynchronizingObject)
					{
						if (_baseGenes == null)
						{
							_baseGenes = CreateBaseGenes();
						}
					}
				}

				return _baseGenes;
			}
		}
		private static Gene[] CreateBaseGenes()
		{
			Gene[] genes = new Gene[9];

			for (Int32 move = 0; move < 9; move++)
			{
				genes[move] = new Gene(move);
			}

			return genes;
		}
	}
}
