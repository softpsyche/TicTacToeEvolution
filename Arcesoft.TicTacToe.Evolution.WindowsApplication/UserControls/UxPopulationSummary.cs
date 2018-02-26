using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls
{
    public partial class UxPopulationSummary : UserControl
    {
        public event EventHandler<EventArgs> PlayRequested;

        public PopulationSummary PopulationSummary  { get; private set;}

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

        private void buttonPlayAgainst_Click(object sender, EventArgs e)
        {
            OnPlayRequested();
        }

        private void OnPlayRequested()
        {
            PlayRequested?.Invoke(this, new EventArgs());
        }
    }
}
