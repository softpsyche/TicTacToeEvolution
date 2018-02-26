using Arcesoft.TicTacToe.Evolution.WindowsApplication.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.Dialogs
{
    internal partial class DlgPlayGame : Form
    {
        private IGame Game { get; set; }

        public DlgPlayGame(IGame game)
        {
            InitializeComponent();

            Game = game;

            uxGameBoardMain.Game = Game;
        }

        public static void Play(FactoryContainer factoryContainer)
        {
            using (var dlg = factoryContainer.GetInstance<DlgPlayGame>())
            {
                dlg.ShowDialog();
            }
        }
    }
}
