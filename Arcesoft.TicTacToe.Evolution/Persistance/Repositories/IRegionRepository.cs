using Arcesoft.TicTacToe.Evolution.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance.Repositories
{
    internal interface IRegionRepository
    {
        bool Exists(Guid id);

        void Insert(RegionEntity regionEntity);

        bool Update(RegionEntity regionEntity);

        bool Delete(Guid id);

        void DeleteAll();

        RegionEntity Find(Guid id);

        IEnumerable<RegionEntity> FindByName(string name);

        IEnumerable<RegionEntity> FindMostRecent(int maxDaysOld = 30, int limit = 100);
    }
}
