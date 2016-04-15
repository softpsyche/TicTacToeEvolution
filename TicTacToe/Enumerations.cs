using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
	public enum Square
	{
		Empty = 0,
		X =1,
		O =2
	}
	public enum BoardState
	{
		InPlay,
		Tie,
		XWin,
		OWin
	}
	public enum Side
	{
		X,
		O
	}
	public enum Allele
	{
		Empty=0,
		X,
		O,
		XOrO,
		DontCare
	} 
}
