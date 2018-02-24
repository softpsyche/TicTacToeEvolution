using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.Assets;
using Arcesoft.TicTacToe.Evolution.Reproduction;
using Arcesoft.TicTacToe.Evolution.Selection;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls
{
    public partial class UxPopulationSettings : UserControl
    {
        private List<PresetPopulationSetting> PresetPopulationSettings { get; set; } = new List<PresetPopulationSetting>();
        internal  PopulationSettings SelectedSettings {get;set;}

        public UxPopulationSettings()
        {
            InitializeComponent();

            if (this.InDesignMode() == false)
            {
                PresetPopulationSettings = EmbeddedResources.PresetPopulationSettings;
            }
        }

        private void UxPopulationSettings_Load(object sender, EventArgs e)
        {
            if (this.InDesignMode() == false)
            {
                comboBoxPresets.DataSource = PresetPopulationSettings.Select(a => a.Name).ToList();
                comboBoxBreederType.DataSource = Enum.GetNames(typeof(BreederType)).ToList();
                comboBoxFitnessEvaluatorType.DataSource = Enum.GetNames(typeof(FitnessEvaluatorType)).ToList();

                comboBoxPresets.SelectedIndex = 0;
            }
        }

        private void comboBoxPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = PresetPopulationSettings.Single(a => a.Name == comboBoxPresets.SelectedValue.ToString());

            comboBoxBreederType.SelectedItem = val.Settings.BreederType.ToString();
            comboBoxFitnessEvaluatorType.SelectedItem = val.Settings.FitnessEvaluatorType.ToString();

            SelectedSettings = val.Settings;
            bindingSourceMain.DataSource = SelectedSettings;
        }
    }
}
