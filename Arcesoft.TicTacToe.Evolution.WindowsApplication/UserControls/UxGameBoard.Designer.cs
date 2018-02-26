namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls
{
	partial class UxGameBoard
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
            this.panelBoard = new System.Windows.Forms.Panel();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.labelGameState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBoard.BackColor = System.Drawing.Color.White;
            this.panelBoard.Location = new System.Drawing.Point(0, 0);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(480, 480);
            this.panelBoard.TabIndex = 0;
            this.panelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBoard_Paint);
            this.panelBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameBoard_MouseUp);
            // 
            // labelFeedback
            // 
            this.labelFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedback.Location = new System.Drawing.Point(172, 483);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(308, 25);
            this.labelFeedback.TabIndex = 1;
            this.labelFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGameState
            // 
            this.labelGameState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelGameState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameState.Location = new System.Drawing.Point(0, 483);
            this.labelGameState.Name = "labelGameState";
            this.labelGameState.Size = new System.Drawing.Size(166, 25);
            this.labelGameState.TabIndex = 2;
            this.labelGameState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UxGameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelGameState);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.panelBoard);
            this.Name = "UxGameBoard";
            this.Size = new System.Drawing.Size(480, 508);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.Label labelGameState;
    }
}
