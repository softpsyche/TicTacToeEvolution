@Domain
Feature: Organisms
	Verify that tic tac toe individuals are working correctly

Background: 
	Given I have a container
	Given I have a tictactoe factory
	Given I have an evolution factory

Scenario: Individual should get genes correctly
	Given I have an individual
	When I set the following genes on the individual
		| Turn  | Priority | Alleles   |
		| First | 34       | DDD_X_ORA |
		| Third | 99       | RDX_X_ODA |
	Then The individual should contain the following genes
		| Turn  | Priority | Alleles   |
		| First | 34       | DDD_X_ORA |
		| Third | 99       | RDX_X_ODA |

Scenario: Individual should copy correctly
	Given I have an individual with the following genes
		| Turn  | Priority | Alleles   |
		| First | 34       | DDD_X_ORA |
		| Third | 99       | RDX_X_ODA |
		| Ninth | 0        | DXO___RAA |
	When I make '2' copies of the individual
	Then All individual copies should contain the following genes
		| Turn  | Priority | Alleles   |
		| First | 34       | DDD_X_ORA |
		| Third | 99       | RDX_X_ODA |
		| Ninth | 0        | DXO___RAA |
	Then There should be exactly '2' individual copies

Scenario: Individual should find move
	Given I have a new game in the following state
		|   |   |   |
		| X |   | O |
		| O | X |   |
		| X |   | O |
	Given I have an individual
	Given I add a gene to my individual for turn 'Sixth' with priority '1' and the following alleles
		|   |   |   |
		| X |   | O |
		| O | X | R |
		| X |   | O |
	Given I add a gene to my individual for turn 'Seventh' with priority '2' and the following alleles
		|   |   |   |
		| D |   | D |
		| D | R | D |
		| D |   | O |
	Given I add a gene to my individual for turn 'Seventh' with priority '18' and the following alleles
		|   |   |   |
		| D |   | D |
		| D | X | D |
		| D | R | O |
	Given I add a gene to my individual for turn 'Seventh' with priority '7' and the following alleles
		|   |   |   |
		| D | R | D |
		| D | X | D |
		| D |   | O |
	When I try to find a move for the current game with my individual
	Then I expect the move to be 'Northern'

Scenario: Individual should not find move
	Given I have a new game in the following state
		|  |  |  |
		|  |  |  |
		|  |  |  |
		|  |  |  |
	Given I have an individual
		Given I add a gene to my individual for turn 'First' with priority '1' and the following alleles
		|  |  |  |
		|  |  |  |
		|  |  |  |
		|  |  |  |
	Given I add a gene to my individual for turn 'First' with priority '1' and the following alleles
		|  |   |  |
		|  |   |  |
		|  |   |  |
		|  | X |  |
	When I try to find a move for the current game with my individual
	Then I expect the move to be null

Scenario: Individual should find responses correctly
	Given I have a new game in the following state
		|  |   |   |
		|  |   | O |
		|  | X |   |
		|  |   |   |
	Given I have an individual
	Given I add a gene to my individual for turn 'Third' with priority '3' and the following alleles
		|   |   |   |
		|   |   | O |
		| D | D |   |
		|   | R |   |
	Given I add a gene to my individual for turn 'Third' with priority '5' and the following alleles
		|   |   |   |
		| D | R | O |
		| D | X |   |
		| D |   |   |
	Given I add a gene to my individual for turn 'Third' with priority '1' and the following alleles
		|   |   |   |
		|   |   | O |
		| R | X |   |
		|   |   |   |
	Given I add a gene to my individual for turn 'First' with priority '7' and the following alleles
		|  |   |   |
		|  | R | O |
		|  | X |   |
		|  |   |   |
	When I find responses for the current game with my individual
	Then I expect the responses to contain in the following order
		| Move     |
		| Western  |
		| Southern |
		| Northern |


