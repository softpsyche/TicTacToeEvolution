using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	public class Individual
	{
		public String Name { get; private set; }
		private List<Gene> Genes { get; set; }

		public Individual(String name)
		{
			this.Name = name;
			this.Genes = new List<Gene>();
		}
		private Individual(Individual source)
		{
			this.Name = source.Name;
			this.Genes = new List<Gene>();
			//we can copy the references here because genes are IMMUTABLE. Flyweight anyone?
			this.Genes.AddRange(source.Genes);
		}

		public IEnumerable<Gene> GetGenes()
		{
			return Genes.AsReadOnly();
		}
		public void SetGenes(IEnumerable<Gene> genes)
		{
			this.Genes.Clear();
			this.Genes.AddRange(genes);
		}
		public GameMove TryFindBestGameMove(IGame game)
		{
			Int32 response;

			if (TryFindBestResponse(game.GameBoardString, game.MovesMade, out response))
			{
				return new GameMove(response / 3, response % 3);
			}

			return null;
		}

		private Boolean TryFindBestResponse(String gameBoardState, Int32 currentMove, out Int32 bestResponse)
		{
			bestResponse = 0;
			var responses = FindResponses(gameBoardState, currentMove, 1);

			if (responses.Any())
			{
				bestResponse = responses.First();
				return true;
			}

			return false;
		}
		public IEnumerable<Int32> FindResponses(String gameBoardState, Int32 currentMove, Int32 maximumToFind = Int32.MaxValue)
		{
			List<Int32> responses = new List<Int32>();
			var genesForCurrentMove = Genes
				.Where(a => a.Move == currentMove)
				.OrderBy(a => a.Priority)//sort here maybe move this out to an eager sort later.
				.ToArray();

			//assume list is sorted
			foreach (var gene in genesForCurrentMove)
			{
				//try to match on each gene...
				if (gene.IsMatch(gameBoardState))
				{
					//get the response for caching...
					var response = gene.Response;

					if (response.HasValue)
					{
						responses.Add(response.Value);

						if (responses.Count >= maximumToFind)
						{
							return responses;
						}

					}
				}
			}

			//return a distinct list of responses
			return responses
				.Distinct()
				.ToList();
		}

		public override string ToString()
		{
			return Name;
		}

		public Individual[] Copy(Int32 numberOfCopies)
		{
			Individual[] array = new Individual[numberOfCopies];

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Individual(this);
			}

			return array;
		}
	}
}
