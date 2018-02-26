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
        public Guid Id { get; internal set; } = Guid.NewGuid();
        public string Name { get; set; }

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

        public PopulationSettings Settings { get; set; }
        public List<Individual> Individuals { get; internal set; }
        IEnumerable<Individual> IPopulation.Individuals => Individuals;


        public long Generation { get; internal set; }

        public Population(
            IInternalEvolutionFactory evolutionFactory,
            IMutator mutator,
            PopulationSettings settings)
        {
            EvolutionFactory = evolutionFactory;
            Mutator = mutator;
            Settings = settings;
        }

        public void Evolve(int cycles = 1)
        {
            //initialize if we have not already
            InitializeIndividuals(Settings);

            for (int i = 0; i < cycles; i++)
            {
                Evolve(Settings, Individuals);
            }
        }

        public void AddIndividuals(IEnumerable<Individual> individuals, bool replaceExisting = false)
        {
            if (individuals == null) return;

            if (replaceExisting)
            {
                //TODO: we may need to rework some history here...maybe??

                Individuals = individuals.ToList();
            }
            else
            {
                //initialize if we have not already
                InitializeIndividuals(Settings);

                //add the migrants
                Individuals.AddRange(individuals);
            }
        }

        private void Evolve(PopulationSettings settings, List<Individual> evolveList)
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

        private void InitializeIndividuals(PopulationSettings settings)
        {
            if (Individuals != null)
            {
                return;
            }

            var newIndividual = EvolutionFactory.CreateIndividual(settings.MaximumGenesPerIndividual);
            newIndividual.Name = "Eve";

            Individuals = newIndividual.Copy(settings.MaximumPopulationSize).ToList();
        }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Name) ? Id.ToString() : Name;
        }
    }
}
