@Behavioral
Feature: Mutations
	Validate all mutation level features

Background: 
	Given I have a container
	Given I have a mutator

Scenario: Should mutate all genes when mutation rate is 100 percent
	Given I have the following evolution settings
		| MutationRate |
		| 1.0          |
	Given I have an individual with the following genes
		| Turn  | Priority | Alleles   |
		| First | 34       | DDD_X_ORA |
		| Third | 99       | RDX_X_ODA |
		| Ninth | 0        | DXO___RAA |
	When I mutate my given individual
	Then I expect the individual to not contain any of the following genes
		| Turn  | Priority | Alleles   |
		| First | 34       | DDD_X_ORA |
		| Third | 99       | RDX_X_ODA |
		| Ninth | 0        | DXO___RAA |
	Then I expect the individual to contain '3' genes

Scenario: Should not mutate any genes when mutation rate is 0 percent
	Given I have the following evolution settings
		| MutationRate |
		| 0.0          |
	Given I have an individual with the following genes
		| Turn    | Priority | Alleles   |
		| First   | 0        | DDD_X_ORA |
		| Second  | 0        | RDX_X_ODA |
		| Third   | 0        | DXO___RAA |
		| Fourth  | 0        | DDDDDDDDD |
		| Fifth   | 0        | DDDDDDDDD |
		| Sixth   | 0        | DDDDDDDDD |
		| Seventh | 0        | DDDDDDDDD |
		| Eigth   | 0        | DDDDDDDDD |
		| Ninth   | 0        | DDDDDDDDD |
		| First   | 1        | DDD_X_ORA |
		| Second  | 1        | RDX_X_ODA |
		| Third   | 1        | DXO___RAA |
		| Fourth  | 1        | DDDDDDDDD |
		| Fifth   | 1        | DDDDDDDDD |
		| Sixth   | 1        | DDDDDDDDD |
		| Seventh | 1        | DDDDDDDDD |
		| Eigth   | 1        | DDDDDDDDD |
		| Ninth   | 1        | DDDDDDDDD |
		| First   | 2        | DDD_X_ORA |
		| Second  | 2        | RDX_X_ODA |
		| Third   | 2        | DXO___RAA |
		| Fourth  | 2        | DDDDDDDDD |
		| Fifth   | 2        | DDDDDDDDD |
		| Sixth   | 2        | DDDDDDDDD |
		| Seventh | 2        | DDDDDDDDD |
		| Eigth   | 2        | DDDDDDDDD |
		| Ninth   | 2        | DDDDDDDDD |
	When I mutate my given individual
	Then I expect the individual to contain the following genes
		| Turn    | Priority | Alleles   |
		| First   | 0        | DDD_X_ORA |
		| Second  | 0        | RDX_X_ODA |
		| Third   | 0        | DXO___RAA |
		| Fourth  | 0        | DDDDDDDDD |
		| Fifth   | 0        | DDDDDDDDD |
		| Sixth   | 0        | DDDDDDDDD |
		| Seventh | 0        | DDDDDDDDD |
		| Eigth   | 0        | DDDDDDDDD |
		| Ninth   | 0        | DDDDDDDDD |
		| First   | 1        | DDD_X_ORA |
		| Second  | 1        | RDX_X_ODA |
		| Third   | 1        | DXO___RAA |
		| Fourth  | 1        | DDDDDDDDD |
		| Fifth   | 1        | DDDDDDDDD |
		| Sixth   | 1        | DDDDDDDDD |
		| Seventh | 1        | DDDDDDDDD |
		| Eigth   | 1        | DDDDDDDDD |
		| Ninth   | 1        | DDDDDDDDD |
		| First   | 2        | DDD_X_ORA |
		| Second  | 2        | RDX_X_ODA |
		| Third   | 2        | DXO___RAA |
		| Fourth  | 2        | DDDDDDDDD |
		| Fifth   | 2        | DDDDDDDDD |
		| Sixth   | 2        | DDDDDDDDD |
		| Seventh | 2        | DDDDDDDDD |
		| Eigth   | 2        | DDDDDDDDD |
		| Ninth   | 2        | DDDDDDDDD |
	Then I expect the individual to contain '27' genes


