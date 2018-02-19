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
    /// <summary>
    /// Internally available factory which includes whatever is publically available as well
    /// </summary>
    internal interface IInternalEvolutionFactory : IEvolutionFactory
    {
        Individual CreateIndividual(int initialNumberOfGenes);

        IBreeder CreateBreeder(BreederType breederType);

        IFitnessEvaluator CreateFitnessEvaluator(FitnessEvaluatorType fitnessEvaluatorType);
    }
}
