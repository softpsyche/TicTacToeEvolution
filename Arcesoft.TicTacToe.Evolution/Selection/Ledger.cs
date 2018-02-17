using Arcesoft.TicTacToe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class Ledger
    {
        public List<LedgerEntry> Entries { get; set; }

        public Ledger()
        {
            Entries = new List<LedgerEntry>();
        }



        public Ledger Merge(params Ledger[] ledgers)
        {
            Ledger newLedger = new Ledger();
            ledgers.ForEach(a => newLedger.Entries.AddRange(a.Entries));
            return newLedger;
        }

        public LedgerEntry AddEntry(Guid individualId, string individualName, Guid matchId, Player player, MetricType? metricType, String description = null)
        {

            var entry = new LedgerEntry()
            {
                IndividualId = individualId,
                IndividualName = individualName,
                MatchId = matchId,
                Player = player,
                MetricType = metricType,
                Description = description
            };
            Entries.Add(entry);

            return entry;
        }
    }
}
