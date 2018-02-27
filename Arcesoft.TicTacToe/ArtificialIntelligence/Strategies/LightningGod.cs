using Arcesoft.TicTacToe.Data;
using Arcesoft.TicTacToe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.ArtificialIntelligence.Strategies
{
    internal class LightningGod:IArtificialIntelligence
    {
        private IMoveDataAccess _moveDataAccess;
        private IRandom _random;

        private class MoveHash
        {
            public List<MoveResponse> MoveResponses { get; private set; }
            public string Id { get; private set; }

            public MoveHash(IEnumerable<MoveResponse> moveResponses)
            {
                var board = moveResponses.Select(a => a.Board).Distinct();
                var player = moveResponses.Select(a => a.Player).Distinct();

                MoveResponses = moveResponses.ToList();
                Id = $@"{board}{player.ToString()}";
            }

            public override bool Equals(object obj)
            {
                var other = obj as MoveHash;
                if (other == null) return false;

                return Id.Equals(other.Id);
            }
            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }
        }
        private static object SynchronizingObject { get; set; } = new object();
        private static SortedList<string, List<MoveResponse>> Cache { get; set; }
        private static SortedList<string, List<MoveResponse>> GetCache(IMoveDataAccess moveDataAccess)
        {
            if (Cache == null)
            {
                lock (SynchronizingObject)
                {
                    if (Cache == null)
                    {
                        //build it..
                        var newCache = new SortedList<string, List<MoveResponse>>();

                        var allResponses = moveDataAccess.FindAllMoveResponses().ToList();
                        var groupedResponses = allResponses.GroupBy(a => a.Board + a.Player.ToString());
                        groupedResponses.ForEach(a => newCache.Add(a.Key, a.ToList()));

                        Cache = newCache;
                    }
                }
            }

            return Cache;
        }

        public LightningGod(IMoveDataAccess moveDataAccess, IRandom random)
        {
            _moveDataAccess = moveDataAccess;
            _random = random;
        }

        private List<MoveResponse> FindCachedResponses(string currentBoardPosition, Player currentPlayer)
        {
            return GetCache(_moveDataAccess)[BuildKey(currentBoardPosition, currentPlayer)];
        }
        private string BuildKey(string board, Player player)
        {
            return $@"{board}{player.ToString()}";
        }

        public bool TryMakeMove(IGame game, bool randomlySelectIfMoreThanOne = true)
        {
            var move = TryFindBestMove(game, randomlySelectIfMoreThanOne);

            if (move.HasValue)
            {
                game.Move(move.Value);
                return true;
            }

            return false;
        }

        public Move? TryFindBestMove(IGame game, bool randomlySelectIfMoreThanOne = true)
        {
            if (game.GameIsOver)
            {
                return null;
            }

            var moves = FindCachedResponses(game.GameBoardString, game.CurrentPlayer);
            MoveResponse moveResponse =
                moves.Where(a => a.IsWin).RandomFromListOrDefault(_random) ??
                moves.Where(a => a.IsTie).RandomFromListOrDefault(_random) ??
                moves.Where(a => a.IsLoss).RandomFromListOrDefault(_random);

            if (moveResponse == null)
            {
                //this should NEVER happen if the game is not over. This is a true exceptional case
                throw new Exception($"Unable to make a move because there are no available moves for game board {game.GameBoardString}. Possible corrupt move data access or game.");
            }

            return moveResponse.Response;
        }

        public void MakeMove(IGame game, bool randomlySelectIfMoreThanOne = true)
        {
            if (TryMakeMove(game, randomlySelectIfMoreThanOne) == false)
            {
                throw new GameException($"Unable to make a move because the game is over.");
            }
        }

        public IEnumerable<MoveResult> FindMoveResults(IGame game)
        {
            return FindCachedResponses(game.GameBoardString, game.CurrentPlayer)
                .Select(a => new MoveResult(a.Response, a.Outcome))
                .ToList();
        }
    }
}
