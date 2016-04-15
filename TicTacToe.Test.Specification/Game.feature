#This is just a comment. Its glorious.
Feature: Game
	General testing for the Game api of our tic tac toe library

#Steps defined in the background will run for
#all scenarios and scenario outlines in the feature file.
#As good practice, this should only include 'Given' steps (aka Arrange)
Background: 
	Given I create a new tic tac toe game



Scenario: Game - Reset
	# Given steps are for setting up the test. Identical to 'Arrange'.
	Given I make the following move "0,0"
	# When steps are for executing the action you are trying to test. Identical to 
	# 'Act' and there should only be one per scenario per best practices.
	When I reset the game
	# Then steps are for verifying the code behaved as expected after your 'When'
	# action. Identical to 'Assert'. 
	Then The board should be empty
	Then The current players turn should be "X"
	#the step below takes a parameter 'InPlay' which is an enumeration that specflow can parse for you automatically
	Then The current game state should be "InPlay"
	And The number of moves made should be "0"
	# NOTE: that you can use the 'And' word to chain statements 
	# as done above. When used this way the 'And' is equivalent
	# to 'Then', 'Given' or 'When' depending on when its used. if used after a 'Then' it becomes a 'Then' 
	# as demonstrated above. I prefer to use the formal Given When Then always instead of 'and'.



Scenario: Game - Created
	#note that although this first step appears identical to the background step defined at the top it is
	#treated differently by specflow because it is defined as a 'When' step 
	#instead of a 'Given' step. Both the step type and the step are used by specflow to
	#match to a binding
	When I create a new tic tac toe game
	Then The board should be empty
	Then The current players turn should be "X"
	Then The current game state should be "InPlay"
	And The number of moves made should be "0"


Scenario: Game  - Make valid move
	When I make the following move "1,1"
	#The step below takes a specflow 'Table' parameter which can be used to hold tabular data
	#Additionally, extension methods of the table class in the 'TechTalk.SpecFlow.Assist' 
	#namespace can be used to easily transform the table data into a set of POCO objects where
	#each property is mapped to the column header for the table (in this case i have not defined any)
	Then The game board should look like
		|   |   |   |
		| _ | _ | _ |
		| _ | X | _ |
		| _ | _ | _ |
	Then The current game state should be "InPlay"
	Then The current players turn should be "O"
	Then The number of moves made should be "1"

Scenario: Game  - Win a game for X
	When I make the following moves
		| Row | Column |
		| 0   | 0      |
		| 1   | 1      |
		| 2   | 2      |
		| 2   | 0      |
		| 0   | 2      |
		| 1   | 0      |
		| 0   | 1      |
	Then The game board should look like
		|   |   |   |
		| X | X | X |
		| O | O | _ |
		| O | _ | X |
	Then The current game state should be "XWin"
	Then The current players turn should be "O"
	Then The number of moves made should be "7" 

Scenario: Game  - Win a game for O
	When I make the following moves
		| Row | Column |
		| 0   | 0      |
		| 2   | 0      |
		| 0   | 1      |
		| 2   | 1      |
		| 1   | 0      |
		| 2   | 2      |
	Then The game board should look like
		|   |   |   |
		| X | X | _ |
		| X | _ | _ |
		| O | O | O |
	Then The current game state should be "OWin"
	Then The current players turn should be "X"
	Then The number of moves made should be "6"

Scenario: Game  - Tie a game using more business friendly steps
	Given I make a move to the northwest square
	Given I make a move to the center square
	Given I make a move to the northern square
	Given I make a move to the northeast square
	Given I make a move to the southwest square
	Given I make a move to the western square
	Given I make a move to the eastern square
	Given I make a move to the southern square
	When I make a move to the southeast square
	Then The game board should look like
		|   |   |   |
		| X | X | O |
		| O | O | X |
		| X | O | X |
	Then The current game state should be "Tie"
	Then The current players turn should be "O"
	Then The number of moves made should be "9"

Scenario Outline: Game - Board evaluation
Given I have the following board state
		|   |   |   |
		| X | O | _ |
		| X | X | _ |
		| _ | _ | O |
When I try to make the move "<Move>"
Then The outcome should be "<Outcome>"
Examples: 
| TestName         | Move      | Outcome     |
| SouthwestWin     | SouthWest | XWin        |
| SouthInPlay      | Southern  | InPlay      |
| EastWin          | Eastern   | XWin        |
| NortheastInplay  | NorthEast | InPlay      |
| Northinvalid     | Northern  | InvalidMove |
| NorthwestInvalid | NorthWest | InvalidMove |
| CenterInvalid    | Center    | InvalidMove |
