@Behavioral
Feature: Selection
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
	Given I have a container
	Given I have a tictactoe factory

Scenario: Should build many matches correctly
	Given I have a match builder
	Given I have '50' individuals
	When I repeat the test '500' times using '5' tournaments and '50' individuals

Scenario Outline: Should build matches for a
	Given I have a match builder
	Given I have '<Individuals>' individuals
	When I build matches with '<Tournaments>' tournaments for my given individuals
	Then I expect all given individuals to have at least '<ExpectedTournaments>' tournaments each
	Then I expect the number of matches to be at least '<ExpectedMatches>'
	Examples: 
		| Name                          | Individuals | Tournaments | ExpectedTournaments | ExpectedMatches |
		| tiny set                      | 2           | 1           | 1                   | 2               |
		| small set                     | 4           | 3           | 3                   | 12              |
		| medium set                    | 20          | 6           | 6                   | 120             |
		| large set                     | 100         | 5           | 5                   | 500             |
		| huge set                      | 1000        | 6           | 6                   | 6000            |
		| set with too many tournaments | 10          | 15          | 9                   | 90              |
		| invalid set                   | 3           | 1           | 1                   | 3               |

Scenario: Should evaluate match correctly if players have no moves
	Given I have a match evaluator
	Given I have the following individuals
		| Name  |
		| John  |
		| Sally |
	Given I create matches for the following individuals
		| PlayerXName | PlayerOName |
		| John        | Sally       |
	When I evaluate the matches
	Then I expect the ledger to contain
		| IndividualName | Player | MetricScore | MetricType       |
		| John           | X      | 0           | LostDueToNoMoves |
		| Sally          | O      | 10          | WonDueToNoMoves  |

Scenario: Should evaluate match correctly for invalid move
	Given I have a match evaluator
	Given I have the following individuals
		| Name  |
		| John  |
		| Sally |
	Given I add a gene to individual 'John' for turn 'First' with priority '1' and the following alleles
		|   |   |   |
		|   |   | D |
		| D | R |   |
		|   | D |   |
	Given I add a gene to individual 'Sally' for turn 'Second' with priority '1' and the following alleles
		|   |   |  |
		| R |   |  |
		|   | D |  |
		|   |   |  |
	Given I add a gene to individual 'John' for turn 'Third' with priority '1' and the following alleles
		|   |   |   |
		| O |   |   |
		|   | X | R |
		|   |   |   |
	Given I create matches for the following individuals
		| PlayerXName | PlayerOName |
		| John        | Sally       |
	When I evaluate the matches
	Then I expect the ledger to contain
		| IndividualName | Player | MetricScore | MetricType       | Description                              |
		| John           | X      | 10          | Moved            | Moved to 'Center' for board _________    |
		| Sally          | O      | 10          | Moved            | Moved to 'NorthWest' for board ____X____ |
		| John           | X      | 10          | Moved            | Moved to 'Eastern' for board O___X____   |
		| Sally          | O      | 0           | LostDueToNoMoves | Lost due to no move for board O___XX___  |
		| John           | X      | 10          | WonDueToNoMoves  | Won due to no move for board O___XX___   |

