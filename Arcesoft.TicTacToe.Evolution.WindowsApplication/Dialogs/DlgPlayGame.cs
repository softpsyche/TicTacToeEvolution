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
        public IArtificialIntelligence PlayerXAI { get; set; }
        public IArtificialIntelligence PlayerOAI { get; set; }

        public DlgPlayGame(IGame game)
        {
            InitializeComponent();

            if (this.InDesignMode())
            {
                return;
            }

            Game = game;
            uxGameBoardMain.Game = Game;
        }

        private void DlgPlayGame_Load(object sender, EventArgs e)
        {
            if (this.InDesignMode())
            {
                return;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Game.Reset();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public static void Play(FactoryContainer factoryContainer, IArtificialIntelligence playerXAI = null, IArtificialIntelligence playerOAI = null)
        {
            using (var dlg = factoryContainer.GetInstance<DlgPlayGame>())
            {
                dlg.PlayerXAI = playerXAI;
                dlg.PlayerOAI = playerOAI;
                dlg.ShowDialog();
            }
        }
    }
}
