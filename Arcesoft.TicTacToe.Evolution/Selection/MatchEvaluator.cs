using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class MatchEvaluator:IMatchEvaluator
    {
        private ITicTacToeFactory TicTacToeFactory { get; set; }

        public MatchEvaluator(ITicTacToeFactory ticTacToeFactory)
        {
            TicTacToeFactory = ticTacToeFactory;
        }

        public Ledger Evaluate(IEnumerable<Match> matches)
        {
            Ledger ledger = new Ledger();
            var game = TicTacToeFactory.NewGame();

            foreach (var match in matches)
            {
                EvaluateInternal(game, match, ledger,true);

                game.Reset();
            }

            return ledger;
        }
        private void EvaluateInternal(IGame game, Match match, Ledger ledger, bool includeDescription)
        {

            if (game.TotalMovesMade > 4)
            {
                var boardy = game.GameBoardString;
            }

            //is the game over?
            if (game.GameIsOver)
            {
                switch (game.GameState)
                {
                    case GameState.OWin:
                        UpdateScoresOrLedger(match.PlayerX, match, MetricType.Lost, ledger,
                            includeDescription ? $"Lost for board {game.GameBoardString}" : null);
                        UpdateScoresOrLedger(match.PlayerO, match, MetricType.Won, ledger,
                            includeDescription ? $"Won for board {game.GameBoardString}" : null);
                        break;
                    case GameState.XWin:
                        UpdateScoresOrLedger(match.PlayerX, match, MetricType.Won, ledger,
                            includeDescription ? $"Won for board {game.GameBoardString}" : null);
                        UpdateScoresOrLedger(match.PlayerO, match, MetricType.Lost, ledger,
                            includeDescription ? $"Lost for board {game.GameBoardString}" : null);
                        break;
                    case GameState.Tie:
                        UpdateScoresOrLedger(match.PlayerX, match, MetricType.Tied, ledger,
                            includeDescription ? $"Tied for board {game.GameBoardString}" : null);
                        UpdateScoresOrLedger(match.PlayerO, match, MetricType.Tied, ledger,
                            includeDescription ? $"Tied for board {game.GameBoardString}" : null);
                        break;
                }
            }
            else
            {
                var move = game.CurrentPlayer == Player.X ?
                    match.PlayerX.TryFindMove(game) :
                    match.PlayerO.TryFindMove(game);

                if (move.HasValue)
                {
                    UpdateScoresOrLedger(
                        game.CurrentPlayer == Player.X ? match.PlayerX : match.PlayerO,
                        match,
                        MetricType.Moved,
                        ledger,
                        includeDescription ? $"Moved to '{move.Value}' for board {game.GameBoardString}" : null);


                    //the super narrow path to game continuation...
                    game.Move(move.Value);
                    EvaluateInternal(game, match, ledger, includeDescription);
                }
                else
                {
                    //The player making the move loses
                    UpdateScoresOrLedger(
                        game.CurrentPlayer == Player.X ? match.PlayerX : match.PlayerO,
                        match,
                        MetricType.LostDueToNoMoves,
                        ledger,
                        includeDescription ? $"Lost due to no move for board {game.GameBoardString}" : null);

                    //The other player wins by default, specifically wins due to invalid move
                    UpdateScoresOrLedger(
                        game.CurrentPlayer == Player.X ? match.PlayerO : match.PlayerX,
                        match,
                        MetricType.WonDueToNoMoves,
                        ledger,
                        includeDescription ? $"Won due to no move for board {game.GameBoardString}" : null);
                }
            }
        }
        private void UpdateScoresOrLedger(Individual individual, Match match, MetricType metricType, Ledger ledger, string description)
        {
            if (ledger != null)
            {
                ledger.AddEntry(
                    individual.Id,
                    individual.Name,
                    match.Id,
                    match.PlayerX == individual ? Player.X : Player.O,
                    metricType,
                    description);
            }
        }
    }
}
