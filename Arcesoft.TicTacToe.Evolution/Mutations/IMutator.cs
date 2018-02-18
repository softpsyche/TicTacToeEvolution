using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Mutations
{
    public interface IMutator
    {
        void Mutate(IEnumerable<Individual> individuals, IMutationSettings mutationSettings);

        void MutateIndividual(Individual individual, IMutationSettings mutationSettings);
    }
}
