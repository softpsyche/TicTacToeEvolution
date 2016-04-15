using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	public class Culler
	{
		private IEvolutionContext Context { get; set; }

		public Culler(IEvolutionContext context)
		{
			this.Context = context;
		}

		public IList<FitnessResult> Cull(IEnumerable<FitnessResult> fitnessScores)
		{
			var orderedFittest = fitnessScores
				.OrderByDescending(a => a.Score)
				.ToList();

			if (fitnessScores.Count() < Context.EvolutionSettings.MaximumPopulationSize)
			{
				return orderedFittest;
			}
			else
			{
				return orderedFittest.Take(Context.EvolutionSettings.MaximumPopulationSize).ToList();
			}

		}
	}
}
