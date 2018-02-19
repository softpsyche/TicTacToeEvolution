using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance
{
    internal class LiteDatabaseFactory
    {
        //See ilitedatabase comment...same thing here
        public LiteDatabase OpenOrCreate(string connectionString)
        {
            return new LiteDatabase(connectionString);
        }
    }
}
