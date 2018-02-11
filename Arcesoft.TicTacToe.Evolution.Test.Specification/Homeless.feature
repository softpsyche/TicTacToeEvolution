Feature: FitnessCalculator
	Fitness Calculator

Background: 
	Given I have a mock evolution context
	Given I have a breeder


Scenario: ShouldCreateGameMatches
	Given I have the following evolution settings
		| MaximumMatchesPerIndividual | MaximumPopulationSize | MutationRate |
		| 3                           | 6                     | .05          |
	Given I have a fitness calculator
	Given I have the following individuals
		| Name |
		| A    |
		| B    |
		| C    |
		| D    |
		| E    |
		| F    |
	When I evaluate fitness
	Then The matches count should be 18
	Then The matches should contain
		| X | O |
		| A | B |
		| B | A |
		| A | C |
		| C | A |
		| A | D |
		| D | A |
		| B | E |
		| E | B |
		| B | F |
		| F | B |
		| C | D |
		| D | C |
		| C | E |
		| E | C |
		| D | F |
		| F | D |
		| E | F |
		| F | E |

#Scenario: ShouldEvaluateFitness
#	Given I have the following evolution settings
#		| MaximumMatchesPerIndividual | MaximumPopulationSize | MutationRate |
#		| 1                           | 2                     | .05          |
#	Given I have a fitness calculator
#	Given I have the following individuals
#         | Name |
#         | A    |
#         | B    |
#	Given I have the following genes for individual 'A'
#		| Move | Priority | NorthWest | Northern | NorthEast | Western  | Center   | Eastern  | SouthWest | Southern | SouthEast |
#		| 0    | 0        | DontCare  | DontCare | DontCare  | DontCare | Response | DontCare | DontCare  | DontCare | DontCare  |
#		| 1    | 0        | DontCare  | DontCare | DontCare  | DontCare | DontCare | DontCare | DontCare  | DontCare | DontCare  |
#	Given I have the following genes for individual 'B'
#		| Move | Priority | NorthWest | Northern | NorthEast | Western  | Center   | Eastern  | SouthWest | Southern | SouthEast |
#		| 0    | 0        | DontCare  | DontCare | DontCare  | DontCare | DontCare | DontCare | DontCare  | DontCare | DontCare  |
#		| 1    | 0        | DontCare  | DontCare | DontCare  | DontCare | DontCare | DontCare | DontCare  | DontCare | DontCare  |
#	When I evaluate fitness
#	Then The fitness scores should be
#		| Name | Score |
#		| A    | 1     |
#		| B    | 0     |




