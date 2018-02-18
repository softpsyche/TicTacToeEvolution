using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Evolution.Reproduction;
using Arcesoft.TicTacToe.Evolution.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
    public interface IBreeder
    {
        IEnumerable<Individual> Breed(IEnumerable<FitnessScore> fitnessScores, IReproductionSettings settings);
    }

}
