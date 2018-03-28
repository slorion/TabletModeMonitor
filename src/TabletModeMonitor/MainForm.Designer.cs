namespace TabletModeMonitor
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.settingsNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.grpDesktopMode = new System.Windows.Forms.GroupBox();
			this.lblDesktopResolution = new System.Windows.Forms.Label();
			this.cboDesktopResolutions = new System.Windows.Forms.ComboBox();
			this.grpTabletMode = new System.Windows.Forms.GroupBox();
			this.lblTabletResolution = new System.Windows.Forms.Label();
			this.cboTabletResolutions = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.grpDesktopMode.SuspendLayout();
			this.grpTabletMode.SuspendLayout();
			this.SuspendLayout();
			// 
			// settingsNotifyIcon
			// 
			this.settingsNotifyIcon.BalloonTipText = "Modify monitor settings";
			this.settingsNotifyIcon.BalloonTipTitle = "Settings";
			this.settingsNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("settingsNotifyIcon.Icon")));
			this.settingsNotifyIcon.Text = "Tablet Mode Monitor";
			this.settingsNotifyIcon.Visible = true;
			this.settingsNotifyIcon.DoubleClick += new System.EventHandler(this.settingsNotifyIcon_DoubleClick);
			// 
			// grpDesktopMode
			// 
			this.grpDesktopMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpDesktopMode.Controls.Add(this.lblDesktopResolution);
			this.grpDesktopMode.Controls.Add(this.cboDesktopResolutions);
			this.grpDesktopMode.Location = new System.Drawing.Point(12, 12);
			this.grpDesktopMode.Name = "grpDesktopMode";
			this.grpDesktopMode.Size = new System.Drawing.Size(300, 60);
			this.grpDesktopMode.TabIndex = 0;
			this.grpDesktopMode.TabStop = false;
			this.grpDesktopMode.Text = "Desktop Mode";
			// 
			// lblDesktopResolution
			// 
			this.lblDesktopResolution.AutoSize = true;
			this.lblDesktopResolution.Location = new System.Drawing.Point(6, 28);
			this.lblDesktopResolution.Name = "lblDesktopResolution";
			this.lblDesktopResolution.Size = new System.Drawing.Size(57, 13);
			this.lblDesktopResolution.TabIndex = 0;
			this.lblDesktopResolution.Text = "Resolution";
			// 
			// cboDesktopResolutions
			// 
			this.cboDesktopResolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboDesktopResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDesktopResolutions.FormattingEnabled = true;
			this.cboDesktopResolutions.Location = new System.Drawing.Point(69, 25);
			this.cboDesktopResolutions.Name = "cboDesktopResolutions";
			this.cboDesktopResolutions.Size = new System.Drawing.Size(225, 21);
			this.cboDesktopResolutions.TabIndex = 1;
			// 
			// grpTabletMode
			// 
			this.grpTabletMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpTabletMode.Controls.Add(this.lblTabletResolution);
			this.grpTabletMode.Controls.Add(this.cboTabletResolutions);
			this.grpTabletMode.Location = new System.Drawing.Point(12, 78);
			this.grpTabletMode.Name = "grpTabletMode";
			this.grpTabletMode.Size = new System.Drawing.Size(300, 60);
			this.grpTabletMode.TabIndex = 1;
			this.grpTabletMode.TabStop = false;
			this.grpTabletMode.Text = "Tablet Mode";
			// 
			// lblTabletResolution
			// 
			this.lblTabletResolution.AutoSize = true;
			this.lblTabletResolution.Location = new System.Drawing.Point(6, 28);
			this.lblTabletResolution.Name = "lblTabletResolution";
			this.lblTabletResolution.Size = new System.Drawing.Size(57, 13);
			this.lblTabletResolution.TabIndex = 0;
			this.lblTabletResolution.Text = "Resolution";
			// 
			// cboTabletResolutions
			// 
			this.cboTabletResolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboTabletResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTabletResolutions.FormattingEnabled = true;
			this.cboTabletResolutions.Location = new System.Drawing.Point(69, 25);
			this.cboTabletResolutions.Name = "cboTabletResolutions";
			this.cboTabletResolutions.Size = new System.Drawing.Size(225, 21);
			this.cboTabletResolutions.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(237, 144);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnApply.Location = new System.Drawing.Point(156, 144);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "&Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnApply;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(324, 171);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.grpTabletMode);
			this.Controls.Add(this.grpDesktopMode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tablet Mode Monitor";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.grpDesktopMode.ResumeLayout(false);
			this.grpDesktopMode.PerformLayout();
			this.grpTabletMode.ResumeLayout(false);
			this.grpTabletMode.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon settingsNotifyIcon;
		private System.Windows.Forms.GroupBox grpDesktopMode;
		private System.Windows.Forms.Label lblDesktopResolution;
		private System.Windows.Forms.ComboBox cboDesktopResolutions;
		private System.Windows.Forms.GroupBox grpTabletMode;
		private System.Windows.Forms.Label lblTabletResolution;
		private System.Windows.Forms.ComboBox cboTabletResolutions;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
	}
}

