using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Persistance.LiteDatabaseHelpers
{
    internal static class LiteDatabaseExtensions
    {
        public static void DropCollection<T>(this LiteDatabase liteDatabase)
        {
            liteDatabase.DropCollection(typeof(T).Name);
        }
    } 
}
