using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Organisms;
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
    internal class PopulationRepository : IPopulationRepository
    {
        private LiteDatabaseFactory LiteDatabaseFactory { get; set; }
        private DataAccessSettings Settings { get; set; }

        public PopulationRepository(
            LiteDatabaseFactory liteDatabaseFactory,
            DataAccessSettings settings)
        {
            LiteDatabaseFactory = liteDatabaseFactory;
            Settings = settings;
        }

        public void Insert(PopulationEntity populationEntity)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<PopulationEntity>();

                collection.Insert(populationEntity);

                collection.EnsureIndex(a => a.Name);
            }
        }

        public PopulationEntity Find(Guid id)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<PopulationEntity>();

                return collection.FindById(id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<PopulationEntity>();

                return collection.Delete(id);
            }
        }

        public void DeleteAll()
        {
            using (var db = Open())
            {
                db.DropCollection<PopulationEntity>();
            }
        }

        public IEnumerable<PopulationEntity> FindByName(string name)
        {
            using (var db = Open())
            {
                var collection = db.GetCollection<PopulationEntity>();

                return collection.Find(a => a.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }
        }

        private LiteDatabase Open()
        {
            return LiteDatabaseFactory.OpenOrCreate(Settings.LiteDatabaseConnectionString);
        }
    }
}
