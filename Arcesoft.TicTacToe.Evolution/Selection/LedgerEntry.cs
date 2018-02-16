using Arcesoft.TicTacToe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class LedgerEntry
    {
        public Guid IndividualId { get; set; }
        public string IndividualName { get; set; }
        public Guid MatchId { get; set; }
        public Player Player { get; set; }
        public Double MetricScore { get; set; }
        public MetricType? MetricType { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{MetricType}:{MetricScore}:{Player}:{MatchId}:{IndividualName}({IndividualId}):{Description}";
        }
    }
}
