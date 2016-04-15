using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution.Serialization
{

	public abstract class DtoMapper<Source, Target> : IDtoMapper
	{
		private IDtoMapperRepository DtoMapperRepository { get; set; }

		protected DtoMapper(IDtoMapperRepository dtoMapperRepository)
		{
			DtoMapperRepository = dtoMapperRepository;
		}

		protected T[] MapCollection<S, T>(IEnumerable<S> sourceItems)
		{
			var mapper = DtoMapperRepository.GetMapper(typeof(S));

			return sourceItems.Select(a => (T)mapper.Map(typeof(S), a)).ToArray();
		}

		public abstract Target Map(Source source);

		#region IDtoMapper implementation
		public Type SourceType
		{
			get { throw new NotImplementedException(); }
		}
		public Type DtoType
		{
			get { throw new NotImplementedException(); }
		}
		public Object Map(Type sourceType, Object sourceInstance)
		{
			return Map((Source)sourceInstance);
		}
		#endregion
	}
	public interface IDtoMapper
	{
		Type SourceType { get; }
		Type DtoType { get; }

		Object Map(Type sourceType, Object sourceInstance);
	}

}
