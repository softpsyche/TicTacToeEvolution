using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Selection
{
    public class Match
    {
        public Guid Id { get; private set; }
        public Individual PlayerX { get; set; }
        public Individual PlayerO { get; set; }

        public Match()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            var thingy = obj as Match;
            if (thingy == null)
            {
                return false;
            }

            return
                ReferenceEquals(PlayerX, thingy.PlayerX) &&
                ReferenceEquals(PlayerO, thingy.PlayerO);
        }
        public override int GetHashCode()
        {
            return
                PlayerX.GetHashCode() ^
                PlayerO.GetHashCode();
        }

        public override string ToString()
        {
            return $"X:{PlayerX} vs O:{PlayerO}";
        }
    }
}
