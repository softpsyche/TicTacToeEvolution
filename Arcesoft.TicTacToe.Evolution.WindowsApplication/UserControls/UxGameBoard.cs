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
using System.Threading;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls
{
    public partial class UxGameBoard : UserControl
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
                    UnregisterEvents(_game);
                    _game = value;
                    RegisterEvents(_game);

                    _game.Reset();

                    Invalidate();
                }
            }
        }
        public IArtificialIntelligence PlayerX { get; set; }
        public IArtificialIntelligence PlayerO { get; set; }
        public int DelayBetweenAiMovesInMilliseconds { get; set; } = 1000;
        private bool IsCurrentPlayerHuman => Game.CurrentPlayer == Player.X ? PlayerX == null : PlayerO == null;
        private IArtificialIntelligence CurrentAI => Game.CurrentPlayer == Player.X ? PlayerX : PlayerO;
        private String BoardState { get; set; }
        private Int32 SquareWidth
        {
            get
            {
                return this.panelBoard.Width / 3;
            }
        }
        private Int32 SquareHeight
        {
            get
            {
                return this.panelBoard.Height / 3;
            }
        }
        private Pen BlackPen
        {
            get;
            set;
        }

        public UxGameBoard()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //this.BoardState = "XXXOOOXXX";
            this.BlackPen = new Pen(Brushes.Black, 10);
        }

        private void UnregisterEvents(IGame game)
        {
            if (game != null)
            {
                game.GameStateChanged -= Game_GameStateChanged;
            }
        }

        private void RegisterEvents(IGame game)
        {
            if (game != null)
            {
                game.GameStateChanged += Game_GameStateChanged;
            }
        }

        private void Game_GameStateChanged(object sender, GameStateChangedEventArgs e)
        {
            if (Game.GameIsOver)
            {
                //do game over junk? render
                labelGameState.Text = $"Game state: {Game.GameState}";

                //feedback
                labelFeedback.Text = $"Game over";

                return;
            }

            //if we are waiting on a human...bail out
            if (IsCurrentPlayerHuman)
            {
                return;
            }

            //sleep if both players are AI (so it doesnt fly by)
            if (PlayerX != null && PlayerO != null)
            {
                Thread.Sleep(DelayBetweenAiMovesInMilliseconds);
            }

            var moved = CurrentAI.TryMakeMove(Game);

            if (moved == false)
            {
                //do game over junk? render
                labelGameState.Text = $"Game state: " + (Game.CurrentPlayer == Player.X? GameState.OWin.ToString(): GameState.XWin.ToString());

                //feedback
                labelFeedback.Text = $"AI unable to move...";
            }
        }

        private void panelBoard_Paint(object sender, PaintEventArgs e)
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
                    var squareString = Game.GameBoardString[x + (y * 3)].ToString();

                    DrawSquare(e, squareString, x, y);
                }
            }
        }

        //private String GetBoardCharacter(int x, int y)
        //{
        //    var charIndex = x + (y * 3);

        //    switch (Game.GameBoardString[charIndex])
        //    {
        //        case BoardConstants.SquareOChar:
        //            return BoardConstants.SquareOString;
        //        case BoardConstants.SquareXChar:
        //            return BoardConstants.SquareXString;
        //        default:
        //            return string.Empty;
        //    }
        //}

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

        private void GameBoard_MouseUp(object sender, MouseEventArgs e)
        {
            //if the current player is not human, throw this away.
            if (IsCurrentPlayerHuman == false)
            {
                return;
            }

            Int32 xCoord;
            Int32 yCoord;

            var height = panelBoard.Height / 3;
            var width = panelBoard.Width / 3;

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

        private void MakeMove(int yCoord, int xCoord)
        {
            var move = ToMove(yCoord, xCoord);

            if (Game.IsMoveValid(move))
            {
                Game.Move(move);
                Invalidate(true);
            }
            else
            {
                labelFeedback.Text = $"Invalid move '{move}'";
            }
        }

        private Move ToMove(int yCoord, int xCoord)
        {
            return (Move)((yCoord * 3) + xCoord);
        }
    }
}
