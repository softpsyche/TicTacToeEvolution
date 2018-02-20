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

        bool DeletePopulation(Guid id);

        IPopulation FindPopulation(Guid id);

        List<IPopulation> FindPopulations(string name);
    }
}
