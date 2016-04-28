using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	public class Culler
	{
		public Culler()
		{

		}

		public IList<FitnessResult> Cull(IEnumerable<FitnessResult> fitnessScores, Int32 maximumSize)
		{
			var orderedFittest = fitnessScores
				.OrderByDescending(a => a.Score)
				.ToList();

			if (fitnessScores.Count() < maximumSize)
			{
				return orderedFittest;
			}
			else
			{
				return orderedFittest.Take(maximumSize).ToList();
			}

		}
	}
}
