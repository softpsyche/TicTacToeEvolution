using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication
{
	public partial class GameBoard : UserControl
	{
		private String BoardState { get; set; }
		public GameBoard()
		{
			InitializeComponent();
			this.DoubleBuffered = true;

			//this.BoardState = "XXXOOOXXX";
			this.BlackPen = new Pen(Brushes.Black, 10);
		}

		private Int32 SquareWidth
		{
			get
			{
				return this.Width / 3;
			}
		}
		private Int32 SquareHeight
		{
			get
			{
				return this.Height / 3;
			}
		}
		private Pen BlackPen
		{
			get;
			 set;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);

			e.Graphics.DrawLine(BlackPen, new Point(SquareWidth, 0), new Point(SquareWidth, this.Height));
			e.Graphics.DrawLine(BlackPen, new Point(SquareWidth * 2, 0), new Point(SquareWidth * 2, this.Height));
			e.Graphics.DrawLine(BlackPen, new Point(0, SquareHeight), new Point(Width, SquareHeight));
			e.Graphics.DrawLine(BlackPen, new Point(0, SquareHeight * 2), new Point(Width, SquareHeight * 2));

			for (Int32 y = 0; y < 3; y++)
			{
				for (Int32 x = 0; x < 3; x++)
				{
					DrawSquare(e, GetBoardCharacter(x,y), x, y);
				}
			}
		}
		private String GetBoardCharacter(int x, int y)
		{
			var dude = new GameMove(y, x).ToInteger();

			if(BoardState != null && BoardState.Length > dude)
			{
				return BoardState[dude].ToString();
			}
			
			return String.Empty;
		}
		private void DrawSquare(PaintEventArgs e, String character, Int32 x, Int32 y)
		{
			Rectangle drawRect = new Rectangle(
				x * SquareWidth,
				y * SquareHeight,
				SquareWidth,
				SquareHeight);

			drawRect = Rectangle.Inflate(drawRect, -15, -15);

			if (character == "X")
			{
				e.Graphics.DrawLine(this.BlackPen, drawRect.Location, new Point(drawRect.Right, drawRect.Bottom));
				e.Graphics.DrawLine(this.BlackPen, new Point(drawRect.Left, drawRect.Bottom), new Point(drawRect.Right, drawRect.Top));
			}
			else if (character == "O")
			{
				e.Graphics.DrawEllipse(this.BlackPen, drawRect);
			}
		}

		public event EventHandler<MoveRequestEventArgs> MoveRequested;
		private void OnMoveRequested(GameMove move)
		{
			var temp = this.MoveRequested;

			if (temp != null)
			{
				temp(this, new MoveRequestEventArgs() { Move = move });
			}
		}

		public void SetBoardState(String gameBoardState)
		{
			this.BoardState = gameBoardState;
			this.Invalidate();
		}

		private void GameBoard_Click(object sender, EventArgs e)
		{

		}

		private void GameBoard_MouseUp(object sender, MouseEventArgs e)
		{
			Int32 xCoord;
			Int32 yCoord;

			var height = this.Height / 3;
			var width = this.Width / 3;

			if (e.Location.X < width)
			{
				xCoord = 0;
			}
			else if (e.Location.X < width * 2)
			{
				xCoord = 1;
			}
			else
			{
				xCoord = 2;
			}

			if (e.Location.Y < height)
			{
				yCoord = 0;
			}
			else if (e.Location.Y < height * 2)
			{
				yCoord = 1;
			}
			else
			{
				yCoord = 2;
			}

			this.OnMoveRequested(new GameMove(yCoord, xCoord));

		}
	}

	public class MoveRequestEventArgs:EventArgs
	{
		public GameMove Move
		{
			get;
			set;
		}
	}
}
