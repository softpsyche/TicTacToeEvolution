using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
	public class GameMatch
	{
		public Individual XPlayer { get; private set; }
		public Individual OPlayer { get; private set; }
		public Boolean HasEvaluated { get; private set; }
		public String GameBoardString
		{
			get
			{
				return Game.GameBoardString;
			}
		}

		private IGame Game { get; set; }
		private FitnessScore XPlayerFitnessScore { get; set; }
		private FitnessScore OPlayerFitnessScore { get; set; }

		private Individual MovingPlayer
		{
			get
			{
				return Game.PlayerTurn == Player.X ? XPlayer : OPlayer;
			}
		}
		private Individual NonMovingPlayer
		{
			get
			{
				return Game.PlayerTurn == Player.X ? OPlayer : XPlayer;
			}
		}
		private FitnessScore MovingPlayerFitnessScore
		{
			get
			{
				return Game.PlayerTurn == Player.X ? XPlayerFitnessScore : OPlayerFitnessScore;
			}
		}
		private FitnessScore NonMovingPlayerFitnessScore
		{
			get
			{
				return Game.PlayerTurn == Player.X ? OPlayerFitnessScore : XPlayerFitnessScore;
			}
		}

		public GameMatch(IGame game, Individual xPlayer, Individual oPlayer, FitnessScore xPlayerFitnessScore, FitnessScore oPlayerFitnessScore)
		{
			this.Game = game;
			this.XPlayer = xPlayer;
			this.OPlayer = oPlayer;
			this.XPlayerFitnessScore = xPlayerFitnessScore;
			this.OPlayerFitnessScore = oPlayerFitnessScore;
		}

		public Tuple<Individual, FitnessScore> GetPlayerAndScoreByName(String playerName)
		{
			if (playerName == XPlayer.Name)
				return new Tuple<Individual, FitnessScore>(this.XPlayer, this.XPlayerFitnessScore);
			else if (playerName == OPlayer.Name)
				return new Tuple<Individual, FitnessScore>(this.OPlayer, this.OPlayerFitnessScore);
			else
				throw new GameException("Invalid player name");
		}
		public GameState Evaluate()
		{
			if (HasEvaluated == false)
			{
				HasEvaluated = true;
				EvaluateMatchRecursive();
			}

			return Game.GameState;
		}
		private void EvaluateMatchRecursive()
		{
			//get the best move for the moving player.
			var move = MovingPlayer.TryFindBestGameMove(Game);
			var movingPlayerFitnessScore = MovingPlayerFitnessScore;
			var nonMovingPlayerFitnessScore = NonMovingPlayerFitnessScore;

			if (move == null)
			{//no move means we lose...concede the game
				movingPlayerFitnessScore.AddMetric(FitnessMetric.NoResponse);
			}
			else//we have a move to make
			{
				movingPlayerFitnessScore.AddMetric(FitnessMetric.Moved);
				Game.MakeMove(move);

				if (Game.IsOver)
				{
					if (Game.GameState == GameState.Tie)
					{
						//the only way to win is to make the move that wins...we can assume the moving player is the winner here.
						movingPlayerFitnessScore.AddMetric(FitnessMetric.Tied);
						nonMovingPlayerFitnessScore.AddMetric(FitnessMetric.Tied);
					}
					else
					{
						//the only way to win is to make the move that wins...we can assume the moving player is the winner here.
						movingPlayerFitnessScore.AddMetric(FitnessMetric.Won);
						nonMovingPlayerFitnessScore.AddMetric(FitnessMetric.Lost);
					}
				}
				else
				{
					EvaluateMatchRecursive();
				}
			}
		}

		private class IndividualCount
		{
			public Individual Individual { get; set; }
			public Int32 Count { get; set; }

			public IndividualCount(Individual i, Int32 count)
			{
				this.Individual = i;
				this.Count = count;
			}

			public override string ToString()
			{
				return String.Format("{0} - {1}", Individual.Name, Count.ToString());
			}
		}

		public override string ToString()
		{
			return String.Format("'{0}(X)' vs '{1}'(O)", XPlayer, OPlayer);
		}
	}
	public class FitnessScore
	{
		public const Double ZeroScore = 0;
		public Double Total
		{
			get
			{
				return MetricTotals.Values.Sum(a => a.Score);
			}
		}

		private Dictionary<FitnessMetric, FitnessScoreContainer> MetricTotals { get; set; }
		private IReadOnlyDictionary<FitnessMetric, Double> MetricWeights { get; set; }
		private class FitnessScoreContainer
		{
			public Double Score { get; set; }

			public override string ToString()
			{
				return Score.ToString();
			}
		}
		private Double GetMetricWeight(FitnessMetric metric)
		{
			return this.MetricWeights[metric];
		}

		private static Dictionary<FitnessMetric,Double> _metricWeights;
		static FitnessScore()
		{
			_metricWeights = new Dictionary<FitnessMetric,double>();
			_metricWeights.Add(FitnessMetric.Lost, 2D);
			_metricWeights.Add(FitnessMetric.Moved, 1D);
			_metricWeights.Add(FitnessMetric.NoResponse, 0D);
			_metricWeights.Add(FitnessMetric.Tied, 10D);
			_metricWeights.Add(FitnessMetric.Won, 100D);
		}
		public FitnessScore()
			:this(_metricWeights)
		{

		}
		public FitnessScore(IReadOnlyDictionary<FitnessMetric, Double> metricWeights)
		{
			MetricTotals = new Dictionary<FitnessMetric, FitnessScoreContainer>();
			MetricTotals.Add(FitnessMetric.Lost, new FitnessScoreContainer());
			MetricTotals.Add(FitnessMetric.Moved, new FitnessScoreContainer());
			MetricTotals.Add(FitnessMetric.NoResponse, new FitnessScoreContainer());
			MetricTotals.Add(FitnessMetric.Tied, new FitnessScoreContainer());
			MetricTotals.Add(FitnessMetric.Won, new FitnessScoreContainer());


			this.MetricWeights = metricWeights;

		}

		public void AddMetric(FitnessMetric metric, Int32 occurrences = 1)
		{
			MetricTotals[metric].Score += MetricWeights[metric] * occurrences;
		}

		public override string ToString()
		{
			return Total.ToString();
		}
	}
	public enum FitnessMetric
	{
		NoResponse = 0,
		Moved,
		Won,
		Lost,
		Tied
	}
}
