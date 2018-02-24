namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls
{
    partial class UxRegionSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxInternalMigrationEnabled = new System.Windows.Forms.CheckBox();
            this.checkBoxExternalMigrationEnabled = new System.Windows.Forms.CheckBox();
            this.bindingSourceRegionSettings = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegionSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Internal Migration enabled";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "External Migration enabled";
            // 
            // checkBoxInternalMigrationEnabled
            // 
            this.checkBoxInternalMigrationEnabled.AutoSize = true;
            this.checkBoxInternalMigrationEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceRegionSettings, "InternalMigrationEnabled", true));
            this.checkBoxInternalMigrationEnabled.Location = new System.Drawing.Point(167, 5);
            this.checkBoxInternalMigrationEnabled.Name = "checkBoxInternalMigrationEnabled";
            this.checkBoxInternalMigrationEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBoxInternalMigrationEnabled.TabIndex = 7;
            this.checkBoxInternalMigrationEnabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxExternalMigrationEnabled
            // 
            this.checkBoxExternalMigrationEnabled.AutoSize = true;
            this.checkBoxExternalMigrationEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceRegionSettings, "ExternalMigrationEnabled", true));
            this.checkBoxExternalMigrationEnabled.Location = new System.Drawing.Point(167, 31);
            this.checkBoxExternalMigrationEnabled.Name = "checkBoxExternalMigrationEnabled";
            this.checkBoxExternalMigrationEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBoxExternalMigrationEnabled.TabIndex = 8;
            this.checkBoxExternalMigrationEnabled.UseVisualStyleBackColor = true;
            // 
            // bindingSourceRegionSettings
            // 
            this.bindingSourceRegionSettings.DataSource = typeof(Arcesoft.TicTacToe.Evolution.Environs.RegionSettings);
            // 
            // UxRegionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxExternalMigrationEnabled);
            this.Controls.Add(this.checkBoxInternalMigrationEnabled);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UxRegionSettings";
            this.Size = new System.Drawing.Size(322, 64);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegionSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxInternalMigrationEnabled;
        private System.Windows.Forms.CheckBox checkBoxExternalMigrationEnabled;
        private System.Windows.Forms.BindingSource bindingSourceRegionSettings;
    }
}
