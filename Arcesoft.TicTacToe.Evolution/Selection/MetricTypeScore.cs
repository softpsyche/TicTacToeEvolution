using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class MetricTypeScore
    {
        private static Dictionary<MetricType, double> DefaultScores { get; set; }
        private Dictionary<MetricType, double> Scores { get; set; }


        static MetricTypeScore()
        {
            DefaultScores = new Dictionary<Selection.MetricType, double>();

            DefaultScores.Add(MetricType.Moved, 10);
            DefaultScores.Add(MetricType.LostDueToNoMoves, 0);
            DefaultScores.Add(MetricType.LostDueToInvalidMove, 5);
            DefaultScores.Add(MetricType.Lost, 0);
            DefaultScores.Add(MetricType.WonDueToNoMoves, 10);
            DefaultScores.Add(MetricType.WonDueToInvalidMove, 10);
            DefaultScores.Add(MetricType.Won, 100);
            DefaultScores.Add(MetricType.Tied, 50);
        }
        public MetricTypeScore()
        {

        }

        public Dictionary<MetricType, double> AllScores => new Dictionary<Selection.MetricType, double>(Scores);

        public double GetScore(MetricType type)
        {
            return Scores == null ? DefaultScores[type] : Scores[type];
        }
        public void SetScores(Dictionary<MetricType, double> scores)
        {
            Scores = scores;
        }
    }
}
