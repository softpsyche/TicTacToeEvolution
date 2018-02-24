using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Models;
using Arcesoft.TicTacToe.Evolution.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance
{
    public interface IDataAccess
    {
        void SavePopulation(IPopulation population);

        void DeleteAllPopulations();

        bool DeletePopulation(Guid id);

        IPopulation TryFindPopulation(Guid id);

        List<IPopulation> FindPopulations(string name);

        void SaveRegion(IRegion region);

        void DeleteAllRegions();

        bool DeleteRegion(Guid Id);

        IRegion TryFindRegion(Guid id);

        List<RegionSearchResult> SearchRegionsByName(string name);

        List<RegionSearchResult> SearchRegionsMostRecent(int maxDaysOld = 30, int limit = 100);
    }
}
