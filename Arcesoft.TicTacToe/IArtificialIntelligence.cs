using Arcesoft.TicTacToe.ArtificialIntelligence;
using Arcesoft.TicTacToe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe
{
    public interface IArtificialIntelligence
    {
        bool TryMakeMove(IGame game, bool randomlySelectIfMoreThanOne = true);

        void MakeMove(IGame game, bool randomlySelectIfMoreThanOne = true);

        IEnumerable<MoveResult> FindMoveResults(IGame game);
    }
}
