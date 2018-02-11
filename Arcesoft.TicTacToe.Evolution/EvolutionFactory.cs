using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Evolution.Serialization;

namespace Arcesoft.TicTacToe.Evolution
{
	public class EvolutionFactory : IEvolutionFactory,IGameFactory
	{

		public virtual IGame NewGame()
		{
			return new Game();
		}
		public virtual IRandom CreateRandom()
		{
			return new GameRng();
		}

		public virtual Population NewPopulation(PopulationDto dto)
		{
			var yo = dto;

			return null;
		}
		public virtual Population NewPopulation()
		{
			var settings = new PopulationSettings()
			{
				MaximumMatchesPerIndividual = 5,
				MaximumSize = 200,
				MutationRate = .01D
			};

			var rng = new GameRng();

			return new Population(
				settings,
				new Selector(this,settings.MaximumMatchesPerIndividual),
				new Culler(),
				new Breeder(rng));
		}
	}
	public interface IGameFactory
	{
		IGame NewGame();
	}
	public interface IEvolutionFactory
	{
		Population NewPopulation();
	}



	
}
