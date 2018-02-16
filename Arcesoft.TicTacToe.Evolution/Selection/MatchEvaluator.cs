using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class MatchEvaluator
    {
        private ITicTacToeFactory TicTacToeFactory { get; set; }
        private MetricTypeScore MetricTypeScore { get; set; }

        public MatchEvaluator(ITicTacToeFactory ticTacToeFactory, MetricTypeScore metricTypeScore)
        {
            TicTacToeFactory = ticTacToeFactory;
            MetricTypeScore = metricTypeScore;
        }

        public Ledger Evaluate(params Match[] matches)
        {
            Ledger ledger = new Ledger();
            var game = TicTacToeFactory.NewGame();
            Score xScore = new Score();
            Score oScore = new Score();

            foreach (var match in matches)
            {
                EvaluateInternal(game, match, xScore, oScore, ledger);

                game.Reset();
            }

            return ledger;
        }
        private void EvaluateInternal(IGame game, Match match, Score xScore, Score oScore, Ledger ledger)
        {
            //is the game over?
            if (game.GameIsOver)
            {
                switch (game.GameState)
                {
                    case GameState.OWin:
                        UpdateScoresOrLedger(match.PlayerX, match, xScore, MetricType.Lost, ledger,$"Lost for board {game.GameBoardString}");
                        UpdateScoresOrLedger(match.PlayerO, match, oScore, MetricType.Won, ledger, $"Won for board {game.GameBoardString}");
                        break;
                    case GameState.XWin:
                        UpdateScoresOrLedger(match.PlayerX, match, xScore, MetricType.Won, ledger, $"Won for board {game.GameBoardString}");
                        UpdateScoresOrLedger(match.PlayerO, match, oScore, MetricType.Lost, ledger, $"Lost for board {game.GameBoardString}");
                        break;
                    case GameState.Tie:
                        UpdateScoresOrLedger(match.PlayerX, match, xScore, MetricType.Tied, ledger, $"Tied for board {game.GameBoardString}");
                        UpdateScoresOrLedger(match.PlayerO, match, oScore, MetricType.Tied, ledger, $"Tied for board {game.GameBoardString}");
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
                    if (game.IsMoveValid(move.Value))
                    {
                        //give the player who made a move some points...
                        UpdateScoresOrLedger(
                            game.CurrentPlayer == Player.X ? match.PlayerX : match.PlayerO,
                            match,
                            game.CurrentPlayer == Player.X ? xScore : oScore,
                            MetricType.Moved,
                            ledger,
                            $"Moved to '{move.Value}' for board {game.GameBoardString}");


                        //the super narrow path to game continuation...
                        game.Move(move.Value);
                        EvaluateInternal(game, match, xScore, oScore, ledger);
                    }
                    else
                    {
                        //The player making the move loses
                        UpdateScoresOrLedger(
                            game.CurrentPlayer == Player.X ? match.PlayerX : match.PlayerO,
                            match,
                            game.CurrentPlayer == Player.X ? xScore : oScore,
                            MetricType.LostDueToInvalidMove,
                            ledger,
                            $"Lost due to no move for board {game.GameBoardString}");

                        //The other player wins by default, specifically wins due to invalid move
                        UpdateScoresOrLedger(
                            game.CurrentPlayer == Player.X ? match.PlayerO : match.PlayerX,
                            match,
                            game.CurrentPlayer == Player.X ? oScore : xScore,
                            MetricType.WonDueToInvalidMove,
                            ledger,
                            $"Won due to no move for board {game.GameBoardString}");
                    }
                }
                else
                {
                    //The player making the move loses
                    UpdateScoresOrLedger(
                        game.CurrentPlayer == Player.X ? match.PlayerX : match.PlayerO,
                        match,
                        game.CurrentPlayer == Player.X ? xScore : oScore,
                        MetricType.LostDueToNoMoves,
                        ledger,
                        $"Lost due to no move for board {game.GameBoardString}");

                    //The other player wins by default, specifically wins due to invalid move
                    UpdateScoresOrLedger(
                        game.CurrentPlayer == Player.X ? match.PlayerO : match.PlayerX,
                        match,
                        game.CurrentPlayer == Player.X ? oScore : xScore,
                        MetricType.WonDueToNoMoves,
                        ledger,
                        $"Won due to no move for board {game.GameBoardString}");
                }
            }
        }
        private void UpdateScoresOrLedger(Individual individual, Match match, Score score, MetricType metricType, Ledger ledger, string description)
        {
            var metricScore = MetricTypeScore.GetScore(metricType);
            score.Value += metricScore;

            if (ledger != null)
            {
                ledger.AddEntry(
                    individual.Id,
                    individual.Name,
                    match.Id,
                    match.PlayerX == individual ? Player.X : Player.O,
                    metricScore,
                    metricType,
                    description);
            }
        }

        private class Score
        {
            public double Value { get; set; }
        }
    }
}
