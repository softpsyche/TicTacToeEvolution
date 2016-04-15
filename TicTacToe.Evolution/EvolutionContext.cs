using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Evolution.Serialization;

namespace TicTacToe.Evolution
{
	public class EvolutionContext : IEvolutionContext
	{
		public EvolutionContext()
		{
			this.EvolutionSettings = new EvolutionSettings()
			{
				MaximumMatchesPerIndividual = 5,
				MaximumPopulationSize = 200,
				MutationRate =.01D
			};
		}

		public virtual EvolutionSettings EvolutionSettings
		{
			get;
			private set;
		}


		public virtual IGame CreateGame()
		{
			return new Game();
		}
		public virtual IRandom CreateRandom()
		{
			return new GameRng();
		}

		public virtual Population CreatePopulation(PopulationDto dto)
		{
			var yo = dto;

			return null;
		}
		public virtual Population CreatePopulation()
		{
			return new Population(this);
		}
		public virtual Culler CreateCuller()
		{
			return new Culler(this);
		}
		public virtual Breeder CreateBreeder()
		{
			return new Breeder(this);
		}
		public virtual Selector CreateFitnessProvider()
		{
			return new Selector(this);
		}
	}

	public interface IEvolutionContext
	{
		EvolutionSettings EvolutionSettings
		{
			get;
		}

		IGame CreateGame();
		IRandom CreateRandom();
		Population CreatePopulation();
		Culler CreateCuller();
		Breeder CreateBreeder();
		Selector CreateFitnessProvider();
	}



	
}
