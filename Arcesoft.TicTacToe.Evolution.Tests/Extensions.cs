using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    internal static class Extensions
    {
        public static  string ToParentIdsString(this Individual individual)
        {
            return string.Join(",", individual.ParentIds.Select(b => b.ToString()));
        }
    }
}
