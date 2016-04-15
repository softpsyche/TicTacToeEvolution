namespace TicTacToe
{
	partial class UxPopulation
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.progressBarBreeding = new System.Windows.Forms.ProgressBar();
			this.btnStartOrStop = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtLastGenerationAverageAbsoluteFitness = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLastGenerationLowestAbsoluteFitness = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtLastGenerationHighestAbsoluteFitness = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtCrossOverRate = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMutationRate = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMaximumSize = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtGenerationNumber = new System.Windows.Forms.TextBox();
			this.groupBoxStatus = new System.Windows.Forms.GroupBox();
			this.backgroundWorkerBreeder = new System.ComponentModel.BackgroundWorker();
			this.txtLastGenerationAverageTurnsPlayedPerGame = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1.SuspendLayout();
			this.groupBoxStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// progressBarBreeding
			// 
			this.progressBarBreeding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarBreeding.Location = new System.Drawing.Point(6, 19);
			this.progressBarBreeding.Name = "progressBarBreeding";
			this.progressBarBreeding.Size = new System.Drawing.Size(466, 23);
			this.progressBarBreeding.TabIndex = 0;
			// 
			// btnStartOrStop
			// 
			this.btnStartOrStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnStartOrStop.Location = new System.Drawing.Point(136, 403);
			this.btnStartOrStop.Name = "btnStartOrStop";
			this.btnStartOrStop.Size = new System.Drawing.Size(68, 23);
			this.btnStartOrStop.TabIndex = 1;
			this.btnStartOrStop.Text = "Start";
			this.btnStartOrStop.UseVisualStyleBackColor = true;
			this.btnStartOrStop.Click += new System.EventHandler(this.btnStartOrStop_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnSave.Location = new System.Drawing.Point(210, 403);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(68, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnClose.Location = new System.Drawing.Point(284, 403);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(68, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtLastGenerationAverageTurnsPlayedPerGame);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtLastGenerationAverageAbsoluteFitness);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtLastGenerationLowestAbsoluteFitness);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtLastGenerationHighestAbsoluteFitness);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtCrossOverRate);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtMutationRate);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtMaximumSize);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtGenerationNumber);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(478, 174);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "General Information";
			// 
			// txtLastGenerationAverageAbsoluteFitness
			// 
			this.txtLastGenerationAverageAbsoluteFitness.Location = new System.Drawing.Point(343, 74);
			this.txtLastGenerationAverageAbsoluteFitness.Name = "txtLastGenerationAverageAbsoluteFitness";
			this.txtLastGenerationAverageAbsoluteFitness.ReadOnly = true;
			this.txtLastGenerationAverageAbsoluteFitness.Size = new System.Drawing.Size(73, 20);
			this.txtLastGenerationAverageAbsoluteFitness.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(182, 74);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(117, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Last Gen. Avg. Fitness:";
			// 
			// txtLastGenerationLowestAbsoluteFitness
			// 
			this.txtLastGenerationLowestAbsoluteFitness.Location = new System.Drawing.Point(343, 45);
			this.txtLastGenerationLowestAbsoluteFitness.Name = "txtLastGenerationLowestAbsoluteFitness";
			this.txtLastGenerationLowestAbsoluteFitness.ReadOnly = true;
			this.txtLastGenerationLowestAbsoluteFitness.Size = new System.Drawing.Size(73, 20);
			this.txtLastGenerationLowestAbsoluteFitness.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(182, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(129, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Last Gen. Lowest Fitness:";
			// 
			// txtLastGenerationHighestAbsoluteFitness
			// 
			this.txtLastGenerationHighestAbsoluteFitness.Location = new System.Drawing.Point(343, 19);
			this.txtLastGenerationHighestAbsoluteFitness.Name = "txtLastGenerationHighestAbsoluteFitness";
			this.txtLastGenerationHighestAbsoluteFitness.ReadOnly = true;
			this.txtLastGenerationHighestAbsoluteFitness.Size = new System.Drawing.Size(73, 20);
			this.txtLastGenerationHighestAbsoluteFitness.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(182, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(131, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Last Gen. Highest Fitness:";
			// 
			// txtCrossOverRate
			// 
			this.txtCrossOverRate.Location = new System.Drawing.Point(100, 97);
			this.txtCrossOverRate.Name = "txtCrossOverRate";
			this.txtCrossOverRate.ReadOnly = true;
			this.txtCrossOverRate.Size = new System.Drawing.Size(73, 20);
			this.txtCrossOverRate.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Cross Over Rate:";
			// 
			// txtMutationRate
			// 
			this.txtMutationRate.Location = new System.Drawing.Point(100, 71);
			this.txtMutationRate.Name = "txtMutationRate";
			this.txtMutationRate.ReadOnly = true;
			this.txtMutationRate.Size = new System.Drawing.Size(73, 20);
			this.txtMutationRate.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Mutation Rate:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Generation #:";
			// 
			// txtMaximumSize
			// 
			this.txtMaximumSize.Location = new System.Drawing.Point(100, 45);
			this.txtMaximumSize.Name = "txtMaximumSize";
			this.txtMaximumSize.ReadOnly = true;
			this.txtMaximumSize.Size = new System.Drawing.Size(73, 20);
			this.txtMaximumSize.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Maximum Size:";
			// 
			// txtGenerationNumber
			// 
			this.txtGenerationNumber.Location = new System.Drawing.Point(100, 19);
			this.txtGenerationNumber.Name = "txtGenerationNumber";
			this.txtGenerationNumber.ReadOnly = true;
			this.txtGenerationNumber.Size = new System.Drawing.Size(73, 20);
			this.txtGenerationNumber.TabIndex = 0;
			// 
			// groupBoxStatus
			// 
			this.groupBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxStatus.Controls.Add(this.progressBarBreeding);
			this.groupBoxStatus.Location = new System.Drawing.Point(3, 344);
			this.groupBoxStatus.Name = "groupBoxStatus";
			this.groupBoxStatus.Size = new System.Drawing.Size(478, 53);
			this.groupBoxStatus.TabIndex = 5;
			this.groupBoxStatus.TabStop = false;
			// 
			// backgroundWorkerBreeder
			// 
			this.backgroundWorkerBreeder.WorkerReportsProgress = true;
			this.backgroundWorkerBreeder.WorkerSupportsCancellation = true;
			this.backgroundWorkerBreeder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBreeder_DoWork);
			this.backgroundWorkerBreeder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBreeder_RunWorkerCompleted);
			this.backgroundWorkerBreeder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerBreeder_ProgressChanged);
			// 
			// txtLastGenerationAverageTurnsPlayedPerGame
			// 
			this.txtLastGenerationAverageTurnsPlayedPerGame.Location = new System.Drawing.Point(343, 100);
			this.txtLastGenerationAverageTurnsPlayedPerGame.Name = "txtLastGenerationAverageTurnsPlayedPerGame";
			this.txtLastGenerationAverageTurnsPlayedPerGame.ReadOnly = true;
			this.txtLastGenerationAverageTurnsPlayedPerGame.Size = new System.Drawing.Size(73, 20);
			this.txtLastGenerationAverageTurnsPlayedPerGame.TabIndex = 15;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(182, 100);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(144, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Last Gen. Avg. Turns/Game:";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Tic Tac Toe Files|*.ttt";
			// 
			// UxPopulation
			// 
			this.Controls.Add(this.groupBoxStatus);
			this.Controls.Add(this.btnStartOrStop);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClose);
			this.Name = "UxPopulation";
			this.Size = new System.Drawing.Size(488, 429);
			this.Load += new System.EventHandler(this.UxPopulation_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBoxStatus.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBarBreeding;
		private System.Windows.Forms.Button btnStartOrStop;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtGenerationNumber;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMaximumSize;
		private System.Windows.Forms.TextBox txtCrossOverRate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMutationRate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBoxStatus;
		private System.ComponentModel.BackgroundWorker backgroundWorkerBreeder;
		private System.Windows.Forms.TextBox txtLastGenerationAverageAbsoluteFitness;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLastGenerationLowestAbsoluteFitness;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtLastGenerationHighestAbsoluteFitness;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtLastGenerationAverageTurnsPlayedPerGame;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;

	}
}
