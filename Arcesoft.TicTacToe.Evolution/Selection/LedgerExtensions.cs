using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public static class LedgerExtensions
    {
        public static double WinRatio(this IEnumerable<LedgerEntry> ledgerEntries) => Convert.ToDouble(ledgerEntries.TotalWins()) / ledgerEntries.TotalMatches();
        public static double TieRatio(this IEnumerable<LedgerEntry> ledgerEntries) => Convert.ToDouble(ledgerEntries.TotalTies()) / ledgerEntries.TotalMatches();
        public static double LossRatio(this IEnumerable<LedgerEntry> ledgerEntries) => Convert.ToDouble(ledgerEntries.TotalLosses()) / ledgerEntries.TotalMatches();
        public static double MoveRatio(this IEnumerable<LedgerEntry> ledgerEntries) => Convert.ToDouble(ledgerEntries.TotalMoves()) / ledgerEntries.TotalMatches();
        
        public static int TotalMatches(this IEnumerable<LedgerEntry> ledgerEntries) => ledgerEntries.Select(a => a.MatchId).Distinct().Count();
        public static int TotalWins(this IEnumerable<LedgerEntry> ledgerEntries) => ledgerEntries.Count(a => a.IsWin());
        public static int TotalTies(this IEnumerable<LedgerEntry> ledgerEntries) => ledgerEntries.Count(a => a.IsTie());
        public static int TotalLosses(this IEnumerable<LedgerEntry> ledgerEntries) => ledgerEntries.Count(a => a.IsLoss());
        public static int TotalMoves(this IEnumerable<LedgerEntry> ledgerEntries) => ledgerEntries.Count(a => a.MetricType == MetricType.Moved);
        public static bool IsWin(this LedgerEntry ledgerEntry)
        {
            switch (ledgerEntry.MetricType)
            {
                case MetricType.Won:
                case MetricType.WonDueToInvalidMove:
                case MetricType.WonDueToNoMoves:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsLoss(this LedgerEntry ledgerEntry)
        {
            switch (ledgerEntry.MetricType)
            {
                case MetricType.Lost:
                case MetricType.LostDueToInvalidMove:
                case MetricType.LostDueToNoMoves:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsTie(this LedgerEntry ledgerEntry)
        {
            return ledgerEntry.MetricType == MetricType.Tied;
        }
    }
}
