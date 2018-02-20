using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Common
{
    public interface IIdentifiable
    {
        Guid Id { get; }
        string Name { get; set; }
    }
}
