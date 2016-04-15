using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution.Serialization
{

	public class PopulationDto
	{
		public String Name { get; set; }
		public Int32 Size { get; set; }

		public IndividualDto[] Individuals { get; set; }

		public override string ToString()
		{
			return String.Format("{0} - {1}", Name, Size);
		}
	}

	public class IndividualDto
	{
		public String Name { get; set; }
		public GeneDto[] Genes { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

	public class GeneDto
	{
		public Int32 Priority { get; set; }
		public Int32 Move { get; set; }
		public Allele[] Alleles { get; set; }

		public override string ToString()
		{
			return String.Format("(M:{0}|P:{1}) - {2}", this.Move, this.Priority, this.Alleles.ToVisualString());
		}
	}

}
