using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Serialization
{

	public class JsonSerializer
	{
		private DtoMapperRepository DtoMapperRepository { get; set; }

		public JsonSerializer()
		{
			this.DtoMapperRepository = DtoMapperRepository.Create();
		}

		public String Serialize(Population population)
		{
			var mapper = DtoMapperRepository.GetMapper<Population>();
			var dto = mapper.Map(typeof(Population),population);
			var jsonString= JsonConvert.SerializeObject(dto);
			return jsonString;
		}
		public void SerializeToFile(Population population, String filePath)
		{
			var json = Serialize(population);

			File.WriteAllText(filePath, json);
		}

		public PopulationDto Deserialize(String jsonString)
		{
			return JsonConvert.DeserializeObject<PopulationDto>(jsonString);
		}
		public PopulationDto DeserializeFromFile(String filePath)
		{
			return JsonConvert.DeserializeObject<PopulationDto>(File.ReadAllText(filePath));
		} 

	}
}
