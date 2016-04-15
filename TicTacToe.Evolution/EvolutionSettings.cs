using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	public class EvolutionSettings
	{
		public Int32 MaximumMatchesPerIndividual { get; set; }
		public Int32 MaximumPopulationSize { get; set; }
		public Double MutationRate { get; set; }

		public EvolutionSettings()
		{
			//this.MaximumMatchesPerIndividual = 5;
			//this.MaximumPopulationSize = 10;
			//this.MutationRate = .01;
		}
	}
}
