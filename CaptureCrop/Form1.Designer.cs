namespace CaptureCrop
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grpCrop = new System.Windows.Forms.GroupBox();
            this.lblBottom = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.txtBottom = new System.Windows.Forms.TextBox();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.cmdBatch = new System.Windows.Forms.Button();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblProcess = new System.Windows.Forms.Label();
            this.cboSetupOption = new System.Windows.Forms.ComboBox();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.chkSaveOriginal = new System.Windows.Forms.CheckBox();
            this.lblDPI = new System.Windows.Forms.Label();
            this.txtDPI = new System.Windows.Forms.TextBox();
            this.cmdMonitorFolder = new System.Windows.Forms.Button();
            this.cmdFolder = new System.Windows.Forms.Button();
            this.lblSaveFolder = new System.Windows.Forms.Label();
            this.lblMonitorFolder = new System.Windows.Forms.Label();
            this.grpCrop.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCrop
            // 
            this.grpCrop.Controls.Add(this.lblBottom);
            this.grpCrop.Controls.Add(this.lblRight);
            this.grpCrop.Controls.Add(this.lblTop);
            this.grpCrop.Controls.Add(this.txtBottom);
            this.grpCrop.Controls.Add(this.txtRight);
            this.grpCrop.Controls.Add(this.txtTop);
            this.grpCrop.Controls.Add(this.txtLeft);
            this.grpCrop.Controls.Add(this.lblLeft);
            this.grpCrop.Location = new System.Drawing.Point(237, 12);
            this.grpCrop.Name = "grpCrop";
            this.grpCrop.Size = new System.Drawing.Size(200, 175);
            this.grpCrop.TabIndex = 12;
            this.grpCrop.TabStop = false;
            this.grpCrop.Text = "Crop";
            // 
            // lblBottom
            // 
            this.lblBottom.AutoSize = true;
            this.lblBottom.Location = new System.Drawing.Point(34, 132);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(43, 13);
            this.lblBottom.TabIndex = 17;
            this.lblBottom.Text = "Bottom:";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(32, 98);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(32, 13);
            this.lblRight.TabIndex = 16;
            this.lblRight.Text = "Right";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(32, 59);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(26, 13);
            this.lblTop.TabIndex = 15;
            this.lblTop.Text = "Top";
            // 
            // txtBottom
            // 
            this.txtBottom.Location = new System.Drawing.Point(86, 132);
            this.txtBottom.MaxLength = 5;
            this.txtBottom.Name = "txtBottom";
            this.txtBottom.Size = new System.Drawing.Size(55, 20);
            this.txtBottom.TabIndex = 14;
            this.txtBottom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBottom_KeyPress);
            this.txtBottom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBottom_KeyUp);
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(86, 96);
            this.txtRight.MaxLength = 5;
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(55, 20);
            this.txtRight.TabIndex = 13;
            this.txtRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRight_KeyPress);
            this.txtRight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRight_KeyUp);
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(86, 59);
            this.txtTop.MaxLength = 5;
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(55, 20);
            this.txtTop.TabIndex = 12;
            this.txtTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTop_KeyPress);
            this.txtTop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTop_KeyUp);
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(86, 21);
            this.txtLeft.MaxLength = 5;
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(55, 20);
            this.txtLeft.TabIndex = 11;
            this.txtLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLeft_KeyPress);
            this.txtLeft.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLeft_KeyUp);
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(32, 23);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(28, 13);
            this.lblLeft.TabIndex = 10;
            this.lblLeft.Text = "Left:";
            // 
            // cmdBatch
            // 
            this.cmdBatch.Location = new System.Drawing.Point(35, 287);
            this.cmdBatch.Name = "cmdBatch";
            this.cmdBatch.Size = new System.Drawing.Size(89, 36);
            this.cmdBatch.TabIndex = 14;
            this.cmdBatch.Text = "&Batch";
            this.cmdBatch.UseVisualStyleBackColor = true;
            this.cmdBatch.Click += new System.EventHandler(this.cmdBatch_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.lblSave);
            this.grpSettings.Controls.Add(this.lblProcess);
            this.grpSettings.Controls.Add(this.cboSetupOption);
            this.grpSettings.Controls.Add(this.cboFileType);
            this.grpSettings.Controls.Add(this.chkSaveOriginal);
            this.grpSettings.Controls.Add(this.lblDPI);
            this.grpSettings.Controls.Add(this.txtDPI);
            this.grpSettings.Location = new System.Drawing.Point(16, 12);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(200, 175);
            this.grpSettings.TabIndex = 20;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Location = new System.Drawing.Point(16, 98);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(47, 13);
            this.lblSave.TabIndex = 27;
            this.lblSave.Text = "Save As";
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(16, 134);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(45, 13);
            this.lblProcess.TabIndex = 26;
            this.lblProcess.Text = "Process";
            // 
            // cboSetupOption
            // 
            this.cboSetupOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSetupOption.FormattingEnabled = true;
            this.cboSetupOption.Items.AddRange(new object[] {
            "Print Screen",
            "Monitor Folder"});
            this.cboSetupOption.Location = new System.Drawing.Point(78, 131);
            this.cboSetupOption.Name = "cboSetupOption";
            this.cboSetupOption.Size = new System.Drawing.Size(89, 21);
            this.cboSetupOption.TabIndex = 25;
            this.cboSetupOption.SelectedIndexChanged += new System.EventHandler(this.cboSetupOption_SelectedIndexChanged);
            // 
            // cboFileType
            // 
            this.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Items.AddRange(new object[] {
            "Bitmap",
            "Jpeg",
            "Png"});
            this.cboFileType.Location = new System.Drawing.Point(78, 95);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(89, 21);
            this.cboFileType.TabIndex = 24;
            this.cboFileType.SelectedIndexChanged += new System.EventHandler(this.cboFileType_SelectedIndexChanged);
            // 
            // chkSaveOriginal
            // 
            this.chkSaveOriginal.AutoSize = true;
            this.chkSaveOriginal.Checked = true;
            this.chkSaveOriginal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveOriginal.Location = new System.Drawing.Point(78, 24);
            this.chkSaveOriginal.Name = "chkSaveOriginal";
            this.chkSaveOriginal.Size = new System.Drawing.Size(89, 17);
            this.chkSaveOriginal.TabIndex = 22;
            this.chkSaveOriginal.Text = "Save Original";
            this.chkSaveOriginal.UseVisualStyleBackColor = true;
            this.chkSaveOriginal.Click += new System.EventHandler(this.chkSaveOriginal_Click);
            // 
            // lblDPI
            // 
            this.lblDPI.AutoSize = true;
            this.lblDPI.Location = new System.Drawing.Point(16, 59);
            this.lblDPI.Name = "lblDPI";
            this.lblDPI.Size = new System.Drawing.Size(28, 13);
            this.lblDPI.TabIndex = 21;
            this.lblDPI.Text = "DPI:";
            // 
            // txtDPI
            // 
            this.txtDPI.Location = new System.Drawing.Point(78, 59);
            this.txtDPI.MaxLength = 4;
            this.txtDPI.Name = "txtDPI";
            this.txtDPI.Size = new System.Drawing.Size(89, 20);
            this.txtDPI.TabIndex = 20;
            this.txtDPI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDPI_KeyPress);
            this.txtDPI.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDPI_KeyUp);
            // 
            // cmdMonitorFolder
            // 
            this.cmdMonitorFolder.Location = new System.Drawing.Point(35, 242);
            this.cmdMonitorFolder.Name = "cmdMonitorFolder";
            this.cmdMonitorFolder.Size = new System.Drawing.Size(89, 36);
            this.cmdMonitorFolder.TabIndex = 31;
            this.cmdMonitorFolder.Text = "&Monitor Folder";
            this.cmdMonitorFolder.UseVisualStyleBackColor = true;
            this.cmdMonitorFolder.Click += new System.EventHandler(this.cmdMonitorFolder_Click);
            // 
            // cmdFolder
            // 
            this.cmdFolder.Location = new System.Drawing.Point(35, 198);
            this.cmdFolder.Name = "cmdFolder";
            this.cmdFolder.Size = new System.Drawing.Size(89, 36);
            this.cmdFolder.TabIndex = 32;
            this.cmdFolder.Text = "&Save Folder";
            this.cmdFolder.UseVisualStyleBackColor = true;
            this.cmdFolder.Click += new System.EventHandler(this.cmdFolder_Click);
            // 
            // lblSaveFolder
            // 
            this.lblSaveFolder.AutoSize = true;
            this.lblSaveFolder.Location = new System.Drawing.Point(146, 215);
            this.lblSaveFolder.Name = "lblSaveFolder";
            this.lblSaveFolder.Size = new System.Drawing.Size(96, 13);
            this.lblSaveFolder.TabIndex = 33;
            this.lblSaveFolder.Text = "No folder selected.";
            // 
            // lblMonitorFolder
            // 
            this.lblMonitorFolder.AutoSize = true;
            this.lblMonitorFolder.Location = new System.Drawing.Point(146, 257);
            this.lblMonitorFolder.Name = "lblMonitorFolder";
            this.lblMonitorFolder.Size = new System.Drawing.Size(96, 13);
            this.lblMonitorFolder.TabIndex = 34;
            this.lblMonitorFolder.Text = "No folder selected.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 337);
            this.Controls.Add(this.lblMonitorFolder);
            this.Controls.Add(this.lblSaveFolder);
            this.Controls.Add(this.cmdFolder);
            this.Controls.Add(this.cmdMonitorFolder);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.cmdBatch);
            this.Controls.Add(this.grpCrop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capture / Crop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpCrop.ResumeLayout(false);
            this.grpCrop.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCrop;
        private System.Windows.Forms.Label lblBottom;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.TextBox txtBottom;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Button cmdBatch;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ComboBox cboSetupOption;
        private System.Windows.Forms.ComboBox cboFileType;
        private System.Windows.Forms.CheckBox chkSaveOriginal;
        private System.Windows.Forms.Label lblDPI;
        private System.Windows.Forms.TextBox txtDPI;
        private System.Windows.Forms.Button cmdMonitorFolder;
        private System.Windows.Forms.Button cmdFolder;
        private System.Windows.Forms.Label lblSaveFolder;
        private System.Windows.Forms.Label lblMonitorFolder;
    }
}

