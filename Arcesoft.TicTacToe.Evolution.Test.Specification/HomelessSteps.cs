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
	public class HomelessSteps : Steps
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
		private IEnumerable<FitnessResult> FitnessResults
		{
			get
			{
				return ScenarioContext.Current.Get<IEnumerable<FitnessResult>>();
			}
			set
			{
				ScenarioContext.Current.Set<IEnumerable<FitnessResult>>(value);
			}
		}
		private List<GameMatch> Matches
		{
			get
			{
				List<GameMatch> matches;

				if (ScenarioContext.Current.TryGetValue<List<GameMatch>>(out matches) == false)
				{
					matches = new List<GameMatch>();

					this.FitnessResults.ForEach(a => matches.AddRange(a.Matches.Where(b => b.XPlayer.Name == a.Individual.Name)));

					ScenarioContext.Current.Set<List<GameMatch>>(matches);
				}

				return matches;
			}
		}


		private Selector FitnessCalculator
		{
			get
			{
				return null;//EvolutionContext.CreateSelector();
			}
			set
			{
				//this.MockEvolutionContext.Setup(a => a.CreateSelector()).Returns(value);
			}
		}


		[Then(@"The fitness scores should be")]
		public void ThenTheFitnessScoresShouldBe(Table table)
		{
			table.CompareToSet(this.FitnessResults);
		}

		[Given(@"I have a breeder")]
		public void GivenIHaveABreeder()
		{
			//this.Breeder = new Breeder(this.EvolutionContext);
		}
		[Given(@"I have a fitness calculator")]
		public void GivenIHaveAFitnessCalculator()
		{
			//this.FitnessCalculator = new Selector(this.EvolutionContext);
		}


		[Then(@"The matches should contain")]
		public void ThenTheMatchesShouldContain(Table table)
		{
			table.CompareToSet(this.Matches.ToSpecflowGameMatches());
		}

		[Then(@"The matches count should be (.*)")]
		public void ThenTheMatchesCountShouldBe(int p0)
		{
			this.Matches.Count().Should().Be(p0);
		}






		[Given(@"I have the following genes for individual '(.*)'")]
		public void GivenIHaveTheFollowingGenesForIndividual(string p0, Table table)
		{
			var individual = this.Individuals.Single(a => a.Name.Equals(p0, StringComparison.InvariantCultureIgnoreCase));

			individual.SetGenes(table.ToGenes());
		}

		[When(@"I evaluate fitness")]
		public void WhenIEvaluateFitness()
		{
			this.FitnessResults = this.FitnessCalculator.EvaluateFitness(this.Individuals);
		}





	}



}
