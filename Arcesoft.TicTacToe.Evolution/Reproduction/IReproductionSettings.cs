using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Reproduction
{
    public interface IReproductionSettings
    {
        int MaximumPopulationSize { get; }

        /// <summary>
        /// The maximum number of children a given individual can conceive in a given generation.
        /// This is to prevent gene pool homogenization by either an extremely successful individual or 
        /// a particularly pathetic group.
        /// NOTE:
        /// Would be interesting to add genders to individuals and then experiment with comparing females
        /// with caps to males with far higher caps. Would it yield any information about the mysteries of the battles
        /// between the sexes? :-)
        /// </summary>
        int IndividualChildBearingLimit { get; }
    }
}
