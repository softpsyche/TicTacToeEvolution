using Arcesoft.TicTacToe.Evolution.Mutations;
using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Evolution.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Environs
{
    internal class Population : IPopulation
    {
        private IInternalEvolutionFactory EvolutionFactory { get; set; }
        private IMutator Mutator { get; set; }
        private IBreeder _breeder;
        private IBreeder Breeder
        {
            get
            {
                if (_breeder == null)
                {
                    _breeder = EvolutionFactory.CreateBreeder(Settings.BreederType);
                }

                return _breeder;
            }
        }
        private IFitnessEvaluator _fitnessEvaluator;
        private IFitnessEvaluator FitnessEvaluator
        {
            get
            {
                if (_fitnessEvaluator == null)
                {
                    _fitnessEvaluator = EvolutionFactory.CreateFitnessEvaluator(Settings.FitnessEvaluatorType);
                }

                return _fitnessEvaluator;
            }
        }

        public EvolutionSettings Settings { get; set; }
        private List<Individual> Individuals { get; set; }
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
        public long Generation { get; internal set; }


        public Population(
            IInternalEvolutionFactory evolutionFactory,
            IMutator mutator)
        {
            EvolutionFactory = evolutionFactory;
            Mutator = mutator;
        }

        public void Evolve()
        {
            //initialize if we have not already
            Initialize();

            //Compete: evaluate the fitness of the individuals
            var fitnessScores = FitnessEvaluator.Evaluate(Individuals, Settings);

            //Breed: Breed based on fitness scores
            var newGeneration = Breeder.Breed(fitnessScores, Settings).ToList();

            //Mutate: apply mutations to new generation
            Mutator.Mutate(newGeneration, Settings);

            //set the new individuals
            Individuals = newGeneration;

            //progress the next generation
            Generation++;
        }

        private void Initialize()
        {
            if (Individuals != null)
            {
                return;
            }

            Individuals = new List<Individual>();

        }
    }
}
