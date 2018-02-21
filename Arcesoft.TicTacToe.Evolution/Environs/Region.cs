using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Environs
{
    internal class Region : IRegion
    {
        public Guid Id { get; internal set; } = Guid.NewGuid();

        public string Name { get; set; }

        public DateTimeOffset DateCreated { get; internal set; } = DateTimeOffset.Now;

        public long Age { get; internal set; }

        public RegionSettings Settings { get; set; }

        public List<Population> Populations { get; internal set; }

        IEnumerable<IPopulation> IRegion.Populations => Populations;

        public Region(RegionSettings settings)
        {
            Settings = settings;
        }

        public void Advance(int years = 1)
        {
            try
            {
                Task.WaitAll(Populations.Select(a => Task.Run(() => a.Evolve(years))).ToArray());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
