using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using SimpleInjector;
using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Entities;
using System.Collections.Generic;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    public abstract class Steps
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
