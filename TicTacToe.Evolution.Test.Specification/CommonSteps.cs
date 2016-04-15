using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using Moq;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
using System.Linq;
using System.Text;

namespace TicTacToe.Evolution.Test.Specification
{


	[Binding]
	public class CommonSteps : Steps
	{
		[Given(@"I have a mock evolution context")]
		public void GivenIHaveAnEvolutionContext()
		{
			this.MockEvolutionContext = new Mock<EvolutionContext>()
			{
				CallBase = true
			};
		}
		[Given(@"I have the following evolution settings")]
		public void GivenIHaveTheFollowingEvolutionSettings(Table table)
		{
			var instance = table.CreateInstance<EvolutionSettings>();

			this.MockEvolutionContext
				.Setup(a => a.EvolutionSettings)
				.Returns(instance);
		}
		[Given(@"I have a random number generator with seed (.*)")]
		public void GivenIHaveARandomNumberGeneratorWithSeed(int p0)
		{
			this.MockEvolutionContext.Setup(a => a.CreateRandom()).Returns(new GameRng(p0));
		}


	}

	public abstract class Steps
	{
		protected Mock<EvolutionContext> MockEvolutionContext
		{
			get
			{
				return ScenarioContext.Current.Get<Mock<EvolutionContext>>();
			}
			set
			{
				ScenarioContext.Current.Set<Mock<EvolutionContext>>(value);
			}
		}
		protected IEvolutionContext EvolutionContext
		{
			get
			{
				return MockEvolutionContext.Object;
			}
		}
		protected Breeder Breeder
		{
			get
			{
				return EvolutionContext.CreateBreeder();
			}
			set
			{
				this.MockEvolutionContext.Setup(a => a.CreateBreeder()).Returns(value);
			}
		}

		protected String TranslateToBoardState(Table table)
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
	}

	public class SpecflowGene
	{
		public Int32 Move { get; set; }
		public Int32 Priority { get; set; }
		public String NorthWest { get; set; }
		public String Northern { get; set; }
		public String NorthEast { get; set; }
		public String Western { get; set; }
		public String Center { get; set; }
		public String Eastern { get; set; }
		public String SouthWest { get; set; }
		public String Southern { get; set; }
		public String SouthEast { get; set; }

		public Allele[] Alleles
		{
			get
			{
				return new Allele[]
				{
					NorthWest.ToAllele(),
					Northern.ToAllele(),
					NorthEast.ToAllele(),
					Western.ToAllele(),
					Center.ToAllele(),
					Eastern.ToAllele(),
					SouthWest.ToAllele(),
					Southern.ToAllele(),
					SouthEast.ToAllele(),
				};
			}
		}
	}
	public static class SpecflowExtensions
	{
		public static Allele ToAllele(this String value)
		{
			return (Allele)Enum.Parse(typeof(Allele), value);
		}
		public static IEnumerable<Gene> ToGenes(this Table table)
		{
			return table
				.CreateSet<SpecflowGene>()
				.Select(a => a.ToGene())
				.ToArray();
		}
		public static Gene ToGene(this SpecflowGene specflowGene)
		{
			return new Gene(
				specflowGene.Move,
				specflowGene.Priority,
				specflowGene.Alleles);
		}
		public static IEnumerable<SpecflowGameMatch> ToSpecflowGameMatches(this IEnumerable<GameMatch> gameMatches)
		{
			return gameMatches.ToList().Select(a => new SpecflowGameMatch()
			{
				X = a.XPlayer.Name,
				O = a.OPlayer.Name
			}).ToList();
		}
	}

	public class SpecflowGameMatch
	{
		public String X { get; set; }
		public String O { get; set; }
	}

}
