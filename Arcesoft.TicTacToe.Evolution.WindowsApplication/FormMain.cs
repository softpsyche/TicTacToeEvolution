using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Persistance;
using Arcesoft.TicTacToe.Evolution.Reproduction;
using Arcesoft.TicTacToe.Evolution.Selection;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.Assets;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.DependencyInjection;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.Dialogs;
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

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication
{
    internal partial class FormMain : Form
    {
        private FactoryContainer FactoryContainer { get; set; }
        private IEvolutionFactory EvolutionFactory { get; set; }
        private ITicTacToeFactory TicTacToeFactory { get; set; }
        private IDataAccess DataAccess { get; set; }
        private ApplicationSettings ApplicationSettings { get; set; }

        IRegion SelectedRegion { get; set; }

        public FormMain(FactoryContainer factoryContainer, IEvolutionFactory evolutionFactory, ITicTacToeFactory ticTacToeFactory, IDataAccess dataAccess, ApplicationSettings applicationSettings)
        {
            FactoryContainer = factoryContainer;
            EvolutionFactory = evolutionFactory;
            TicTacToeFactory = ticTacToeFactory;
            DataAccess = dataAccess;
            ApplicationSettings = applicationSettings;

            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var lastRegion = DataAccess.SearchRegionsMostRecent().FirstOrDefault();

            if (lastRegion == null)
            {
                var region = EvolutionFactory.CreateRegion(new RegionSettings()
                {
                    ExternalMigrationEnabled = true,
                    InternalMigrationEnabled = true
                });

                region.Name = $@"{Environment.MachineName}/{Environment.UserName} - {DateTime.Now.ToShortDateString()}";

                region.AddPopulations(new[] { EvolutionFactory.CreatePopulation(EmbeddedResources.PresetPopulationSettings.First().Settings, "First") });
                region.AddPopulations(new[] { EvolutionFactory.CreatePopulation(EmbeddedResources.PresetPopulationSettings.Skip(1).First().Settings, "Second") });
                region.AddPopulations(new[] { EvolutionFactory.CreatePopulation(EmbeddedResources.PresetPopulationSettings.Skip(2).First().Settings, "Third") });

                region.Advance();

                SetCurrentRegion(region);
            }
            else
            {
                SetCurrentRegion(DataAccess.TryFindRegion(lastRegion.Id));
            }
        }


        private void FormMain_Shown(object sender, EventArgs e)
        {

        }

        private void SetCurrentRegion(IRegion region)
        {
            SelectedRegion = region;

            BindName();

            BindPopulationTabs();
        }

        private void BindName()
        {
            Text = $"Evott - ({SelectedRegion.Name})";
        }

        private void BindPopulationTabs()
        {
            tabControlPopulationSummaries.TabPages.Clear();

            SelectedRegion.Populations.ForEach(a =>
            {
                var tabPage = new TabPage(a.ToString());
                var uxPopulationSummary = new UxPopulationSummary();
                uxPopulationSummary.Dock = DockStyle.Fill;
                uxPopulationSummary.PlayRequested += UxPopulationSummary_PlayRequested;
                uxPopulationSummary.UpdateSummary(new PopulationSummary(a));

                tabPage.Controls.Add(uxPopulationSummary);

                tabControlPopulationSummaries.TabPages.Add(tabPage);
            });
        }

        private void UxPopulationSummary_PlayRequested(object sender, EventArgs e)
        {
            if (backgroundWorkerMain.IsBusy)
            {
                MessageBox.Show("Unable to do this while game is running");
            }

            var requestor = sender as UxPopulationSummary;
            var popId = requestor.PopulationSummary.Id;
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
            DataAccess.SaveOrUpdateRegion(SelectedRegion);

            
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
            long nextProgressReport = SelectedRegion.Age + 1;
            var advanceAmount = CalculateAdvanceOptimumForCurrentComputer();

            //save the region...
            //DataAccess.SaveOrUpdateRegion(SelectedRegion);

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
                    nextSaveDate = GetNextSaveDate();
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
                PopulationSummaries = region.Populations.Select(a => new PopulationSummary(a)).ToList()
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

        private void renameRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newName = SelectedRegion.Name;
            if (this.InputBox("Rename region", "Enter new region name", ref newName) == DialogResult.OK)
            {
                SelectedRegion.Name = newName;

                BindName();
            }
        }

        private void playHumanVHumanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgPlayGame.Play(FactoryContainer);
        }

        private void playVsAIasXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgPlayGame.Play(FactoryContainer, null, TicTacToeFactory.NewArtificialIntelligence(ArtificialIntelligenceTypes.OmniscientGod));         
        }

        private void playVsAIasOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgPlayGame.Play(FactoryContainer, TicTacToeFactory.NewArtificialIntelligence(ArtificialIntelligenceTypes.OmniscientGod));
        }

        private void playVsIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        public long Generation { get; set; }

        public int GenesPerIndividual { get; set; }

        public BreederType BreederType { get; set; }

        public FitnessEvaluatorType FitnessEvaluatorType { get; set; }

        public PopulationSummary()
        {

        }
        public PopulationSummary(IPopulation population)
        {
            Id = population.Id;
            Name = population.Name;
            Generation = population.Generation;
            Size = population.Individuals.Count();
            GenesPerIndividual = population.Settings.MaximumGenesPerIndividual;
            BreederType = population.Settings.BreederType;
            FitnessEvaluatorType = population.Settings.FitnessEvaluatorType;
        }

    }
}
