using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	public class PopulationSettings
	{
		public Int32 MaximumSize { get; set; }
		public Double MutationRate { get; set; }
		public Int32 MaximumMatchesPerIndividual { get; set; }
		//determine how much score affects breeding rate...
		public Int32 MaximumIndividualOffspring { get; set; }

		//randomly let some guy die...
		//public Double RandomDeathRate { get; set; }

		public PopulationSettings()
		{

		}
	}
}
