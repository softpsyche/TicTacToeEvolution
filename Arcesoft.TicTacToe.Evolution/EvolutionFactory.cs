using Arcesoft.TicTacToe.Evolution.DependencyInjection;
using Arcesoft.TicTacToe.Evolution.Reproduction;
using Arcesoft.TicTacToe.Evolution.Reproduction.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcesoft.TicTacToe.Evolution.Selection;
using Arcesoft.TicTacToe.Evolution.Selection.Strategies;
using Arcesoft.TicTacToe.Evolution.Environs;

namespace Arcesoft.TicTacToe.Evolution
{
    internal class EvolutionFactory : IEvolutionFactory, IInternalEvolutionFactory
    {
        private FactoryContainer FactoryContainer { get; set; }

        public EvolutionFactory(FactoryContainer factoryContainer)
        {
            FactoryContainer = factoryContainer;
        }

        public IBreeder CreateBreeder(BreederType breederType)
        {
            switch (breederType)
            {
                case BreederType.ASexual:
                    return FactoryContainer.GetInstance<AsexualBreeder>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(breederType));
            }
        }

        public IFitnessEvaluator CreateFitnessEvaluator(FitnessEvaluatorType fitnessEvaluatorType)
        {
            switch (fitnessEvaluatorType)
            {
                case FitnessEvaluatorType.AllOrNothing:
                    return FactoryContainer.GetInstance<AllOrNothingFitnessEvaluator>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(fitnessEvaluatorType));
            }
        }

        public IPopulation CreatePopulation(EvolutionSettings evolutionSettings)
        {
            var population = FactoryContainer.GetInstance<IPopulation>();


            return population;
        }
    }
}

