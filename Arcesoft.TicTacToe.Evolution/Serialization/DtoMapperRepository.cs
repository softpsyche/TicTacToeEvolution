using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Serialization
{

	public class DtoMapperRepository : IDtoMapperRepository
	{
		private Dictionary<Type, IDtoMapper> DtoMapperDictionary { get; set; }

		public DtoMapperRepository()
		{
			this.DtoMapperDictionary = new Dictionary<Type, IDtoMapper>();
		}

		public void AddMapper<T>(IDtoMapper dtoMapper)
		{
			this.AddMapper(typeof(T), dtoMapper);
		}
		public IDtoMapper GetMapper<T>()
		{
			return GetMapper(typeof(T));
		}
		#region IDtoMapperRepository implementation
		public IDtoMapper GetMapper(Type sourceType)
		{
			return DtoMapperDictionary[sourceType];
		}

		public void AddMapper(Type sourceType, IDtoMapper dtoMapper)
		{
			DtoMapperDictionary.Add(sourceType, dtoMapper);
		}
		#endregion

		public static DtoMapperRepository Create()
		{
			DtoMapperRepository repository = new DtoMapperRepository();

			repository.AddMapper<Population>(new PopulationDtoMapper(repository));
			repository.AddMapper<Individual>(new IndividualDtoMapper(repository));
			repository.AddMapper<Gene>(new GeneDtoMapper(repository));

			return repository;
		}
	}
	public interface IDtoMapperRepository
	{
		IDtoMapper GetMapper(Type sourceType);
		void AddMapper(Type sourceType, IDtoMapper dtoMapper);
	}

}
