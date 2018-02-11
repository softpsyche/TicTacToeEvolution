using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
    internal static class GameExtensions
    {
        public static Turn Turn(this IGame game)
        {
            return game.TotalMovesMade.ToTurn();
        }
    }
}
