@Domain
Feature: Reproduction
	Validate all reproduction type functions

Background: 
	Given I have a container
	Given I have a tictactoe factory
	Given I have an evolution factory

Scenario: ASexual breeder should breed individuals
	Given I have the following evolution settings
         | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit |
         | 1.0          | 10                    | 5                           |
	Given I have an asexual breeder
	Given I have the following individuals
        | Name    | Id                                   |
        | Alpha   | 10000000-0000-0000-0000-000000000000 |
        | Beta    | 20000000-0000-0000-0000-000000000000 |
        | Gamma   | 30000000-0000-0000-0000-000000000000 |
        | Delta   | 40000000-0000-0000-0000-000000000000 |
	Given I have the following genes on my individuals
		| IndividualId                         | Turn   | Priority | Alleles   |
		| 10000000-0000-0000-0000-000000000000 | First  | 10       | DDD_X_ORA |
		| 10000000-0000-0000-0000-000000000000 | Second | 20       | RDX_X_ODA |
		| 20000000-0000-0000-0000-000000000000 | Third  | 50       | DXO___RAA |
		| 30000000-0000-0000-0000-000000000000 | Fourth | 25       | DDD_O_DDD |
		| 40000000-0000-0000-0000-000000000000 | Fifth  | 5        | DDDDDDDDD |
	Given I have the following fitness scores for my individuals
		| IndividualId                         | Score | PercentageOfAllScores |
		| 10000000-0000-0000-0000-000000000000 | .30   | 0.30                  |
		| 20000000-0000-0000-0000-000000000000 | .50   | 0.50                  |
		| 30000000-0000-0000-0000-000000000000 | .20   | 0.20                  |
		| 40000000-0000-0000-0000-000000000000 | .0    | 0                     |
	When I breed my individuals
	Then I expect the new generation of individuals to contain
		| ParentIds                            |
		| 10000000-0000-0000-0000-000000000000 |
		| 10000000-0000-0000-0000-000000000000 |
		| 10000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 30000000-0000-0000-0000-000000000000 |
		| 30000000-0000-0000-0000-000000000000 |
	Then I expect the size of the new generation to be exactly '10'
	Then I expect '3' individuals with parents '10000000-0000-0000-0000-000000000000' to contain the following genes
         | Turn   | Priority | Alleles   |
         | First  | 10       | DDD_X_ORA |
         | Second | 20       | RDX_X_ODA |
	Then I expect '5' individuals with parents '20000000-0000-0000-0000-000000000000' to contain the following genes
         | Turn  | Priority | Alleles   |
         | Third | 50       | DXO___RAA |
	Then I expect '2' individuals with parents '30000000-0000-0000-0000-000000000000' to contain the following genes
         | Turn   | Priority | Alleles   |
         | Fourth | 25       | DDD_O_DDD |

Scenario: ASexual breeder should downsize population accordingly
	Given I have the following evolution settings
         | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit |
         | 1.0          | 3                     | 5                           |
	Given I have an asexual breeder
	Given I have the following individuals
        | Name    | Id                                   |
        | Alpha   | 10000000-0000-0000-0000-000000000000 |
        | Beta    | 20000000-0000-0000-0000-000000000000 |
        | Gamma   | 30000000-0000-0000-0000-000000000000 |
        | Delta   | 40000000-0000-0000-0000-000000000000 |
	Given I have the following genes on my individuals
		| IndividualId                         | Turn   | Priority | Alleles   |
		| 10000000-0000-0000-0000-000000000000 | First  | 10       | DDD_X_ORA |
		| 10000000-0000-0000-0000-000000000000 | Second | 20       | RDX_X_ODA |
		| 20000000-0000-0000-0000-000000000000 | Third  | 50       | DXO___RAA |
		| 30000000-0000-0000-0000-000000000000 | Fourth | 25       | DDD_O_DDD |
		| 40000000-0000-0000-0000-000000000000 | Fifth  | 5        | DDDDDDDDD |
	Given I have the following fitness scores for my individuals
		| IndividualId                         | Score | PercentageOfAllScores |
		| 10000000-0000-0000-0000-000000000000 | .30   | 0.30                  |
		| 20000000-0000-0000-0000-000000000000 | .50   | 0.50                  |
		| 30000000-0000-0000-0000-000000000000 | .20   | 0.20                  |
		| 40000000-0000-0000-0000-000000000000 | .0    | 0                     |
	When I breed my individuals
	Then I expect the new generation of individuals to contain
		| ParentIds                            |
		| 10000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
	Then I expect the size of the new generation to be exactly '3'

Scenario: ASexual breeder should obey child bearing limits
	Given I have the following evolution settings
         | MutationRate | MaximumPopulationSize | IndividualChildBearingLimit |
         | 1.0          | 10                    | 3                           |
	Given I have an asexual breeder
	Given I have the following individuals
        | Name    | Id                                   |
        | Alpha   | 10000000-0000-0000-0000-000000000000 |
        | Beta    | 20000000-0000-0000-0000-000000000000 |
        | Gamma   | 30000000-0000-0000-0000-000000000000 |
        | Delta   | 40000000-0000-0000-0000-000000000000 |
	Given I have the following genes on my individuals
		| IndividualId                         | Turn   | Priority | Alleles   |
		| 10000000-0000-0000-0000-000000000000 | First  | 10       | DDD_X_ORA |
		| 10000000-0000-0000-0000-000000000000 | Second | 20       | RDX_X_ODA |
		| 20000000-0000-0000-0000-000000000000 | Third  | 50       | DXO___RAA |
		| 30000000-0000-0000-0000-000000000000 | Fourth | 25       | DDD_O_DDD |
		| 40000000-0000-0000-0000-000000000000 | Fifth  | 5        | DDDDDDDDD |
	Given I have the following fitness scores for my individuals
		| IndividualId                         | Score | PercentageOfAllScores |
		| 10000000-0000-0000-0000-000000000000 | .30   | 0.30                  |
		| 20000000-0000-0000-0000-000000000000 | .50   | 0.50                  |
		| 30000000-0000-0000-0000-000000000000 | .20   | 0.20                  |
		| 40000000-0000-0000-0000-000000000000 | .0    | 0                     |
	When I breed my individuals
	Then I expect the new generation of individuals to contain
		| ParentIds                            |
		| 10000000-0000-0000-0000-000000000000 |
		| 10000000-0000-0000-0000-000000000000 |
		| 10000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 20000000-0000-0000-0000-000000000000 |
		| 30000000-0000-0000-0000-000000000000 |
		| 30000000-0000-0000-0000-000000000000 |
		| 40000000-0000-0000-0000-000000000000 |
	Then I expect the size of the new generation to be exactly '9'