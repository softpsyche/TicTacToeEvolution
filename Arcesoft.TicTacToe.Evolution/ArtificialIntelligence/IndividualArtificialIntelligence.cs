using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Organisms;

namespace Arcesoft.TicTacToe.Evolution.ArtificialIntelligence
{
    public class IndividualArtificialIntelligence : IArtificialIntelligence
    {
        private Individual Individual { get;set;}

        public IndividualArtificialIntelligence(Individual individual)
        {
            Individual = individual;
        }

        public IEnumerable<MoveResult> FindMoveResults(IGame game)
        {
            //just make something up for this...
            return Individual
                .FindResponses(game)
                .Select(a => new MoveResult(a, GameState.InPlay));
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

            var moves = Individual.FindResponses(game, 1).ToList();

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
    }
}
