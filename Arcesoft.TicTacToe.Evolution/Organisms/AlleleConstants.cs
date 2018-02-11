using Arcesoft.TicTacToe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    internal static class AlleleConstants
    {
        public const string DontCareString = "D";
        public const string EmptyString = BoardConstants.SquareEmptyString;
        public const string OccupiedXString = BoardConstants.SquareXString;
        public const string OccupiedOString = BoardConstants.SquareOString;
        public const string OccupiedAnyString = "A";
        public const string ResponseString = "R";

        public const char DontCareChar = 'D';
        public const char EmptyChar = BoardConstants.SquareEmptyChar;
        public const char OccupiedXChar = BoardConstants.SquareXChar;
        public const char OccupiedOChar = BoardConstants.SquareOChar;
        public const char OccupiedAnyChar = 'A';
        public const char ResponseChar = 'R';


    }
}
