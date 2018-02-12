using Arcesoft.TicTacToe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
	public class Individual
	{
        public string Name { get; set; }
        public Guid Id { get; internal set; }
        private List<Gene> _geneList = null;
		public IEnumerable<Gene> Genes
        {
            get
            {
                //ok, we hand this out which is risky ONLY if they cast to list...
                return _geneList;
            }
            set
            {
                _geneList.Clear();
                _geneList.AddRange(value);
            }
        }

		public Individual()
		{
            Id = Guid.NewGuid();
            _geneList = new List<Gene>();
		}
        private Individual(Individual source) : this()
        {
            //we can copy the references here because genes are IMMUTABLE. Flyweight anyone?
            Genes = source.Genes;
        }

        public Move? TryFindMove(IGame game)
        {
            return TryFindMove(game.GameBoardString, game.Turn());
        }

        public Move? TryFindMove(String gameBoardState, Turn turn)
        {
            var responses = FindResponses(gameBoardState, turn, 1);

            return responses.Any() ? responses.Single() : new Move?();
        }

        public IEnumerable<Move> FindResponses(IGame game, Int32 maximumToFind = Int32.MaxValue)
        {
            return FindResponses(game.GameBoardString, game.Turn(), maximumToFind);
        }
        public IEnumerable<Move> FindResponses(String gameBoardState, Turn turn, Int32 maximumToFind = Int32.MaxValue)
		{
            List<Move> responses = new List<Move>();
			var genesForCurrentMove = Genes
				.Where(a => a.Turn == turn)
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

        public Individual[] Copy(Int32 numberOfCopies)
        {
            Individual[] array = new Individual[numberOfCopies];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Individual(this);
            }

            return array;
        }


        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Name) ? Id.ToString() : $"{Name} - ({Id})";
        }


	}
}
