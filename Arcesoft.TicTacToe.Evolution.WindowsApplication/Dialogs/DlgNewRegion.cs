using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.DependencyInjection;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls;
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
    internal partial class DlgNewRegion : Form
    {
        internal RegionSettings NewRegionSettings { get; set; }
        internal List<Tuple<string, PopulationSettings>> GetPopulations()
        {
            var listy = new List<Tuple<string, PopulationSettings>>();

            tabControlPopulations.TabPages.ForEachAs<TabPage>(a => listy.Add(new Tuple<string, PopulationSettings>(
                a.Text,
                (a.Controls[0] as UxPopulationSettings).SelectedSettings)));

            return listy;
        }

        public DlgNewRegion()
        {
            InitializeComponent();

            NewRegionSettings = new RegionSettings();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            //validate here? maybe...

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        internal static IRegion TryCreateNewRegion(FactoryContainer factoryContainer, IWin32Window owner = null)
        {
            using (var dialog = factoryContainer.GetInstance<DlgNewRegion>())
            {
                if (dialog.ShowDialog(owner) == DialogResult.OK)
                {
                    var evoFactory = factoryContainer.GetInstance<IEvolutionFactory>();

                    var region = evoFactory.CreateRegion(dialog.NewRegionSettings);
                    var pops = dialog.GetPopulations();
                    var populations = pops.Select(a => evoFactory.CreatePopulation(a.Item2, a.Item1));
                    region.AddPopulations(populations);

                    return region;
                }
            }

            return null;
        }

        private void addPopulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = $"Population ({DateTime.Now.ToShortDateString()})";

            if (this.InputBox("Add new population", "Please enter a name", ref name) != DialogResult.OK)
            {
                return;
            }

            AddPopulationTab(name);
        }

        private void AddPopulationTab(string name)
        {
            var newPopulationTabPage = new TabPage(name);
            var populationSettings = new PopulationSettings();
            var settingsControl = new UxPopulationSettings();

            tabControlPopulations.TabPages.Add(newPopulationTabPage);
            newPopulationTabPage.Controls.Add(settingsControl);
            settingsControl.Dock = DockStyle.Fill;

        }

        private void DlgNewRegion_Shown(object sender, EventArgs e)
        {
            AddPopulationTab($"Population ({DateTime.Now.ToShortDateString()})");

            textBoxName.Focus();
        }
    }
}
