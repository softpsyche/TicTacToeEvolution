namespace TicTacToe.Evolution.WindowsApplication
{
	partial class FormMain
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonDoIt = new System.Windows.Forms.Button();
			this.backgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.progressBarMain = new System.Windows.Forms.ProgressBar();
			this.buttonSave = new System.Windows.Forms.Button();
			this.gameBoardMain = new TicTacToe.Evolution.WindowsApplication.GameBoard();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDoIt
			// 
			this.buttonDoIt.Location = new System.Drawing.Point(4, 4);
			this.buttonDoIt.Margin = new System.Windows.Forms.Padding(4);
			this.buttonDoIt.Name = "buttonDoIt";
			this.buttonDoIt.Size = new System.Drawing.Size(110, 39);
			this.buttonDoIt.TabIndex = 0;
			this.buttonDoIt.Text = "Do It";
			this.buttonDoIt.UseVisualStyleBackColor = true;
			this.buttonDoIt.Click += new System.EventHandler(this.buttonDoIt_Click);
			// 
			// backgroundWorkerMain
			// 
			this.backgroundWorkerMain.WorkerReportsProgress = true;
			this.backgroundWorkerMain.WorkerSupportsCancellation = true;
			this.backgroundWorkerMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMain_DoWork);
			this.backgroundWorkerMain.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerMain_ProgressChanged);
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.progressBarMain);
			this.splitContainerMain.Panel1.Controls.Add(this.buttonSave);
			this.splitContainerMain.Panel1.Controls.Add(this.buttonDoIt);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.gameBoardMain);
			this.splitContainerMain.Size = new System.Drawing.Size(856, 559);
			this.splitContainerMain.SplitterDistance = 51;
			this.splitContainerMain.TabIndex = 2;
			// 
			// progressBarMain
			// 
			this.progressBarMain.Location = new System.Drawing.Point(121, 4);
			this.progressBarMain.Maximum = 20;
			this.progressBarMain.Name = "progressBarMain";
			this.progressBarMain.Size = new System.Drawing.Size(162, 39);
			this.progressBarMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBarMain.TabIndex = 2;
			this.progressBarMain.Visible = false;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(738, 4);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(110, 39);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// gameBoardMain
			// 
			this.gameBoardMain.Location = new System.Drawing.Point(258, 155);
			this.gameBoardMain.Name = "gameBoardMain";
			this.gameBoardMain.Size = new System.Drawing.Size(113, 26);
			this.gameBoardMain.TabIndex = 1;
			this.gameBoardMain.MoveRequested += new System.EventHandler<TicTacToe.Evolution.WindowsApplication.MoveRequestEventArgs>(this.gameBoardMain_MoveRequested);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(856, 559);
			this.Controls.Add(this.splitContainerMain);
			this.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.Shown += new System.EventHandler(this.FormMain_Shown);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonDoIt;
		private GameBoard gameBoardMain;
		private System.ComponentModel.BackgroundWorker backgroundWorkerMain;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.ProgressBar progressBarMain;
	}
}

