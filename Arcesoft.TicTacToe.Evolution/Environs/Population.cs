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
        public List<Individual> Individuals { get; internal set; }
        IEnumerable<Individual> IPopulation.Individuals => Individuals;

        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
        public long Generation { get; internal set; }



        public Population(
            IInternalEvolutionFactory evolutionFactory,
            IMutator mutator,
            EvolutionSettings evolutionSettings)
        {
            EvolutionFactory = evolutionFactory;
            Mutator = mutator;
            Settings = evolutionSettings;
        }

        public void Evolve(int cycles = 1)
        {
            //initialize if we have not already
            Initialize(Settings);

            for (int i = 0; i < cycles; i++)
            {
                Evolve(Settings, Individuals);
            }
        }

        public void AddIndividuals(IEnumerable<Individual> individuals)//todo? allow replace???
        {
            if (individuals == null) return;

            //initialize if we have not already
            Initialize(Settings);

            //add the migrants
            Individuals.AddRange(individuals);
        }

        private void Evolve(EvolutionSettings settings, List<Individual> evolveList)
        {
            //Compete: evaluate the fitness of the individuals
            var fitnessScores = FitnessEvaluator.Evaluate(evolveList, settings);

            //Breed: Breed based on fitness scores
            var newGeneration = Breeder.Breed(fitnessScores, settings).ToList();

            //Mutate: apply mutations to new generation
            Mutator.Mutate(newGeneration, settings);

            //set the new individuals
            Individuals = newGeneration;

            //progress the next generation
            Generation++;
        }

        private void Initialize(EvolutionSettings settings)
        {
            if (Individuals != null)
            {
                return;
            }

            var newIndividual = EvolutionFactory.CreateIndividual(settings.MaximumGenesPerIndividual);
            newIndividual.Name = "Eve";

            Individuals = newIndividual.Copy(settings.MaximumPopulationSize).ToList();
        }
    }
}
