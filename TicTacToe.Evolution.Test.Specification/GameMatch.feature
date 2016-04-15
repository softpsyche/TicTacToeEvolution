Feature: GameMatch
	A game match

Background: 
	Given I have a mock evolution context
	Given I have a breeder


Scenario: Should assign no points for NoResponse
	Given I have the following individuals
         | Name |
         | A    |
         | B    |
	Given I have the following genes for individual 'A'
		| Move | Priority | NorthWest | Northern | NorthEast | Western  | Center   | Eastern  | SouthWest | Southern | SouthEast |
		| 0    | 0        | DontCare  | DontCare | DontCare  | DontCare | DontCare | DontCare | DontCare  | DontCare | DontCare  |
	Given I have the following genes for individual 'B'
		| Move | Priority | NorthWest | Northern | NorthEast | Western  | Center   | Eastern  | SouthWest | Southern | SouthEast |
		| 0    | 0        | DontCare  | DontCare | DontCare  | DontCare | DontCare | DontCare | DontCare  | DontCare | DontCare  |
	Given I have a gamematch with individual 'A' as player X and individual 'B' as player O
	When I evaluate the game match
	Then The fitness score for player 'A' should be '0'
	Then The fitness score for player 'B' should be '0'
	Then The match game board should look like
		|   |   |   |
		| _ | _ | _ |
		| _ | _ | _ |
		| _ | _ | _ |

Scenario: Should Play a tie game
	Given I have the following individuals
         | Name |
         | A    |
         | B    |
	Given I have the following genes for individual 'A'
		| Move | Priority | NorthWest | Northern  | NorthEast | Western   | Center    | Eastern   | SouthWest | Southern  | SouthEast |
		| 0    | 0        | Response  | Empty     | Empty     | Empty     | Empty     | Empty     | Empty     | Empty     | Empty     |
		| 2    | 0        | OccupiedX | Empty     | Empty     | Empty     | OccupiedO | Empty     | Response  | Empty     | Empty     |
		| 4    | 0        | OccupiedX | Empty     | Empty     | OccupiedO | OccupiedO | Response  | OccupiedX | Empty     | Empty     |
		| 6    | 0        | OccupiedX | OccupiedO | Empty     | OccupiedO | OccupiedO | OccupiedX | OccupiedX | Response  | Empty     |
		| 8    | 0        | OccupiedX | OccupiedO | Response | OccupiedO | OccupiedO | OccupiedX | OccupiedX | OccupiedX | OccupiedO  |
	Given I have the following genes for individual 'B'
		| Move | Priority | NorthWest | Northern  | NorthEast | Western   | Center    | Eastern   | SouthWest | Southern  | SouthEast |
		| 1    | 0        | OccupiedX | Empty     | Empty     | Empty     | Response  | Empty     | Empty     | Empty     | Empty     |
		| 3    | 0        | OccupiedX | Empty     | Empty     | Response  | OccupiedO | Empty     | OccupiedX | Empty     | Empty     |
		| 5    | 0        | OccupiedX | Response  | Empty     | OccupiedO | OccupiedO | OccupiedX | OccupiedX | Empty     | Empty     |
		| 7    | 0        | OccupiedX | OccupiedO | Empty     | OccupiedO | OccupiedO | OccupiedX | OccupiedX | OccupiedX | Response  |
	Given I have a gamematch with individual 'A' as player X and individual 'B' as player O
	When I evaluate the game match
	Then The fitness score for player 'A' should be '15'
	Then The fitness score for player 'B' should be '14'
	Then The match game board should look like
		|   |   |   |
		| X | O | X |
		| O | O | X |
		| X | X | O |

Scenario: Should Play a winning game
	Given I have the following individuals
         | Name |
         | A    |
         | B    |
	Given I have the following genes for individual 'A'
		| Move | Priority | NorthWest | Northern  | NorthEast | Western   | Center    | Eastern   | SouthWest | Southern  | SouthEast |
		| 0    | 0        | Response  | Empty     | Empty     | Empty     | Empty     | Empty     | Empty     | Empty     | Empty     |
		| 2    | 0        | OccupiedX | Empty     | Empty     | Empty     | OccupiedO | Empty     | Response  | Empty     | Empty     |
		| 4    | 0        | OccupiedX | Empty     | Empty     | OccupiedO | OccupiedO | Response  | OccupiedX | Empty     | Empty     |
		| 6    | 0        | OccupiedX | OccupiedO | Empty     | OccupiedO | OccupiedO | OccupiedX | OccupiedX | Response  | Empty     |
		| 8    | 0        | OccupiedX | OccupiedO | OccupiedO | OccupiedO | OccupiedO | OccupiedX | OccupiedX | OccupiedX | Response  |
	Given I have the following genes for individual 'B'
		| Move | Priority | NorthWest | Northern  | NorthEast | Western   | Center    | Eastern   | SouthWest | Southern  | SouthEast |
		| 1    | 0        | OccupiedX | Empty     | Empty     | Empty     | Response  | Empty     | Empty     | Empty     | Empty     |
		| 3    | 0        | OccupiedX | Empty     | Empty     | Response  | OccupiedO | Empty     | OccupiedX | Empty     | Empty     |
		| 5    | 0        | OccupiedX | Response  | Empty     | OccupiedO | OccupiedO | OccupiedX | OccupiedX | Empty     | Empty     |
		| 7    | 0        | OccupiedX | OccupiedO | Response  | OccupiedO | OccupiedO | OccupiedX | OccupiedX | OccupiedX | Empty     |
	Given I have a gamematch with individual 'A' as player X and individual 'B' as player O
	When I evaluate the game match
	Then The fitness score for player 'A' should be '105'
	Then The fitness score for player 'B' should be '6'
	Then The match game board should look like
		|   |   |   |
		| X | O | O |
		| O | O | X |
		| X | X | X |

Scenario: Should Respect priority
	Given I have the following individuals
         | Name |
         | A    |
         | B    |
	Given I have the following genes for individual 'A'
		| Move | Priority | NorthWest | Northern | NorthEast | Western | Center   | Eastern | SouthWest | Southern | SouthEast |
		| 0    | 2        | Response  | Empty    | Empty     | Empty   | Empty    | Empty   | Empty     | Empty    | Empty     |
		| 0    | 1        | Empty     | Empty    | Empty     | Empty   | Response | Empty   | Empty     | Empty    | Empty     |
	Given I have a gamematch with individual 'A' as player X and individual 'B' as player O
	When I evaluate the game match
	Then The fitness score for player 'A' should be '1'
	Then The fitness score for player 'B' should be '0'
	Then The match game board should look like
		|   |   |   |
		| _ | _ | _ |
		| _ | X | _ |
		| _ | _ | _ |

Scenario: Should Use first response
	Given I have the following individuals
         | Name |
         | A    |
         | B    |
	Given I have the following genes for individual 'A'
		| Move | Priority | NorthWest | Northern | NorthEast | Western | Center   | Eastern | SouthWest | Southern | SouthEast |
		| 0    | 0        | Empty     | Empty    | Empty     | Empty   | Response | Empty   | Empty     | Empty    | Response  |
	Given I have a gamematch with individual 'A' as player X and individual 'B' as player O
	When I evaluate the game match
	Then The fitness score for player 'A' should be '1'
	Then The fitness score for player 'B' should be '0'
	Then The match game board should look like
		|   |   |   |
		| _ | _ | _ |
		| _ | X | _ |
		| _ | _ | _ |

Scenario: Should Ignore states for DontCare
	Given I have the following individuals
         | Name |
         | A    |
         | B    |
	Given I have the following genes for individual 'A'
		| Move | Priority | NorthWest | Northern | NorthEast | Western  | Center   | Eastern  | SouthWest | Southern | SouthEast |
		| 0    | 0        | Response  | Empty    | Empty     | Empty    | Empty    | Empty    | Empty     | Empty    | Empty     |
		| 2    | 0        | DontCare  | DontCare | DontCare  | Response | DontCare | DontCare | DontCare  | DontCare | Response  |
	Given I have the following genes for individual 'B'
		| Move | Priority | NorthWest | Northern | NorthEast | Western  | Center   | Eastern  | SouthWest | Southern | SouthEast |
		| 1    | 0        | DontCare  | DontCare | DontCare  | DontCare | DontCare | Response | DontCare  | DontCare | DontCare  |
	Given I have a gamematch with individual 'A' as player X and individual 'B' as player O
	When I evaluate the game match
	Then The fitness score for player 'A' should be '2'
	Then The fitness score for player 'B' should be '1'
	Then The match game board should look like
		|   |   |   |
		| X | _ | _ |
		| X | _ | O |
		| _ | _ | _ |


