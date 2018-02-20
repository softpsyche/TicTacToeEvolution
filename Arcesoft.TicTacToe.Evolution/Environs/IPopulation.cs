using Arcesoft.TicTacToe.Evolution.Organisms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Environs
{
    public interface IPopulation
    {
        Guid Id { get; }
        string Name { get; set; }
        long Generation { get; }
        EvolutionSettings Settings { get; set; }
        IEnumerable<Individual> Individuals { get; }

        void Evolve(int cycles = 1);

        void AddIndividuals(IEnumerable<Individual> individuals, bool replaceExisting = false);
    }
}
