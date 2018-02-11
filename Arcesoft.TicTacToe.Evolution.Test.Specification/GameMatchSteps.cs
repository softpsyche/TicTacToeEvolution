using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using Moq;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
using System.Linq;

namespace Arcesoft.TicTacToe.Evolution.Test.Specification
{

	[Binding]
	public class GameMatchSteps : Steps
	{
		private List<Individual> Individuals
		{
			get
			{
				return ScenarioContext.Current.Get<List<Individual>>();
			}
			set
			{
				ScenarioContext.Current.Set<List<Individual>>(value);
			}
		}
		private GameMatch GameMatch
		{
			get
			{
				return ScenarioContext.Current.Get<GameMatch>();
			}
			set
			{
				ScenarioContext.Current.Set(value);
			}
		}
		private Individual GetIndividual(String name)
		{
			return this.Individuals.Single(a => a.Name == name);
		}




		[Given(@"I have the following individuals")]
		public void GivenIHaveTheFollowingIndividuals(Table table)
		{
			this.Individuals = this.Breeder.NewIndividuals(table.Rows.Select(a => a[0]).ToArray());
		}

		[Given(@"I have a gamematch with individual '(.*)' as player X and individual '(.*)' as player O")]
		public void GivenIHaveAGamematchWithIndividualAsPlayerXAndIndividualAsPlayerO(string p0, string p1)
		{
			this.GameMatch = new GameMatch(
				new Game(),
				GetIndividual(p0),
				GetIndividual(p1),
				new FitnessScore(),
				new FitnessScore());
		}


		[When(@"I evaluate the game match")]
		public void WhenIEvaluateTheGameMatch()
		{
			this.GameMatch.Evaluate();
		}

		[Then(@"The fitness score for player '(.*)' should be '(.*)'")]
		public void ThenTheFitnessScoreForPlayerShouldBe(string p0, Double p1)
		{
			this.GameMatch
				.GetPlayerAndScoreByName(p0)
				.Item2.Total
				.Should().Be(p1);
		}

		[Then(@"The match game board should look like")]
		public void ThenTheMatchGameBoardShouldLookLike(Table table)
		{
			this.GameMatch.GameBoardString.Should().Be(this.TranslateToBoardState(table));
		}



	}

}
