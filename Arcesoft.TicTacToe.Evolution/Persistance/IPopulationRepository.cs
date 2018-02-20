using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance
{
    internal interface IPopulationRepository
    {
        void Insert(PopulationEntity populationEntity);

        bool Delete(Guid id);

        PopulationEntity Find(Guid id);

        IEnumerable<PopulationEntity> FindByName(string name);
    }
}
