using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    internal static class TurnExtensions
    {
        public static Turn ToTurn(this int turnInt)
        {
            switch (turnInt)
            {
                case 0:
                    return Turn.First;
                case 1:
                    return Turn.Second;
                case 2:
                    return Turn.Third;
                case 3:
                    return Turn.Fourth;
                case 4:
                    return Turn.Fifth;
                case 5:
                    return Turn.Sixth;
                case 6:
                    return Turn.Seventh;
                case 7:
                    return Turn.Eigth;
                case 8:
                    return Turn.Ninth;
                default:
                    throw new ArgumentOutOfRangeException(nameof(turnInt));
            }
        }
        public static int ToInteger(this Turn turn)
        {
            switch (turn)
            {
                case Turn.First:
                    return 0;
                case Turn.Second:
                    return 1;
                case Turn.Third:
                    return 2;
                case Turn.Fourth:
                    return 3;
                case Turn.Fifth:
                    return 4;
                case Turn.Sixth:
                    return 5;
                case Turn.Seventh:
                    return 6;
                case Turn.Eigth:
                    return 7;
                case Turn.Ninth:
                    return 8;
                default:
                    throw new ArgumentOutOfRangeException(nameof(turn));
            }
        }
    }
}
