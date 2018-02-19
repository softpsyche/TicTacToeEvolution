using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arcesoft.TicTacToe.Entities;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication
{
    public partial class GameBoard : UserControl
    {
        private IGame _game;

        public IGame Game
        {
            get
            {
                return _game;
            }
            set
            {
                if (ReferenceEquals(value, _game) == false)
                {
                    _game = Game;
                    Invalidate();
                }
            }
        }
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

            if (Game == null)
            {
                e.Graphics.DrawString("No game selected", SystemFonts.DefaultFont, Brushes.Black, e.ClipRectangle);
                return;
            }

            e.Graphics.DrawLine(BlackPen, new Point(SquareWidth, 0), new Point(SquareWidth, this.Height));
            e.Graphics.DrawLine(BlackPen, new Point(SquareWidth * 2, 0), new Point(SquareWidth * 2, this.Height));
            e.Graphics.DrawLine(BlackPen, new Point(0, SquareHeight), new Point(Width, SquareHeight));
            e.Graphics.DrawLine(BlackPen, new Point(0, SquareHeight * 2), new Point(Width, SquareHeight * 2));

            for (Int32 y = 0; y < 3; y++)
            {
                for (Int32 x = 0; x < 3; x++)
                {
                    DrawSquare(e, GetBoardCharacter(x, y), x, y);
                }
            }
        }

        private String GetBoardCharacter(int x, int y)
        {
            var dude = (y * 3);

            if (BoardState != null && BoardState.Length > dude)
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

            if (character == BoardConstants.SquareXString)
            {
                e.Graphics.DrawLine(this.BlackPen, drawRect.Location, new Point(drawRect.Right, drawRect.Bottom));
                e.Graphics.DrawLine(this.BlackPen, new Point(drawRect.Left, drawRect.Bottom), new Point(drawRect.Right, drawRect.Top));
            }
            else if (character == BoardConstants.SquareOString)
            {
                e.Graphics.DrawEllipse(this.BlackPen, drawRect);
            }
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

            MakeMove(yCoord, xCoord);
        }

        private Move ToMove(int yCoord, int xCoord)
        {
            return (Move)((yCoord * 3) + xCoord);
        }

        private void MakeMove(int yCoord, int xCoord)
        {

        }
    }
}
