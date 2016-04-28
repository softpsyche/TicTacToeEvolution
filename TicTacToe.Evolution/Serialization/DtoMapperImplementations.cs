using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution.Serialization
{
	public class PopulationDtoMapper : DtoMapper<Population, PopulationDto>
	{
		public PopulationDtoMapper(IDtoMapperRepository dtoMapperRepository)
			: base(dtoMapperRepository)
		{

		}

		public override PopulationDto Map(Population source)
		{
			return new PopulationDto()
			{
				//Name = source.Name,
				//Size = source.Size,
				Individuals = this.MapCollection<Individual, IndividualDto>(source.GetIndividuals())
			};
		}
	}
	public class IndividualDtoMapper : DtoMapper<Individual, IndividualDto>
	{
		public IndividualDtoMapper(IDtoMapperRepository dtoMapperRepository)
			: base(dtoMapperRepository)
		{

		}

		public override IndividualDto Map(Individual source)
		{
			return new IndividualDto()
			{
				Name = source.Name,
				Genes = this.MapCollection<Gene, GeneDto>(source.GetGenes())
			};
		}
	}
	public class GeneDtoMapper : DtoMapper<Gene, GeneDto>
	{
		public GeneDtoMapper(IDtoMapperRepository dtoMapperRepository)
			: base(dtoMapperRepository)
		{

		}


		public override GeneDto Map(Gene source)
		{
			return new GeneDto()
			{
				Priority = source.Priority,
				Move = source.Move,
				Alleles = source.GetAlleles()
			};
		}
	}
}
