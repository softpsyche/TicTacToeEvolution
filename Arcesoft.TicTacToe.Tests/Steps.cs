﻿using Arcesoft.TicTacToe.Data;
using Arcesoft.TicTacToe.Database;
using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.GameImplementation;
using FluentAssertions;
using Moq;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Arcesoft.TicTacToe.Tests
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

        protected IArtificialIntelligence ArtificialIntelligence
        {
            get
            {
                return GetScenarioContextItemOrDefault<IArtificialIntelligence>(nameof(ArtificialIntelligence));
            }
            set
            {
                CurrentContext.Set(value, nameof(ArtificialIntelligence));
            }
        }

        protected IEnumerable<MoveResult> MoveResults
        {
            get
            {
                return GetScenarioContextItemOrDefault<IEnumerable<MoveResult>>(nameof(MoveResults));
            }
            set
            {
                CurrentContext.Set(value, nameof(MoveResults));
            }
        }

        protected IDatabaseBuilder DatabaseBuilder
        {
            get
            {
                return GetScenarioContextItemOrDefault<IDatabaseBuilder>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected GameEventListener GameEventListener
        {
            get
            {
                return GetScenarioContextItemOrDefault<GameEventListener>();
            }
            set
            {
                CurrentContext.Set(value);
            }
        }

        protected Mock<IDatabaseBuilder> MockMoveDatabase
        {
            get
            {
                return GetScenarioContextItemOrDefault<Mock<IDatabaseBuilder>>(nameof(MockMoveDatabase));
            }
            set
            {
                CurrentContext.Set(value, nameof(MockMoveDatabase));
            }
        }

        protected Mock<ILiteDatabaseFactory> MockLiteDatabaseFactory
        {
            get
            {
                return GetScenarioContextItemOrDefault<Mock<ILiteDatabaseFactory>>(nameof(MockLiteDatabaseFactory));
            }
            set
            {
                CurrentContext.Set(value, nameof(MockLiteDatabaseFactory));
            }
        }

        protected Mock<ILiteDatabase> MockLiteDatabase
        {
            get
            {
                return GetScenarioContextItemOrDefault<Mock<ILiteDatabase>>(nameof(MockLiteDatabase));
            }
            set
            {
                CurrentContext.Set(value, nameof(MockLiteDatabase));
            }
        }

        private T GetScenarioContextItemOrDefault<T>(string key = null)
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

        protected IEnumerable<Move> ToPlausibleMoveListFromBoardState(Table table)
        {
            var boardString = ToBoardString(table);
            List<Move> plausibleMoveList = new List<Move>();
            List<Move> xMoves = new List<Move>();
            List<Move> oMoves = new List<Move>();

            for (int i = 0; i < boardString.Length; i++)
            {
                switch (boardString[i])
                {
                    case BoardConstants.SquareXChar:
                        xMoves.Add((Move)i);
                        break;
                    case BoardConstants.SquareOChar:
                        oMoves.Add((Move)i);
                        break;
                }
            }

            Player curPlayer = Player.X;
            var totalMoves = xMoves.Count + oMoves.Count;
            for (int i = 0; i < totalMoves; i++)
            {
                if (curPlayer == Player.X)
                {
                    plausibleMoveList.Add(xMoves.First());
                    xMoves.Remove(xMoves.First());
                    curPlayer = Player.O;
                }
                else
                {
                    plausibleMoveList.Add(oMoves.First());
                    oMoves.Remove(oMoves.First());
                    curPlayer = Player.X;
                }

            }

            return plausibleMoveList;
        }
        protected string ToBoardString(Table table)
        {
            StringBuilder sb = new StringBuilder();

            table.Rows.Count.Should().Be(3, "The table should have three rows");
            table.Rows[0].Count.Should().Be(3, "Each row in the table should have 3 entries");

            table.Rows.ForEach(a => sb.Append(string.Concat(ToSquareValues(a.Values))));

            return sb.ToString();
        }
        private IEnumerable<String> ToSquareValues(IEnumerable<string> values)
        {
            return values.Select(a => ToSquareValue(a));
        }
        private string ToSquareValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return BoardConstants.SquareEmptyString;
            }
            else if (BoardConstants.SquareXString.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                return BoardConstants.SquareXString;
            }
            else if (BoardConstants.SquareOString.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                return BoardConstants.SquareOString;
            }
            else
            {
                throw new InvalidOperationException($"Unable to create square value for string because the value '{value}' is not a valid tic tac toe board value");
            }
        }

        protected IEnumerable<Move> ToMoves(Table table)
        {
            return table.CreateSet((a) => a[0].ToEnumeration<Move>());
        }
        protected IEnumerable<Move> ToMoves(string commaDelimitedMoves)
        {
            return commaDelimitedMoves
                .Split(',')
                .Select(a => a.ToEnumeration<Move>());
        }
    }
}
