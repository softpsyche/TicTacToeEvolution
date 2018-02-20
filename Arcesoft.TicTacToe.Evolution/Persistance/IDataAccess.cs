using Arcesoft.TicTacToe.Evolution.Environs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance
{
    internal interface IDataAccess
    {
        void SavePopulation(IPopulation population);

        void DeleteAllPopulations();

        bool DeletePopulation(Guid id);

        IPopulation FindPopulation(Guid id);

        List<IPopulation> FindPopulations(string name);

        void SaveRegion(IRegion region);

        void DeleteAllRegions();

        bool DeleteRegion(Guid Id);

        IRegion FindRegion(Guid id);

        List<IRegion> FindRegions(string name);
    }
}
