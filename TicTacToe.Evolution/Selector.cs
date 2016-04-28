using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace TicTacToe.Evolution
{
	public class Selector
	{
		private IGameFactory GameFactory { get; set; }
		private Int32 MaximumMatchesPerIndividual { get; set; }
		public Selector(IGameFactory gameFactory, Int32 maximumMatchesPerIndividual)
		{
			this.GameFactory = gameFactory;
			this.MaximumMatchesPerIndividual = maximumMatchesPerIndividual;
		}

		public IEnumerable<FitnessResult> EvaluateFitness(IEnumerable<Individual> individuals)
		{
			var matches = this.CreateIndividualFitnessProviders(individuals);

			return matches.Select(a => new FitnessResult(
				a.Evaluate(),
				a.Individual,
				a.AllMatches)).ToList();
		}

		private List<IndividualFitnessProvider> CreateIndividualFitnessProviders(IEnumerable<Individual> individuals)
		{
			if (this.MaximumMatchesPerIndividual >= individuals.Count())
			{
				throw new GameException("Maximum matches must be less than the total number of individuals");
			}

			List<IndividualFitnessProvider> fitnessScores = new List<IndividualFitnessProvider>();
			individuals.ForEach(a => fitnessScores.Add(new IndividualFitnessProvider(a, new FitnessScore())));

			//build the matches while we have anyone left to match up
			for (Int32 i = 0; i < fitnessScores.Count; i++)
			{
				var individual = fitnessScores[i];

				if (individual.XMatchCount < MaximumMatchesPerIndividual)
				{
					var opponents = fitnessScores
						.Where(a => Object.ReferenceEquals(a.Individual, individual.Individual) == false)
						.OrderBy(a => a.XMatchCount)
						.Take(MaximumMatchesPerIndividual - individual.XMatchCount)
						.ToList();

					opponents.ForEach(a =>
					{
						individual.CreateMatch(this.GameFactory, a);
						a.CreateMatch(this.GameFactory, individual);
					});
				}
			}

			return fitnessScores;
		}

	}

	public class FitnessResult
	{
		public Double Score { get; private set; }
		public String Name
		{
			get
			{
				return Individual.Name;
			}
		}
		public Individual Individual { get; private set; }
		public IEnumerable<GameMatch> Matches { get; private set; }

		public FitnessResult(Double score, Individual individual, IEnumerable<GameMatch> matches )
		{
			this.Score = score;
			this.Individual = individual;
			this.Matches = matches;
		}
	}

	public class IndividualFitnessProvider
	{
		public Individual Individual { get; private set; }
		public Int32 XMatchCount
		{
			get
			{
				return _XMatches.Count;
			}
		}

		private FitnessScore Score { get; set; }

		public IEnumerable<GameMatch> AllMatches
		{
			get
			{
				var array = new GameMatch[_XMatches.Count + _OMatches.Count];
				 _XMatches.CopyTo(array, 0);
				 _OMatches.CopyTo(array, _XMatches.Count);

				 return array;
			}
		}
		public IEnumerable<GameMatch> XMatches
		{
			get
			{
				return _XMatches;
			}
		}
		private List<GameMatch> _XMatches
		{
			get;
			set;
		}
		private List<GameMatch> _OMatches
		{
			get;
			set;
		}

		private Double? Result = null;
		public Double Evaluate()
		{
			if (Result.HasValue == false)
			{
				_XMatches.ForEach(a => a.Evaluate());
				_OMatches.ForEach(a => a.Evaluate());
				Result = Score.Total;
			}

			return Result.Value;
		}

		public IndividualFitnessProvider(Individual individual, FitnessScore fitnessScore)
		{
			this.Individual = individual;
			this.Score = fitnessScore;
			this._XMatches = new List<GameMatch>();
			this._OMatches = new List<GameMatch>();
		}

		public void CreateMatch(IGameFactory gameFactory, IndividualFitnessProvider oPlayer)
		{
			var match = new GameMatch(
				gameFactory.NewGame(),
				this.Individual,
				oPlayer.Individual,
				this.Score,
				oPlayer.Score);

			this._XMatches.Add(match);
			oPlayer._OMatches.Add(match);
		}

		public override string ToString()
		{
			return String.Format("{0} - {1}", Individual.Name, XMatchCount.ToString());
		}
	}


}
