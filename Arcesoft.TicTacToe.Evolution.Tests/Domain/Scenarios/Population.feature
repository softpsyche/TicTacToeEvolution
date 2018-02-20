@Domain
Feature: Population
Verify that the population is working as expected

Background: 
	Given I have a container

Scenario: Population should promote fittest in one cycle
	Given I have an evolution factory
	Given I have the following evolution settings
         | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit | MaximumGenesPerIndividual | BreederType | FitnessEvaluatorType | MatchTournaments |
         | 0            | 10                    | 5                           | 2                         | ASexual     | AllOrNothing         | 5                |
	Given I have a population
	Given I have an individual called 'SuperSayan' with id '10000000-0000-0000-0000-000000000000' and with the following genes
		| Turn  | Priority | Alleles   |
		| First | 0        | ____R____ |
		| Third | 0        | DDDDDDDDR |
	Given I add my individual to the population
	When I evolve the population '1' times
	Then I expect the population to contain '2' individuals with parent ids '10000000-0000-0000-0000-000000000000' and the following genes
		| Turn  | Priority | Alleles   |
		| First | 0        | ____R____ |
		| Third | 0        | DDDDDDDDR |

@ignore
Scenario: Population should promote fittest for many cycles
	Given I have an evolution factory
	Given I have the following evolution settings
         | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit | MaximumGenesPerIndividual | BreederType | FitnessEvaluatorType | MatchTournaments |
         | 0            | 10                    | 5                           | 2                         | ASexual     | AllOrNothing         | 5                |
	Given I have a population
	Given I have an individual called 'SuperSayan' with id '10000000-0000-0000-0000-000000000000' and with the following genes
		| Turn  | Priority | Alleles   |
		| First | 0        | ____R____ |
		| Third | 0        | DDDDDDDDR |
	Given I add my individual to the population
	When I evolve the population '1000' times
	Then I expect the entire population to contain the following genes
		| Turn  | Priority | Alleles   |
		| First | 0        | ____R____ |
		| Third | 0        | DDDDDDDDR |


