using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Moq;
using SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;
using FluentAssertions;
using Arcesoft.TicTacToe.Evolution.Reproduction.Strategies;
using TechTalk.SpecFlow.Assist;
using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Evolution.Selection;

namespace Arcesoft.TicTacToe.Evolution.Tests.Domain
{
    [Binding]
    class ReproductionSteps : Steps
    {


        [Given(@"I have an asexual breeder")]
        public void GivenIHaveAnAsexualBreeder()
        {
            Breeder = Container.GetInstance<AsexualBreeder>();
        }

        [Given(@"I have the following genes on my individuals")]
        public void GivenIHaveTheFollowingGenesOnMyIndividuals(Table table)
        {
            table
                .Rows
                .GroupBy(a => new Guid(a["IndividualId"]))
                .ForEach(a =>
                {
                    var individual = Individuals.Single(b => b.Id == a.Key);

                    individual.Genes = a.Select(b => b.ToGene());
                });
        }

        [Given(@"I have the following fitness scores for my individuals")]
        public void GivenIHaveTheFollowingFitnessScoresForMyIndividuals(Table table)
        {
            FitnessScores = table.CreateSet((row) =>
            {
                var fitnessScore = new FitnessScore()
                {
                    Individual = Individuals.Single(a => a.Id == new Guid(row["IndividualId"]))
                };

                row.FillInstance(fitnessScore);

                return fitnessScore;
            }).ToList();
        }

        [When(@"I breed my individuals")]
        public void WhenIBreedMyIndividuals()
        {
            Invoke(() => Individuals = Breeder.Breed(FitnessScores, EvolutionSettings).ToArray());
        }

        [Then(@"I expect the new generation of individuals to contain")]
        public void ThenIExpectTheNewGenerationOfIndividualsToContain(Table table)
        {
            table
                .CompareToSet(Individuals.Select(a => new { ParentIds = a.ToParentIdsString() }));
        }

        [Then(@"I expect the size of the new generation to be exactly '(.*)'")]
        public void ThenIExpectTheSizeOfTheNewGenerationToBeExactly(int size)
        {
            Individuals.Length.Should().Be(size);
        }


        [Then(@"I expect '(.*)' individuals with parents '(.*)' to contain the following genes")]
        public void ThenIExpectIndividualsWithParentsToContainTheFollowingGenes(int count, string parentIds, Table table)
        {
            var subset = Individuals
                .Where(a => a.ToParentIdsString() == parentIds)
                .ToList();

            subset.Count.Should().Be(count);

            subset
                .ForEach(a =>
                {
                    table.CompareToSet(a.Genes.Select(b => new
                    {
                        b.Turn,
                        b.Priority,
                        Alleles = b.GetAlleles().ToAlleleString()
                    }
                    ));
                });
               
        }

    }
}
