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

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls
{
    public partial class UxPopulationSummary : UserControl
    {
        public event EventHandler<PlayRequestedEventArgs> PlayRequested;

        public PopulationSummary PopulationSummary { get; private set; }

        public UxPopulationSummary()
        {
            InitializeComponent();
        }

        public void UpdateSummary(PopulationSummary summary)
        {
            textBoxBreederType.Text = summary.BreederType.ToString();
            textBoxFitnessEvaluator.Text = summary.FitnessEvaluatorType.ToString();
            textBoxGeneration.Text = summary.Generation.ToString();
            textBoxGenesPerIndividual.Text = summary.GenesPerIndividual.ToString();
            textBoxId.Text = summary.Id.ToString();
            textBoxName.Text = summary.Name;
            textBoxSize.Text = summary.Size.ToString();

            PopulationSummary = summary;
        }

        private void buttonPlayAsX_Click(object sender, EventArgs e)
        {
            OnPlayRequested(Player.X, PopulationSummary.Id);
        }

        private void buttonPlayAsO_Click(object sender, EventArgs e)
        {
            OnPlayRequested(Player.O, PopulationSummary.Id);
        }

        private void OnPlayRequested(Player player, Guid id)
        {
            PlayRequested?.Invoke(this, new PlayRequestedEventArgs()
            {
                Player = player,
                PopulationId = id
            });
        }


    }

    public class PlayRequestedEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public Guid PopulationId { get; set; }
    }
}
