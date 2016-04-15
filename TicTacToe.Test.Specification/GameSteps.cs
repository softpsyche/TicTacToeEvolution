using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;

namespace TicTacToe.Test.Specification
{

	[Binding]//this is all you need for specflow to see this class as have step definitions bound
	public class GameSteps
	{
		private Game Game
		{
			get
			{
				return ScenarioContext.Current.Get<Game>();
			}
			set
			{
				ScenarioContext.Current.Set(value);
			}
		}
		private GameException GameException
		{
			get
			{
				if (ScenarioContext.Current.ContainsKey("LastException"))
				{
					return ScenarioContext.Current.Get<GameException>("LastException");
				}

				return null;
			}
			set
			{
				ScenarioContext.Current.Set(value, "LastException");
			}
		}

		private String TranslateToBoardState(Table table)
		{
			StringBuilder sb = new StringBuilder();

			foreach (var row in table.Rows)
			{
				foreach (var column in row)
				{
					sb.Append(column.Value);
				}
			}

			return sb.ToString();
		}


		[Given(@"I create a new tic tac toe game")]
		public void GivenICreateANewTicTacToeGame()
		{
			this.Game = new Game();
		}

		[When(@"I make the following move ""(.*)""")]
		[Given(@"I make the following move ""(.*)""")]
		public void GivenIMakeTheFollowingMove(String p0)
		{
			var pieces = Regex.Split(p0, ",");
			var x = Convert.ToInt32(pieces[0]);
			var y = Convert.ToInt32(pieces[1]);

			Game.MakeMove(x, y);
		}

		[When(@"I reset the game")]
		public void WhenIResetTheGame()
		{
			this.Game.Reset();
		}

		[Then(@"The board should be empty")]
		public void ThenTheBoardShouldBeEmpty()
		{
			Assert.AreEqual(this.Game.GameBoardString, "_________");
		}

		[Then(@"The current players turn should be ""(.*)""")]
		public void ThenTheCurrentPlayersTurnShouldBe(Player p0)
		{
			Assert.AreEqual(this.Game.PlayerTurn, p0);
		}

		[Then(@"The current game state should be ""(.*)""")]
		public void ThenTheCurrentGameStateShouldBe(GameState p0)
		{
			Assert.AreEqual(this.Game.GameState, p0);
		}

		[Then(@"The number of moves made should be ""(.*)""")]
		public void ThenTheNumberOfMovesShouldBe(int p0)
		{
			Assert.AreEqual(this.Game.MovesMade, p0);
		}

		[When(@"I create a new tic tac toe game")]
		public void WhenICreateANewTicTacToeGame()
		{
			this.Game = new Game();
		}





		[When(@"I make the following moves")]
		public void WhenIMakeTheFollowingMoves(Table table)
		{
			var gameMoves = table.CreateSet<GameMove>().ToList();

			gameMoves.ForEach(a => this.Game.MakeMove(a));
		}






		[When(@"I make a move to the northwest square")]
		[Given(@"I make a move to the northwest square")]
		public void GivenIMakeAMoveToTheNorthwestSquare()
		{
			this.Game.MakeMove(0, 0);
		}
		[When(@"I make a move to the northern square")]
		[Given(@"I make a move to the northern square")]
		public void GivenIMakeAMoveToTheNorthernSquare()
		{
			this.Game.MakeMove(0, 1);
		}
		[When(@"I make a move to the northeast square")]
		[Given(@"I make a move to the northeast square")]
		public void GivenIMakeAMoveToTheNortheastSquare()
		{
			this.Game.MakeMove(0, 2);
		}
		[When(@"I make a move to the western square")]
		[Given(@"I make a move to the western square")]
		public void GivenIMakeAMoveToTheWesternSquare()
		{
			this.Game.MakeMove(1, 0);
		}
		[When(@"I make a move to the center square")]
		[Given(@"I make a move to the center square")]
		public void GivenIMakeAMoveToTheCenterSquare()
		{
			this.Game.MakeMove(1, 1);
		}
		[When(@"I make a move to the eastern square")]
		[Given(@"I make a move to the eastern square")]
		public void GivenIMakeAMoveToTheEasternSquare()
		{
			this.Game.MakeMove(1, 2);
		}
		[When(@"I make a move to the southwest square")]
		[Given(@"I make a move to the southwest square")]
		public void GivenIMakeAMoveToTheSouthwestSquare()
		{
			this.Game.MakeMove(2, 0);
		}
		[When(@"I make a move to the southern square")]
		[Given(@"I make a move to the southern square")]
		public void GivenIMakeAMoveToTheSouthernSquare()
		{
			this.Game.MakeMove(2, 1);
		}
		[When(@"I make a move to the southeast square")]
		[Given(@"I make a move to the southeast square")]
		public void GivenIMakeAMoveToTheSoutheastSquare()
		{
			this.Game.MakeMove(2, 2);
		}


		[Given(@"I have the following board state")]
		public void GivenIHaveTheFollowingBoardState(Table table)
		{
			this.Game = new Game(TranslateToBoardState(table));
		}

		[When(@"I try to make the move ""(.*)""")]
		public void WhenITryToMakeTheMove(MoveDirection p0)
		{
			try
			{
				this.Game.MakeMove(p0);
			}
			catch (GameException exception)
			{
				this.GameException = exception;
			}
		}

		[Then(@"The outcome should be ""(.*)""")]
		public void ThenTheOutcomeShouldBe(string p0)
		{
			if (GameException != null)
			{
				Assert.AreEqual(p0, "InvalidMove");
			}
			else
			{
				Assert.AreEqual(p0, this.Game.GameState.ToString());
			}
		}

		[Then(@"The game board should look like")]
		public void ThenTheGameBoardShouldLookLike(Table table)
		{
			this.TranslateToBoardState(table).Should().Be(this.Game.GameBoardString);
		}




	}
}
