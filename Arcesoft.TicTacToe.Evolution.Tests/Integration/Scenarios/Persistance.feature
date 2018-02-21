@Integration
Feature: Persistance
	Verify persistance functionality

Background: 
	Given I have a container
	Given I have an evolution factory
	Given I have a data access
	Given I delete all individuals
	Given I delete all regions

Scenario: Data access should save population
	Given I have the following population settings
        | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit | MaximumGenesPerIndividual | BreederType | FitnessEvaluatorType | MatchTournaments |
        | 0            | 2                     | 5                           | 2                         | ASexual     | AllOrNothing         | 1                |
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
	When I save my population
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
	Given I have the following population settings
        | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit | MaximumGenesPerIndividual | BreederType | FitnessEvaluatorType | MatchTournaments |
        | 0            | 2                     | 5                           | 2                         | ASexual     | AllOrNothing         | 1                |
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

Scenario: Data access should save region
	Given I have the following population settings
        | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit | MaximumGenesPerIndividual | BreederType | FitnessEvaluatorType | MatchTournaments |
        | 0            | 2                     | 5                           | 2                         | ASexual     | AllOrNothing         | 1                |
	Given I have the following populations
		| Id                                   | Name  | Generation |
		| 10000000-0000-0000-0000-000000000000 | Alpha | 1500       |
		| 20000000-0000-0000-0000-000000000000 | Beta  | 110        |
		| 30000000-0000-0000-0000-000000000000 | Cappa | 70         |
	Given I evolve the populations '1' times
	Given I save my populations
	Given I have the following region settings
		| InternalMigrationEnabled | ExternalMigrationEnabled | 
		| true                     | true                     | 
	Given I have the following regions
		| Id                                   | Name  | DateCreated | Age |
		| 880000000-0000-0000-0000-00000000000 | Bob   | 10/18/1978  | 33  |
		| 990000000-0000-0000-0000-00000000000 | Sally | 9/14/2012   | 8   |
	Given I add the following given populations to region '880000000-0000-0000-0000-00000000000'
		| Id                                   |
		| 10000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
	Given I add the following given populations to region '990000000-0000-0000-0000-00000000000'
		| Id                                   |
		| 30000000-0000-0000-0000-000000000000 |
	When I save my regions
	Then I expect the saved region '880000000-0000-0000-0000-00000000000' to contain
		| Id                                   | Name | DateCreated                  | Age |
		| 880000000-0000-0000-0000-00000000000 | Bob  | 10/18/1978 7:00:00 AM +00:00 | 33  |
	Then I expect the saved region '880000000-0000-0000-0000-00000000000' to contain the following populations
		| Id                                   |
		| 10000000-0000-0000-0000-000000000000 | 
		| 20000000-0000-0000-0000-000000000000 | 
	Then I expect the saved region '990000000-0000-0000-0000-00000000000' to contain
		| Id                                  | Name  | DateCreated                 | Age |
		| 99000000-0000-0000-0000-00000000000 | Sally | 9/14/2012 7:00:00 AM +00:00 | 8   |
	Then I expect the saved region '990000000-0000-0000-0000-00000000000' to contain the following populations
		| Id                                  |
		| 30000000-0000-0000-0000-00000000000 |

Scenario: Data access should search regions by name
	Given I have the following regions
		| Id                                   | Name                      | DateCreated                  |
		| 10000000-0000-0000-0000-000000000000 | Giggidy                   | 10/18/1978 7:00:00 AM +00:00 |
		| 20000000-0000-0000-0000-000000000000 | Giggid                    | 10/19/1978 7:00:00 AM +00:00 |
		| 30000000-0000-0000-0000-000000000000 | QuagmadiusGiggidyTheThird | 10/20/1978 7:00:00 AM +00:00 |
		| 40000000-0000-0000-0000-000000000000 | Coolio                    | 10/21/1978 7:00:00 AM +00:00 |
	Given I save my regions
	When I find regions by name 'gIGgIDY'
	Then I expect the search regions to only contain
		| Id                                   | Name                      | DateCreated                  |
		| 10000000-0000-0000-0000-000000000000 | Giggidy                   | 10/18/1978 7:00:00 AM +00:00 |
		| 30000000-0000-0000-0000-000000000000 | QuagmadiusGiggidyTheThird | 10/20/1978 7:00:00 AM +00:00 |
#need better test for one below...
Scenario: Data access should search regions most recent
	Given I have the following regions
		| Id                                   | Name                      | 
		| 10000000-0000-0000-0000-000000000000 | Giggidy                   | 
		| 20000000-0000-0000-0000-000000000000 | Giggid                    | 
		| 30000000-0000-0000-0000-000000000000 | QuagmadiusGiggidyTheThird | 
		| 40000000-0000-0000-0000-000000000000 | Coolio                    | 
	Given I save my regions
	When I find regions by most recent '10' days with a limit of '10'
	Then I expect the search regions to only contain
		| Id                                   | Name                      | 
		| 10000000-0000-0000-0000-000000000000 | Giggidy                   | 
		| 20000000-0000-0000-0000-000000000000 | Giggid                    | 
		| 30000000-0000-0000-0000-000000000000 | QuagmadiusGiggidyTheThird | 
		| 40000000-0000-0000-0000-000000000000 | Coolio                    | 



