using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
	public class PopulationSettings
	{
		public String Name { get; set; }
		public Int32 MaximumSize { get; set; }
		public Double MutationRate { get; set; }
		public Int32 MaximumMatchesPerIndividual { get; set; }

		public PopulationSettings()
		{
			//this.MaximumMatchesPerIndividual = 5;
			//this.MaximumPopulationSize = 10;
			//this.MutationRate = .01;
		}
	}
}
