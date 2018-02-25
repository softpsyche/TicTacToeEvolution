using Arcesoft.TicTacToe.Evolution.Persistance.Entities;
using Arcesoft.TicTacToe.Evolution.Persistance.LiteDatabaseHelpers;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance.Repositories
{
    internal class RegionRepository : IRegionRepository
    {
        private LiteDatabaseFactory LiteDatabaseFactory { get; set; }
        private DataAccessSettings Settings { get; set; }

        public RegionRepository(
            LiteDatabaseFactory liteDatabaseFactory,
            DataAccessSettings settings)
        {
            LiteDatabaseFactory = liteDatabaseFactory;
            Settings = settings;
        }

        public bool Exists(Guid id)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<RegionEntity>();

                return collection.Exists(a => a.Id == id);
            }
        }

        public void Insert(RegionEntity regionEntity)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<RegionEntity>();

                collection.Insert(regionEntity);

                collection.EnsureIndex(a => a.Name);
                collection.EnsureIndex(a => a.DateCreated);
            }
        }

        public bool Update(RegionEntity regionEntity)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<RegionEntity>();

                return collection.Update(regionEntity);

                //collection.EnsureIndex(a => a.Name);
                //collection.EnsureIndex(a => a.DateCreated);
            }
        }

        public RegionEntity Find(Guid id)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<RegionEntity>();

                return collection.FindById(id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<RegionEntity>();

                return collection.Delete(id);
            }
        }

        public void DeleteAll()
        {
            using (var db = Open())
            {
                db.DropCollection<RegionEntity>();
            }
        }

        public IEnumerable<RegionEntity> FindByName(string name)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<RegionEntity>();

                var results = collection.Find(a => a.Name.ToLowerInvariantSafe().ContainsSafe(name.ToLowerInvariantSafe())).ToList();

                return results;
            }
        }

        public IEnumerable<RegionEntity> FindMostRecent(int maxDaysOld = 30, int limit = 100)
        {
            var cutoffDate = DateTimeOffset.Now.Subtract(new TimeSpan(maxDaysOld, 0, 0, 0));
            using (var db = Open())
            {
                var collection = db.GetCollection<RegionEntity>();

                return collection
                    .Find(a => a.DateCreated >= cutoffDate, 0)
                    .OrderByDescending(a => a.DateCreated)
                    .Take(limit)
                    .ToList();
            }
        }

        private LiteDatabase Open()
        {
            return LiteDatabaseFactory.OpenOrCreate(Settings.LiteDatabaseConnectionString);
        }
    }
}
