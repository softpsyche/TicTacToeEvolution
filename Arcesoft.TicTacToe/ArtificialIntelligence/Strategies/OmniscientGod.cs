﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.RandomNumberGeneration;
using Arcesoft.TicTacToe.Data;

namespace Arcesoft.TicTacToe.ArtificialIntelligence.Strategies
{
    /// <summary>
    /// Its like playing against a god. All knowing, all seeing, never losing. Very boring. This one 
    /// </summary>
    internal class OmniscientGod : IArtificialIntelligence
    {
        private IMoveDataAccess _moveDataAccess;
        private IRandom _random;

        public OmniscientGod(IMoveDataAccess moveDataAccess, IRandom random)
        {
            _moveDataAccess = moveDataAccess;
            _random = random;
        }

        public Move? TryFindBestMove(IGame game, bool randomlySelectIfMoreThanOne = true)
        {
            if (game.GameIsOver)
            {
                return null;
            }

            var moves = _moveDataAccess.FindMoveResponses(game.GameBoardString, game.CurrentPlayer);
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

        public void MakeMove(IGame game, bool randomlySelectIfMoreThanOne = true)
        {
            if (TryMakeMove(game,randomlySelectIfMoreThanOne) == false)
            {
                throw new GameException($"Unable to make a move because the game is over.");
            }
        }

        public IEnumerable<MoveResult> FindMoveResults(IGame game)
        {
            return _moveDataAccess
                .FindMoveResponses(game.GameBoardString, game.CurrentPlayer)
                .Select(a => new MoveResult(a.Response, a.Outcome))
                .ToList();
        }
    }
}
