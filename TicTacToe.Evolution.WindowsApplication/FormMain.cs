using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe;
using TicTacToe.Evolution.Serialization;

namespace TicTacToe.Evolution.WindowsApplication
{
	public partial class FormMain : Form
	{
		EvolutionFactory EvolutionFactory;
		Population Population { get; set; }
		JsonSerializer serializer;

		public FormMain()
		{
			InitializeComponent();

			this.EvolutionFactory = new EvolutionFactory();
			this.Population = this.EvolutionFactory.NewPopulation();
			//this.Population.Name = String.Format("Population.{0}.pop",DateTime.Now.ToString("MM_dd_yyyy"));
			serializer = new JsonSerializer();
		}

		private void buttonDoIt_Click(object sender, EventArgs e)
		{
			if (!backgroundWorkerMain.IsBusy)
			{
				backgroundWorkerMain.RunWorkerAsync();
				buttonDoIt.Text = "Cancel";
				progressBarMain.Value = 0;
				progressBarMain.Visible = true;
			}
			else
			{
				backgroundWorkerMain.CancelAsync();
				while (backgroundWorkerMain.CancellationPending)
					System.Threading.Thread.Sleep(100);

				buttonDoIt.Text = "Do It";
				progressBarMain.Visible = false;
			}
		}


		private void FormMain_Shown(object sender, EventArgs e)
		{
			//this.RunForever();
		}

		private Game HumanGame = new Game();
		private void gameBoardMain_MoveRequested(object sender, MoveRequestEventArgs e)
		{
			if (HumanGame.IsOver)
			{
				MessageBox.Show("Game is over");
				return;
			}

			if (HumanGame.IsMoveValid(e.Move))
			{
				HumanGame.MakeMove(e.Move);

				gameBoardMain.SetBoardState(this.HumanGame.GameBoardString);
			}
			else
			{
				MessageBox.Show("Invalid move to " + e.Move.ToInteger().ToString());
			}
		}

		private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
		{
			while (true)
			{
				if (backgroundWorkerMain.CancellationPending == true)
				{
					break;
				}

				for (int i = 0; i < 1000; i++)
				{
					if (backgroundWorkerMain.CancellationPending == true)
					{
						break;
					}

					this.Population.Evolve();

					if (i % 50 == 0)
						backgroundWorkerMain.ReportProgress(0);
				}

				serializer.SerializeToFile(this.Population, @"C:\" + this.Population.Name);
			}
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			JsonSerializer serializer = new JsonSerializer();
			var population = serializer.DeserializeFromFile(@"c:\Population.04_04_2016.AllNight.pop");


			//this.Population = this.Context.CreatePopulation(population);
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{

		}

		private void backgroundWorkerMain_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (this.progressBarMain.Value == this.progressBarMain.Maximum)
				this.progressBarMain.Value = 0;

			this.progressBarMain.PerformStep();
		}

	}
}
