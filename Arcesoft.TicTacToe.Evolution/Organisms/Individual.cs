using Arcesoft.TicTacToe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    /// <summary>
    /// TODO: parent ids??
    /// </summary>
	public class Individual : IArtificialIntelligence
    {
        public Guid Id { get; internal set; } = Guid.NewGuid();
        public string Name { get; set; }

        private List<Gene> _geneList = new List<Gene>();
        private List<Guid> _parentIdList = null;
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
        public IEnumerable<Guid> ParentIds
        {
            get
            {
                //ok, we hand this out which is risky ONLY if they cast to list...
                return _parentIdList ?? Enumerable.Empty<Guid>();
            }
            set
            {
                if (_parentIdList == null)
                {
                    _parentIdList = new List<Guid>();
                }
                _parentIdList.Clear();
                _parentIdList.AddRange(value);
            }
        }

        public Individual()
        {

        }
        private Individual(Individual source)
        {
            //we can copy the references here because genes are IMMUTABLE. Flyweight anyone?
            Genes = source.Genes;
            ParentIds = new[] { source.Id };
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
        public string ToDetailedString()
        {
            //return string.IsNullOrWhiteSpace(Name) ? Id.ToString() : $"{Name} - ({Id})";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ToString());

            var grouped = Genes.GroupBy(a => a.Turn).OrderBy(a => a.Key.ToInteger());

            var responses = grouped.Select(a => new
            {
                Turn = a.Key,
                Genes = a.OrderBy(b => b.Priority)
            });

            responses.ForEach(a => sb.AppendLine($"{a.Turn}:{a.Genes.First().GetAlleles().ToAlleleString()}"));

            return sb.ToString();
        }

        #region IArtificial intelligence
        public IEnumerable<MoveResult> FindMoveResults(IGame game)
        {
            //just make something up for this...
            return FindResponses(game)
                .Select(a => new MoveResult(a, GameState.InPlay));
        }

        public Move? TryFindBestMove(IGame game, bool randomlySelectIfMoreThanOne = true)
        {
            var results = FindResponses(game, 1).ToList();

            if (results.Any())
            {
                return results.First();
            }

            return null;
        }

        public void MakeMove(IGame game, bool randomlySelectIfMoreThanOne = true)
        {
            var moved = TryMakeMove(game);

            if (moved == false)
            {
                if (game.GameIsOver)
                {
                    throw new GameException($"Unable to make a move because the game is over.");
                }

                throw new GameException($"Unable to make a move because the individual has no response for the given boardstate.");
            }
        }

        public bool TryMakeMove(IGame game, bool randomlySelectIfMoreThanOne = true)
        {
            if (game.GameIsOver)
            {
                return false;
            }

            var moves = FindResponses(game, 1).ToList();

            if (moves.Any() && game.IsMoveValid(moves.First()))
            {
                game.Move(moves.First());
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion
    }
}
