﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Environs
{
    public interface IRegion
    {
        Guid Id { get; }

        string Name { get; set; }

        DateTimeOffset DateCreated { get;}

    }
}
