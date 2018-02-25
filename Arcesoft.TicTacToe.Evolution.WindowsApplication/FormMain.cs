using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Persistance;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.Assets;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.DependencyInjection;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication
{
    internal partial class FormMain : Form
    {
        private FactoryContainer FactoryContainer { get; set; }
        private IEvolutionFactory EvolutionFactory { get; set; }
        private IDataAccess DataAccess { get; set; }
        private ApplicationSettings ApplicationSettings { get; set; }

        IRegion SelectedRegion { get; set; }

        public FormMain(FactoryContainer factoryContainer, IEvolutionFactory evolutionFactory, IDataAccess dataAccess, ApplicationSettings applicationSettings)
        {
            FactoryContainer = factoryContainer;
            EvolutionFactory = evolutionFactory;
            DataAccess = dataAccess;
            ApplicationSettings = applicationSettings;

            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var region = EvolutionFactory.CreateRegion(new RegionSettings()
            {
                ExternalMigrationEnabled = true,
                InternalMigrationEnabled = true
            });

            region.Name = $@"{Environment.MachineName}/{Environment.UserName} - {DateTime.Now.ToShortDateString()}";

            region.AddPopulations(new[] { EvolutionFactory.CreatePopulation(EmbeddedResources.PresetPopulationSettings.First().Settings, "First") });
            region.AddPopulations(new[] { EvolutionFactory.CreatePopulation(EmbeddedResources.PresetPopulationSettings.First().Settings, "Second") });

            SetCurrentRegion(region);
        }


        private void FormMain_Shown(object sender, EventArgs e)
        {

        }

        private void SetCurrentRegion(IRegion region)
        {
            SelectedRegion = region;

            Text = $"Evott - ({SelectedRegion.Name})";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newRegion = DlgNewRegion.TryCreateNewRegion(FactoryContainer, this);

            if (newRegion != null)
            {
                SetCurrentRegion(newRegion);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.SaveRegion(SelectedRegion);
            }
            catch (Exception ex)
            {

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var region = DlgOpenRegion.TryOpenRegion(FactoryContainer);
            }
            catch (Exception ex)
            {

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Close application", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerMain.IsBusy)
            {
                MessageBox.Show("This evolution program is already running",
                    "Cannot start, already running",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            backgroundWorkerMain.RunWorkerAsync();

            toolStripProgressBarRunning.Visible = true;
            toolStripProgressBarRunning.MarqueeAnimationSpeed = 500;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((!backgroundWorkerMain.IsBusy) || (backgroundWorkerMain.CancellationPending))
            {
                MessageBox.Show("This evolution program is not currently running or is in the process of pausing",
                    "Cannot stop, program is not running",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            backgroundWorkerMain.CancelAsync();
        }

        private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime? lastSaveDate = null;
            var nextSaveDate = GetNextSaveDate();
            var reportProgressInterval = ApplicationSettings.ReportProgressIntervalInGenerations;
            long nextProgressReport = 1;
            var advanceAmount = CalculateAdvanceOptimumForCurrentComputer();

            //save the region...
            DataAccess.SaveOrUpdateRegion(SelectedRegion);

            //while the universe has not reached a heat death
            while (true)
            {
                //check for cancel
                if (backgroundWorkerMain.CancellationPending)
                {
                    //save before we bail...
                    DataAccess.SaveOrUpdateRegion(SelectedRegion);
                    return;
                }

                //autosave if enabled
                if (DateTime.Now >= nextSaveDate)
                {
                    lastSaveDate = DateTime.Now;
                    DataAccess.UpdateRegion(SelectedRegion);
                }

                //report progress to user...
                if (SelectedRegion.Age >= nextProgressReport)
                {
                    backgroundWorkerMain.ReportProgress(0, new BackgroundWorkerProgressReport()
                    {
                        LastSaveDate = lastSaveDate,
                        RegionSummary= BuildRegionSummary(SelectedRegion)
                    });
                    nextProgressReport += reportProgressInterval;
                }

                //advance the passage of time...
                SelectedRegion.Advance(advanceAmount);
            }
        }

        private RegionSummary BuildRegionSummary(IRegion region)
        {
            return new RegionSummary()
            {
                Id = region.Id,
                Age = region.Age,
                Name = region.Name,
                PopulationSummaries = region.Populations.Select(a => new PopulationSummary()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Size = a.Individuals.Count()
                }).ToList()
            };
        }

        private int CalculateAdvanceOptimumForCurrentComputer()
        {
            //TODO use some logics yo...
            return 1;
        }

        private DateTime GetNextSaveDate() => ApplicationSettings.AutomaticSaveFrequencyInSecondsEnabled ? DateTime.Now.AddSeconds(ApplicationSettings.AutomaticSaveFrequencyInSeconds) : DateTime.MaxValue;

        private void backgroundWorkerMain_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progress = e.UserState as BackgroundWorkerProgressReport;

            toolStripStatusLabelGenerationCount.Text = $"Age: {progress.RegionSummary.Age}";

            var lastSavedDateString = progress.LastSaveDate.HasValue ? progress.LastSaveDate.Value.ToString() : "N/A";

            toolStripStatusLabelLastSaved.Text = $"Last saved: {lastSavedDateString}";
        }

        private void backgroundWorkerMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBarRunning.Visible = false;
            toolStripProgressBarRunning.MarqueeAnimationSpeed = 0;
            toolStripProgressBarRunning.Value = 0;
        }
    }

    public class BackgroundWorkerProgressReport
    {
        public RegionSummary RegionSummary { get; set; }
        public DateTime? LastSaveDate { get; set; }
    }

    public class RegionSummary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public long Age { get; set; }

        public int PopulationCount => PopulationSummaries.Count;

        public List<PopulationSummary> PopulationSummaries { get; set; }
    }

    public class PopulationSummary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }
    }
}
