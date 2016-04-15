using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TicTacToe
{
	public partial class UxPopulation : UserControl
	{
		private Population population;

		private string PopulationFilePath
		{
			get
			{
				return Application.StartupPath + @"\" + population.Name + ".ttt";
			}
		}
		public UxPopulation(String populationFilePath)
		{
			InitializeComponent();
			this.Dock = DockStyle.Fill;
			this.population = Utility.Deserialize<Population>(populationFilePath);
		}
		public UxPopulation(Population population)
		{
			InitializeComponent();
			this.Dock = DockStyle.Fill;
			this.population = population;
		}

		private void backgroundWorkerBreeder_DoWork(object sender, DoWorkEventArgs e)
		{
			while (!this.backgroundWorkerBreeder.CancellationPending)
			{
				//create a new brood.
				//this.population.NewGenerationBasedOnAbsoluteFitness();

				//create a new brood.
				this.population.NewGenerationBasedOnRelativeFitness();

				//report progress.
				this.backgroundWorkerBreeder.ReportProgress(0,this.population.LastBestIndividual);
			}
		}

		private void backgroundWorkerBreeder_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.txtCrossOverRate.Text = this.population.CrossOverMutationRate.ToString("#.000000");
			this.txtMutationRate.Text = this.population.MutationRate.ToString("#.000000");
			this.txtGenerationNumber.Text = this.population.Generation.ToString();
			this.txtMaximumSize.Text = this.population.MaximumSize.ToString();

			this.txtLastGenerationAverageAbsoluteFitness.Text =
				this.population.LastGenerationAverageFitness.ToString("#.000000");
			this.txtLastGenerationHighestAbsoluteFitness.Text =
				this.population.LastGenerationHighestFitness.ToString("#.000000");
			this.txtLastGenerationLowestAbsoluteFitness.Text =
				this.population.LastGenerationLowestFitness.ToString("#.000000");
			this.txtLastGenerationAverageTurnsPlayedPerGame.Text =
				this.population.LastGenerationAverageNumberOfTurnsPlayedPerGame.ToString("#.000000");
		}

		private void backgroundWorkerBreeder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
				throw e.Error;

			this.SetUserInterfaceState(false);
		}

		private void btnStartOrStop_Click(object sender, EventArgs e)
		{
			if (this.backgroundWorkerBreeder.IsBusy)
			{
				if(!this.backgroundWorkerBreeder.CancellationPending)
					this.backgroundWorkerBreeder.CancelAsync();
			}
			else
			{
				this.SetUserInterfaceState(true);

				this.backgroundWorkerBreeder.RunWorkerAsync();
			}
		}

		private void SetUserInterfaceState(bool backgroundThreadRunning)
		{
			if (backgroundThreadRunning)
			{
				this.groupBoxStatus.Text = "Breeding...";
				this.btnStartOrStop.Text = "Stop";
				this.progressBarBreeding.Style = ProgressBarStyle.Marquee;
			}
			else
			{
				this.groupBoxStatus.Text = String.Empty;
				this.btnStartOrStop.Text = "Start";
				this.progressBarBreeding.Style = ProgressBarStyle.Blocks;
			}

			this.btnSave.Enabled = !backgroundThreadRunning;

			this.groupBoxStatus.Enabled = backgroundThreadRunning;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Utility.Serialize<Population>(this.population, this.saveFileDialog.FileName);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Are you sure?","Close Tab",
				MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				TabControl tc = this.Parent.Parent as TabControl;
				TabPage tp = this.Parent as TabPage;

				if ((tc != null) && (tp != null))
				{
					tc.TabPages.Remove(tp);
				}
			}
		}

		private void UxPopulation_Load(object sender, EventArgs e)
		{
			this.SetUserInterfaceState(false);

			this.saveFileDialog.InitialDirectory = Application.StartupPath;
			this.saveFileDialog.FileName = Path.GetFileName(this.PopulationFilePath);
#if(DEBUG)
			this.btnStartOrStop_Click(this, null);
#endif
		}
	}
}
