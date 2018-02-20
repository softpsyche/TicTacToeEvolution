@Integration
Feature: Persistance
	Verify persistance functionality

Background: 
	Given I have a container
	Given I have an evolution factory
	Given I have a data access
	Given I delete all individuals

Scenario: Data access should save population
	Given I have the following evolution settings
        | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit | MaximumGenesPerIndividual | BreederType | FitnessEvaluatorType | MatchTournaments |
        | 0            | 2                     | 5                           | 2                         | ASexual     | AllOrNothing         | 1                |
	Given I delete the following populations
		| Id                                   |
		| 99000000-0000-0000-0000-000000000000 |
	Given I have the following population
		| Id                                   | Name    | Generation |
		| 99000000-0000-0000-0000-000000000000 | Giggidy | 5500       |
	Given I clear all individuals from my population
	Given I add an individual called 'Alpha' with id '10000000-0000-0000-0000-000000000000' and with the following genes to my population
		| Turn  | Priority | Alleles   |
		| First | 3       | ____R____ |
		| Ninth | 34       | DDDDDDDDR |
	Given I add an individual called 'Beta' with id '20000000-0000-0000-0000-000000000000' and with the following genes to my population
		| Turn   | Priority | Alleles   |
		| Second | 22       | __R__X___ |
		| Third  | 4       | DDD__DDDR |
	Given I add an individual called 'Gamma' with id '30000000-0000-0000-0000-000000000000' and with the following genes to my population
		| Turn   | Priority | Alleles   |
		| Fourth | 1       | XO__R____ |
		| Eigth  | 20       | __DDDDDDR |
	Given I add an individual called 'Cappa' with id '40000000-0000-0000-0000-000000000000' and with the following genes to my population
		| Turn   | Priority | Alleles   |
		| Fourth | 9       | XO__R____ |
		| Eigth  | 20       | __DDDDDDR |
	Given I save my population
	Then I expect the saved population to contain
		| Id                                   | Name    | Generation |
		| 99000000-0000-0000-0000-000000000000 | Giggidy | 5500       |
	Then I expect the saved population to contain the following evolution settings
		| MutationRate | MaximumPopulationSize | IndividualChildBearingLimit | MaximumGenesPerIndividual | BreederType | FitnessEvaluatorType | MatchTournaments |
        | 0            | 2                     | 5                           | 2                         | ASexual     | AllOrNothing         | 1                |
	Then I expect the saved population to contain the following individuals
		| Id                                   | Name  | Turn   | Priority | Alleles   |
		| 10000000-0000-0000-0000-000000000000 | Alpha | First  | 3        | ____R____ |
		| 10000000-0000-0000-0000-000000000000 | Alpha | Ninth  | 34       | DDDDDDDDR |
		| 20000000-0000-0000-0000-000000000000 | Beta  | Second | 22       | __R__X___ |
		| 20000000-0000-0000-0000-000000000000 | Beta  | Third  | 4        | DDD__DDDR |
		| 30000000-0000-0000-0000-000000000000 | Gamma | Fourth | 1        | XO__R____ |
		| 30000000-0000-0000-0000-000000000000 | Gamma | Eigth  | 20       | __DDDDDDR |
		| 40000000-0000-0000-0000-000000000000 | Cappa | Fourth | 9        | XO__R____ |
		| 40000000-0000-0000-0000-000000000000 | Cappa | Eigth  | 20       | __DDDDDDR |

Scenario: Data access should find populations
	Given I have the following evolution settings
        | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit | MaximumGenesPerIndividual | BreederType | FitnessEvaluatorType | MatchTournaments |
        | 0            | 2                     | 5                           | 2                         | ASexual     | AllOrNothing         | 1                |
	Given I delete the following populations
		| Id                                   |
		| 10000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 30000000-0000-0000-0000-000000000000 |
		| 40000000-0000-0000-0000-000000000000 |
	Given I have the following populations
		| Id                                   | Name                      |
		| 10000000-0000-0000-0000-000000000000 | Giggidy                   |
		| 20000000-0000-0000-0000-000000000000 | Giggid                    |
		| 30000000-0000-0000-0000-000000000000 | QuagmadiusGiggidyTheThird |
		| 40000000-0000-0000-0000-000000000000 | Coolio                    |
	Given I save my populations
	When I find populations by name 'gIGgIDY'
	Then I expect the find populations search results to only contain
		| Id                                   | Name                      |
		| 10000000-0000-0000-0000-000000000000 | Giggidy                   |
		| 30000000-0000-0000-0000-000000000000 | QuagmadiusGiggidyTheThird |

