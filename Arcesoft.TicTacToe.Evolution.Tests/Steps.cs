using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using SimpleInjector;
using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Entities;
using System.Collections.Generic;
using Arcesoft.TicTacToe.Evolution.Selection;
using Arcesoft.TicTacToe.Evolution.Mutations;
using Moq;
using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Persistance;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    internal abstract class Steps
    {
        protected ScenarioContext CurrentContext => ScenarioContext.Current;

        protected Boolean ExpectingException
        {
            get
            {
                return GetScenarioContextItemOrDefault<Boolean>(nameof(ExpectingException));
            }
            set
            {
                CurrentContext.Set(value, nameof(ExpectingException));
            }
        }

        protected Exception Exception
        {
            get
            {
                return GetScenarioContextItemOrDefault<Exception>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Container Container
        {
            get
            {
                return GetScenarioContextItemOrDefault<Container>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected ITicTacToeFactory TicTacToeFactory
        {
            get
            {
                return GetScenarioContextItemOrDefault<ITicTacToeFactory>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IInternalEvolutionFactory EvolutionFactory
        {
            get
            {
                return GetScenarioContextItemOrDefault<IInternalEvolutionFactory>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IGame Game
        {
            get
            {
                return GetScenarioContextItemOrDefault<IGame>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Individual Individual
        {
            get
            {
                return GetScenarioContextItemOrDefault<Individual>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Individual[] IndividualCopies
        {
            get
            {
                return GetScenarioContextItemOrDefault<Individual[]>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Move? Move
        {
            get
            {
                return GetScenarioContextItemOrDefault<Move?>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IEnumerable<Move> Responses
        {
            get
            {
                return GetScenarioContextItemOrDefault<IEnumerable<Move>>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IMatchBuilder MatchBuilder
        {
            get
            {
                return GetScenarioContextItemOrDefault<IMatchBuilder>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Mock<IMatchBuilder> MatchBuilderMock
        {
            get
            {
                return GetScenarioContextItemOrDefault<Mock<IMatchBuilder>>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IMatchEvaluator MatchEvaluator
        {
            get
            {
                return GetScenarioContextItemOrDefault<IMatchEvaluator>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Mock<IMatchEvaluator> MatchEvaluatorMock
        {
            get
            {
                return GetScenarioContextItemOrDefault<Mock<IMatchEvaluator>>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IFitnessEvaluator FitnessEvaluator
        {
            get
            {
                return GetScenarioContextItemOrDefault<IFitnessEvaluator>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Individual[] Individuals
        {
            get
            {
                return GetScenarioContextItemOrDefault<Individual[]>(nameof(Individuals));
            }
            set
            {
                CurrentContext.Set(value, nameof(Individuals));
            }
        }

        protected List<Selection.Match> Matches
        {
            get
            {
                return GetScenarioContextItemOrDefault<List<Selection.Match>>(nameof(Matches));
            }
            set
            {
                CurrentContext.Set(value, nameof(Matches));
            }
        }

        protected Ledger Ledger
        {
            get
            {
                return GetScenarioContextItemOrDefault<Ledger>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected List<FitnessScore> FitnessScores
        {
            get
            {
                return GetScenarioContextItemOrDefault<List<FitnessScore>>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IMutator Mutator
        {
            get
            {
                return GetScenarioContextItemOrDefault<IMutator>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected PopulationSettings PopulationSettings
        {
            get
            {
                return GetScenarioContextItemOrDefault<PopulationSettings>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IBreeder Breeder
        {
            get
            {
                return GetScenarioContextItemOrDefault<IBreeder>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IPopulation Population
        {
            get
            {
                return GetScenarioContextItemOrDefault<IPopulation>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected IEnumerable<IPopulation> Populations
        {
            get
            {
                return GetScenarioContextItemOrDefault<IEnumerable<IPopulation>>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected List<IPopulation> PopulationSearchResults
        {
            get
            {
                return GetScenarioContextItemOrDefault<List<IPopulation>>(nameof(PopulationSearchResults));
            }
            set
            {
                CurrentContext.Set(value, nameof(PopulationSearchResults));
            }
        }

        protected IDataAccess DataAccess
        {
            get
            {
                return GetScenarioContextItemOrDefault<IDataAccess>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected RegionSettings RegionSettings
        {
            get
            {
                return GetScenarioContextItemOrDefault<RegionSettings>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected List<IRegion> Regions
        {
            get
            {
                return GetScenarioContextItemOrDefault<List<IRegion>>(nameof(Regions));
            }
            set
            {
                CurrentContext.Set(value, nameof(Regions));
            }
        }


        protected void Invoke(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (ExpectingException)
                {
                    Exception = ex;
                }
                else
                {
                    throw;
                }
            }
        }

        protected T GetScenarioContextItemOrDefault<T>(string key = null)
        {
            var keyName = key ?? typeof(T).FullName;

            if (CurrentContext.ContainsKey(keyName))
            {
                return CurrentContext.Get<T>(keyName);
            }
            else
            {
                return default(T);
            }
        }
    }
}
