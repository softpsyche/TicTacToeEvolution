using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace TicTacToe
{
	[Serializable]
	public struct GameMove
	{
		private int row;
		private int column;

		public GameMove(int row, int column)
		{
			this.row = row;
			this.column = column;
		}
		public int Row
		{
		    get
		    {
		        return row;
		    }
			//set
			//{
			//    //if ((row < 0) || (row > 2))
			//    //    throw new ArgumentException("Invalid row value. Row value must be between 0 and 2 (inclusive).");

			//    row = value;
			//}
		}
		public int Column
		{
		    get
		    {
		        return column;
		    }
			//set
			//{
			//    //if ((column < 0) || (column > 2))
			//    //    throw new ArgumentException("Invalid column value. Column value must be between 0 and 2 (inclusive).");

			//    column = value;
			//}
		}
	}
	[Serializable]
	public class Game
	{
		#region Private variables
		private Board gameBoard = new Board();
		private Side playerTurn = Side.X;
		private int movesMade=0;
		private Collection<GameMove> gameMoves = new Collection<GameMove>();
		private ISynchronizeInvoke synchronizingObject = null;
		#endregion
		#region Events
		public event EventHandler<EventArgs> GameOver;
		public event EventHandler GameReset;

		private void OnGameOver()
		{
			EventHandler<EventArgs> temp = this.GameOver;

			if (temp != null)
			{
				if (this.synchronizingObject != null)
				{
					this.synchronizingObject.Invoke(temp, new object[] { EventArgs.Empty });
				}
				else
				{
					temp(this, EventArgs.Empty);
				}
			}
		}
		private void OnGameReset()
		{
			EventHandler temp = this.GameReset;

			if (temp != null)
			{
				if (this.synchronizingObject != null)
				{
					this.synchronizingObject.Invoke(temp, new object[] { EventArgs.Empty });
				}
				else
				{
					temp(this, EventArgs.Empty);
				}
			}
		}
		#endregion
		#region Constructor(s)
		public Game()
		{

		}
		#endregion
		#region Properties
		public string GameBoardString
		{
			get
			{
				return this.gameBoard.ToString();
			}
		}
		public ISynchronizeInvoke SynchronizingObject
		{
			set
			{
				this.synchronizingObject = value;
			}
		}
		public Side OtherPlayerTurn
		{
			get
			{
				if (playerTurn == Side.O)
					return Side.X;
				else
					return Side.O;
			}
		}
		public Side PlayerTurn
		{
			get
			{
				return playerTurn;
			}
		}
		public int MovesMade
		{
			get
			{
				return this.movesMade;
			}
		}
		public GameMove [] GameHistory
		{
			get
			{
				GameMove [] gameHistoryArray = new GameMove[gameMoves.Count];

				gameMoves.CopyTo(gameHistoryArray,0);

				return gameHistoryArray;
			}
		}
		public BoardState GameState
		{
			get
			{
				return this.gameBoard.State;
			}
		}
		public GameMove [] LegalMoves
		{
			get
			{
				//if the board is no longer 'in play', we have no legal moves left..
				if (GameState != BoardState.InPlay)
					return new GameMove[0];

				//the number of legal moves left can be inferred from 
				//the number of moves already made.
				GameMove [] legalMoves = new GameMove[9 - gameMoves.Count];
				int count = 0;

				for (int row = 0; row < 3; row++)
				{
					for (int column = 0; column < 3; column++)
					{
						if (gameBoard[row, column] == Square.Empty)
						{
							legalMoves[count] = new GameMove(row, column);
							count++;
						}
					}
				}

				return legalMoves;
			}
		}
		public bool IsOver
		{
			get
			{
				return GameState != BoardState.InPlay;
			}
		}
		#endregion
		#region Public methods 
		public void Reset()
		{
			this.gameBoard.Clear();

			this.gameMoves.Clear();

			this.playerTurn = Side.X;

			this.movesMade = 0;

			this.OnGameReset();
		}
		public bool IsMoveValid(GameMove gameMove)
		{
			return gameBoard.SquareIsEmpty(gameMove.Row, gameMove.Column);
		}
		public bool IsMoveValid(int row, int column)
		{
			return gameBoard.SquareIsEmpty(row, column);
		}
		public void UndoLastMove()
		{
			if(gameMoves.Count == 0)
			{
				throw new InvalidOperationException("No moves have been made yet.");
			}

			//undo the board move...
			this.gameBoard[
				gameMoves[gameMoves.Count -1].Row,
				gameMoves[gameMoves.Count -1].Column] = Square.Empty;

			//delete move from history..
			this.gameMoves.RemoveAt(gameMoves.Count-1);

			//flip the player turn to the previous player...
			this.FlipPlayerTurn();

			//decrement movesmade counter..
			this.movesMade--;
		}
		public void MakeMove(int row,int column)
		{
			this.MakeMove(new GameMove(row,column));
		}
		public void MakeMove(GameMove gameMove)
		{
			if (!gameBoard.SquareIsEmpty(gameMove.Row, gameMove.Column))
			{
				throw new ArgumentException("Invalid move. Square already occupied.");
			}

			if (playerTurn == Side.X)
			{
				gameBoard[gameMove.Row, gameMove.Column] = Square.X;
			}
			else
			{
				gameBoard[gameMove.Row, gameMove.Column] = Square.O;
			}

			//update our history here...
			gameMoves.Add(gameMove);

			//flip the player turn...
			this.FlipPlayerTurn();

			//increment movesmade counter.
			this.movesMade++;

			//if the game is over, raise the event...
			if (gameBoard.State != BoardState.InPlay)
			{
				OnGameOver();
			}
		}
		private void FlipPlayerTurn()
		{
			if(playerTurn == Side.O)
				playerTurn = Side.X;
			else
				playerTurn = Side.O;
		}
		#endregion
	}
	[Serializable]
	public class BoardLayoutAndGameMoveResult
	{
		string boardLayout = null;
		GameMoveResult gameMoveResult;

		public string BoardLayout
		{
			get { return boardLayout; }
		}
		internal GameMoveResult GameMoveResult
		{
			get { return gameMoveResult; }
		}
		public BoardLayoutAndGameMoveResult(GameMoveResult gameMoveResult, string boardLayout)
		{
			this.boardLayout	= boardLayout;
			this.gameMoveResult = gameMoveResult;
		}
	}
	[Serializable]
	public struct GameMoveResult
	{
		GameMove moveMade;
		BoardState boardStateAfterMove;

		public GameMove MoveMade
		{
			get { return moveMade; }
		}
		public BoardState BoardStateAfterMove
		{
			get { return boardStateAfterMove; }
		}
		public GameMoveResult(GameMove moveMade, BoardState boardStateAfterMove)
		{
			this.moveMade = moveMade;
			this.boardStateAfterMove = boardStateAfterMove;
		}
		public override string ToString()
		{
			return "Move Made: (" + moveMade.Row.ToString() + "," + moveMade.Column.ToString() +
				") Board State: " + boardStateAfterMove.ToString();
		}

	}
	[Serializable]
	public class ArtificialIntelligence
	{
		#region Private Variables
		public static int moveCount=0;
		private static Random random = new Random(0);
		#endregion
		#region Private Methods
		private static int FindBestMoveIndex(Collection<GameMoveResult> gameMoveResults,Side side)
		{
			Collection<int> winningMovesIndexes = new Collection<int>();
			Collection<int> tieMovesIndexes = new Collection<int>();
			Collection<int> losingMovesIndexes = new Collection<int>();

			if (side == Side.O)
			{
				for (int count = 0; count < gameMoveResults.Count; count++)
				{
					switch (gameMoveResults[count].BoardStateAfterMove)
					{
						case BoardState.OWin:
							winningMovesIndexes.Add(count);
							break;
						case BoardState.Tie:
							tieMovesIndexes.Add(count);
							break;
						default:
							losingMovesIndexes.Add(count);
							break;
					}
				}
			}
			else
			{
				for (int count = 0; count < gameMoveResults.Count; count++)
				{
					switch (gameMoveResults[count].BoardStateAfterMove)
					{
						case BoardState.XWin:
							winningMovesIndexes.Add(count);
							break;
						case BoardState.Tie:
							tieMovesIndexes.Add(count);
							break;
						default:
							losingMovesIndexes.Add(count);
							break;
					}
				}
			}

			if (winningMovesIndexes.Count > 0)
			{
				return winningMovesIndexes[random.Next(0, winningMovesIndexes.Count)];
			}
			else if (tieMovesIndexes.Count > 0)
			{
				return tieMovesIndexes[random.Next(0, tieMovesIndexes.Count)];
			}
			else if (losingMovesIndexes.Count > 0)
			{
				return losingMovesIndexes[random.Next(0, losingMovesIndexes.Count)];
			}
			else
				throw new ArgumentException("gameMoveResults collection is either empty or corrupt");
		}
		#endregion
		#region Public Methods
		public static GameMoveResult GetBestMove(Game game)
		{
			Collection<GameMoveResult> gameMoveResults = new Collection<GameMoveResult>();

			foreach (GameMove gameMove in game.LegalMoves)
			{
				moveCount++;
				game.MakeMove(gameMove);

				if (game.IsOver)
				{
					gameMoveResults.Add(new GameMoveResult(gameMove, game.GameState));
				}
				else
				{
					//recurse to find this moves finale
					gameMoveResults.Add(new GameMoveResult(gameMove,
						GetBestMove(game).BoardStateAfterMove));
				}

				game.UndoLastMove();
			}

			return gameMoveResults[FindBestMoveIndex(gameMoveResults, game.PlayerTurn)];
		}
		public static GameMoveResult GetAllResponsesForGame(Game game,Collection<BoardLayoutAndGameMoveResult> boardLayoutAndGameMoveResult)
		{
			Collection<GameMoveResult> gameMoveResults = new Collection<GameMoveResult>();
			int bestMoveIndex;

			foreach (GameMove gameMove in game.LegalMoves)
			{
				moveCount++;
				game.MakeMove(gameMove);

				if (game.IsOver)
				{
					gameMoveResults.Add(new GameMoveResult(gameMove, game.GameState));
				}
				else
				{
					//recurse to find this moves finale
					gameMoveResults.Add(new GameMoveResult(gameMove,
						GetAllResponsesForGame(game,boardLayoutAndGameMoveResult).BoardStateAfterMove));
				}

				game.UndoLastMove();
			}

			bestMoveIndex = FindBestMoveIndex(gameMoveResults, game.PlayerTurn);

			boardLayoutAndGameMoveResult.Add(new BoardLayoutAndGameMoveResult(
				gameMoveResults[bestMoveIndex],game.GameBoardString));

			return gameMoveResults[bestMoveIndex];
		}
		#endregion
	}
	[Serializable]
	public class MoveDatabase
	{
		private const string moveDataBaseFileName = "MoveDatabase.ttt";
		//private static MoveDatabase moveDatabase = null;
		private TicTacToe.MovesDataTable movesDataTable = null;

		public MoveDatabase()
		{
			if (!this.LoadMovesDataBaseFromDisk())
			{
				this.PopulateMovesDataTable();
				this.SaveMovesDataBaseToDisk();
			}
		}
		//static private MoveDatabase Instance
		//{
		//    get
		//    {
		//        if (moveDatabase == null)
		//        {
		//            moveDatabase = new MoveDatabase();
		//        }

		//        return moveDatabase;
		//    }
		//}

		public GameMove LookupGameMove(string currentBoardPosition)
		{
			TicTacToe.MovesRow move= this.Lookup(currentBoardPosition);
			return new GameMove(move.ResponseRow, move.ResponseColumn);
		}
		public TicTacToe.MovesRow Lookup(string currentBoardPosition)
		{
			return this.movesDataTable.FindByBoard(currentBoardPosition);
		}

		private string MoveDatabaseFilePath
		{
			get
			{
				return Application.StartupPath + @"\" + moveDataBaseFileName;
			}
		}
		private bool LoadMovesDataBaseFromDisk()
		{
			if (File.Exists(MoveDatabaseFilePath))
			{
				this.movesDataTable = Utility.Deserialize<TicTacToe.MovesDataTable>(MoveDatabaseFilePath);
				return true;
			}

			return false;
		}
		private void SaveMovesDataBaseToDisk()
		{
			Utility.Serialize<TicTacToe.MovesDataTable>(this.movesDataTable, MoveDatabaseFilePath);
		}
		private void PopulateMovesDataTable()
		{
			PopulateMovesDataTable(this.movesDataTable);
		}
		private void PopulateMovesDataTable(TicTacToe.MovesDataTable movesDataTable)
		{
			Collection<BoardLayoutAndGameMoveResult> gameMoveResultCollection = new Collection<BoardLayoutAndGameMoveResult>();

			movesDataTable = new TicTacToe.MovesDataTable();

			ArtificialIntelligence.GetAllResponsesForGame(new Game(),gameMoveResultCollection);

			foreach(BoardLayoutAndGameMoveResult boardLayoutAndGameMoveResult 
				in gameMoveResultCollection)
			{
				if (movesDataTable.FindByBoard(boardLayoutAndGameMoveResult.BoardLayout) == null)
				{
					movesDataTable.AddMovesRow(
						boardLayoutAndGameMoveResult.BoardLayout,
						boardLayoutAndGameMoveResult.GameMoveResult.MoveMade.Row,
						boardLayoutAndGameMoveResult.GameMoveResult.MoveMade.Column);

					movesDataTable.AcceptChanges();
				}
			}
		}
	}
}
