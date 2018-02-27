namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls
{
    partial class UxPopulationSettings
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
            this.components = new System.ComponentModel.Container();
            this.labelPresets = new System.Windows.Forms.Label();
            this.comboBoxPresets = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMutationRate = new System.Windows.Forms.TextBox();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxMaximumPopulation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxChildBearingLimit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaximumGenes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMatchTournaments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxBreederType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFitnessEvaluatorType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPresets
            // 
            this.labelPresets.Location = new System.Drawing.Point(3, 12);
            this.labelPresets.Name = "labelPresets";
            this.labelPresets.Size = new System.Drawing.Size(126, 13);
            this.labelPresets.TabIndex = 0;
            this.labelPresets.Text = "Select Preset settings";
            // 
            // comboBoxPresets
            // 
            this.comboBoxPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPresets.FormattingEnabled = true;
            this.comboBoxPresets.Location = new System.Drawing.Point(136, 9);
            this.comboBoxPresets.Name = "comboBoxPresets";
            this.comboBoxPresets.Size = new System.Drawing.Size(183, 21);
            this.comboBoxPresets.TabIndex = 1;
            this.comboBoxPresets.SelectedIndexChanged += new System.EventHandler(this.comboBoxPresets_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MutationRate";
            // 
            // textBoxMutationRate
            // 
            this.textBoxMutationRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMutationRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceMain, "MutationRate", true));
            this.textBoxMutationRate.Location = new System.Drawing.Point(136, 90);
            this.textBoxMutationRate.Name = "textBoxMutationRate";
            this.textBoxMutationRate.Size = new System.Drawing.Size(183, 20);
            this.textBoxMutationRate.TabIndex = 2;
            // 
            // bindingSourceMain
            // 
            this.bindingSourceMain.DataSource = typeof(Arcesoft.TicTacToe.Evolution.PopulationSettings);
            // 
            // textBoxMaximumPopulation
            // 
            this.textBoxMaximumPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMaximumPopulation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceMain, "MaximumPopulationSize", true));
            this.textBoxMaximumPopulation.Location = new System.Drawing.Point(136, 116);
            this.textBoxMaximumPopulation.Name = "textBoxMaximumPopulation";
            this.textBoxMaximumPopulation.Size = new System.Drawing.Size(183, 20);
            this.textBoxMaximumPopulation.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Maximum Population Size";
            // 
            // textBoxChildBearingLimit
            // 
            this.textBoxChildBearingLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChildBearingLimit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceMain, "IndividualChildBearingLimit", true));
            this.textBoxChildBearingLimit.Location = new System.Drawing.Point(136, 142);
            this.textBoxChildBearingLimit.Name = "textBoxChildBearingLimit";
            this.textBoxChildBearingLimit.Size = new System.Drawing.Size(183, 20);
            this.textBoxChildBearingLimit.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Child Bearing limit";
            // 
            // textBoxMaximumGenes
            // 
            this.textBoxMaximumGenes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMaximumGenes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceMain, "MaximumGenesPerIndividual", true));
            this.textBoxMaximumGenes.Location = new System.Drawing.Point(136, 168);
            this.textBoxMaximumGenes.Name = "textBoxMaximumGenes";
            this.textBoxMaximumGenes.Size = new System.Drawing.Size(183, 20);
            this.textBoxMaximumGenes.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Maximum Genes";
            // 
            // textBoxMatchTournaments
            // 
            this.textBoxMatchTournaments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMatchTournaments.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceMain, "MatchTournaments", true));
            this.textBoxMatchTournaments.Location = new System.Drawing.Point(136, 194);
            this.textBoxMatchTournaments.Name = "textBoxMatchTournaments";
            this.textBoxMatchTournaments.Size = new System.Drawing.Size(183, 20);
            this.textBoxMatchTournaments.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Match tournaments";
            // 
            // comboBoxBreederType
            // 
            this.comboBoxBreederType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBreederType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBreederType.FormattingEnabled = true;
            this.comboBoxBreederType.Location = new System.Drawing.Point(136, 36);
            this.comboBoxBreederType.Name = "comboBoxBreederType";
            this.comboBoxBreederType.Size = new System.Drawing.Size(183, 21);
            this.comboBoxBreederType.TabIndex = 7;
            this.comboBoxBreederType.SelectedIndexChanged += new System.EventHandler(this.comboBoxBreederType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Breeder type";
            // 
            // comboBoxFitnessEvaluatorType
            // 
            this.comboBoxFitnessEvaluatorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFitnessEvaluatorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFitnessEvaluatorType.FormattingEnabled = true;
            this.comboBoxFitnessEvaluatorType.Location = new System.Drawing.Point(136, 63);
            this.comboBoxFitnessEvaluatorType.Name = "comboBoxFitnessEvaluatorType";
            this.comboBoxFitnessEvaluatorType.Size = new System.Drawing.Size(183, 21);
            this.comboBoxFitnessEvaluatorType.TabIndex = 8;
            this.comboBoxFitnessEvaluatorType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFitnessEvaluatorType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Fitness Evaluator type";
            // 
            // UxPopulationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxFitnessEvaluatorType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxBreederType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxMatchTournaments);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMaximumGenes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxChildBearingLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMaximumPopulation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMutationRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPresets);
            this.Controls.Add(this.labelPresets);
            this.MinimumSize = new System.Drawing.Size(322, 219);
            this.Name = "UxPopulationSettings";
            this.Size = new System.Drawing.Size(322, 219);
            this.Load += new System.EventHandler(this.UxPopulationSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.Label labelPresets;
        private System.Windows.Forms.ComboBox comboBoxPresets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMutationRate;
        private System.Windows.Forms.TextBox textBoxMaximumPopulation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxChildBearingLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMaximumGenes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMatchTournaments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxBreederType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxFitnessEvaluatorType;
        private System.Windows.Forms.Label label7;
    }
}
