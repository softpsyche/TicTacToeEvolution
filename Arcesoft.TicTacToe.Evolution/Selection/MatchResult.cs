﻿using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            DefaultScores.Add(MetricType.Moved, 1);
            DefaultScores.Add(MetricType.LostDueToNoMoves, 1);
            DefaultScores.Add(MetricType.LostDueToInvalidMove, 1);
            DefaultScores.Add(MetricType.Lost, 1);
            DefaultScores.Add(MetricType.WonDueToNoMoves, 1);
            DefaultScores.Add(MetricType.WonDueToInvalidMove, 1);
            DefaultScores.Add(MetricType.Won, 1);
            DefaultScores.Add(MetricType.Tied, 1);
        }
        public MetricTypeScore()
        {

        }

        public Dictionary<MetricType, double> AllScores => new Dictionary<Selection.MetricType, double>(Scores);

        public double GetScore(MetricType type)
        {
            return Scores == null? DefaultScores[type]: Scores[type];
        }
        public void SetScores(Dictionary<MetricType, double> scores)
        {
            Scores = scores;
        }
    }

    [Serializable]
    public enum MetricType
    {
        
        Moved = 0,
        LostDueToNoMoves,
        LostDueToInvalidMove,
        Lost,
        WonDueToNoMoves,
        WonDueToInvalidMove,
        Won,
        Tied
    }

    public class Ledger
    {
        public List<LedgerEntry> Entries { get; set; }

        public Ledger Merge(params Ledger[] ledgers)
        {
            Ledger newLedger = new Ledger();
            ledgers.ForEach(a => newLedger.Entries.AddRange(a.Entries));
            return newLedger;
        }

        public LedgerEntry AddEntry(Guid individualId, Guid matchId, Player player, Double metricScore, MetricType? metricType)
        {
            var entry = new LedgerEntry()
            {
                IndividualId = individualId,
                MatchId = matchId,
                Player = player,
                MetricScore = metricScore,
                MetricType = metricType
            };
            Entries.Add(entry);

            return entry;
        }
    }

    public class LedgerEntry
    {
        public Guid IndividualId { get; set; }
        public Guid MatchId { get; set; }
        public Player Player { get; set; }
        public Double MetricScore { get; set; }
        public MetricType? MetricType { get; set; }
    }

    public class MatchResult
    {
        public Match Match { get; set; }
        public double XScore { get; set; }
        public double OScore { get; set; }

        public bool HasScoreLedger => Ledger != null;
        public Ledger Ledger { get; set; }
    }
}