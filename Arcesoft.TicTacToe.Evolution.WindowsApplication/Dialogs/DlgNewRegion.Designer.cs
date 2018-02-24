namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.Dialogs
{
    partial class DlgNewRegion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgNewRegion));
            this.tabControlPopulations = new System.Windows.Forms.TabControl();
            this.contextMenuStripPopulation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPopulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePoulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.bindingSourceRegion = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxRegionSettings1 = new Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls.UxRegionSettings();
            this.contextMenuStripPopulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlPopulations
            // 
            this.tabControlPopulations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPopulations.ContextMenuStrip = this.contextMenuStripPopulation;
            this.tabControlPopulations.Location = new System.Drawing.Point(12, 115);
            this.tabControlPopulations.Name = "tabControlPopulations";
            this.tabControlPopulations.SelectedIndex = 0;
            this.tabControlPopulations.Size = new System.Drawing.Size(352, 273);
            this.tabControlPopulations.TabIndex = 0;
            // 
            // contextMenuStripPopulation
            // 
            this.contextMenuStripPopulation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPopulationToolStripMenuItem,
            this.removePoulationToolStripMenuItem});
            this.contextMenuStripPopulation.Name = "contextMenuStripPopulation";
            this.contextMenuStripPopulation.Size = new System.Drawing.Size(172, 48);
            // 
            // addPopulationToolStripMenuItem
            // 
            this.addPopulationToolStripMenuItem.Name = "addPopulationToolStripMenuItem";
            this.addPopulationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addPopulationToolStripMenuItem.Text = "Add population";
            this.addPopulationToolStripMenuItem.Click += new System.EventHandler(this.addPopulationToolStripMenuItem_Click);
            // 
            // removePoulationToolStripMenuItem
            // 
            this.removePoulationToolStripMenuItem.Name = "removePoulationToolStripMenuItem";
            this.removePoulationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.removePoulationToolStripMenuItem.Text = "Remove poulation";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(80, 394);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(105, 43);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(191, 394);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 43);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // bindingSourceRegion
            // 
            this.bindingSourceRegion.DataSource = typeof(Arcesoft.TicTacToe.Evolution.Environs.IRegion);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceRegion, "Name", true));
            this.textBoxName.Location = new System.Drawing.Point(151, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(213, 20);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.Text = "My Region";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // uxRegionSettings1
            // 
            this.uxRegionSettings1.Location = new System.Drawing.Point(16, 41);
            this.uxRegionSettings1.Name = "uxRegionSettings1";
            this.uxRegionSettings1.Size = new System.Drawing.Size(344, 64);
            this.uxRegionSettings1.TabIndex = 3;
            // 
            // DlgNewRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 445);
            this.ContextMenuStrip = this.contextMenuStripPopulation;
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxRegionSettings1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.tabControlPopulations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(392, 484);
            this.Name = "DlgNewRegion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DlgNewRegion";
            this.Shown += new System.EventHandler(this.DlgNewRegion_Shown);
            this.contextMenuStripPopulation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPopulations;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPopulation;
        private System.Windows.Forms.ToolStripMenuItem addPopulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePoulationToolStripMenuItem;
        private UserControls.UxRegionSettings uxRegionSettings1;
        private System.Windows.Forms.BindingSource bindingSourceRegion;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
    }
}