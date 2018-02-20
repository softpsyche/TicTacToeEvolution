using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Reproduction;
using Arcesoft.TicTacToe.Evolution.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{

    /// <summary>
    /// Evolution factory for creating tic tac toe evolutionary constructs
    /// </summary>
    public interface IEvolutionFactory
    {
        IPopulation CreatePopulation(PopulationSettings settings);
    }
}
