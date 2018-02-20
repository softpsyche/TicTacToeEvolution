using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance
{
    internal class DataAccessSettings
    {
        public string LiteDatabaseConnectionString
        {
            get
            {
                return @"C:\TicTacToeEvolution.db";
            }
        }
    }
}
