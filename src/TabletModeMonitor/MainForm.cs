using System;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using TabletModeMonitor.Win32;

namespace TabletModeMonitor
{
	public partial class MainForm
		: Form
	{
		private readonly TabletModeWatcher _monitor;

		public MainForm()
		{
			InitializeComponent();

			var currentUser = WindowsIdentity.GetCurrent();
			_monitor = new TabletModeWatcher(currentUser.User.Value);
		}

		private void LoadSettings()
		{
			var desktopResolution = new DisplayResolution(Properties.Settings.Default.DesktopResolutionWidth, Properties.Settings.Default.DesktopResolutionHeight);
			var tabletResolution = new DisplayResolution(Properties.Settings.Default.TabletResolutionWidth, Properties.Settings.Default.TabletResolutionHeight);

			if (desktopResolution.Width > 0 && desktopResolution.Height > 0 && cboDesktopResolutions.Items.Contains(desktopResolution))
			{
				cboDesktopResolutions.SelectedItem = desktopResolution;
			}

			if (tabletResolution.Width > 0 && tabletResolution.Height > 0 && cboTabletResolutions.Items.Contains(tabletResolution))
			{
				cboTabletResolutions.SelectedItem = tabletResolution;
			}
		}

		private void ApplySettings()
		{
			var desktopResolution = (DisplayResolution) cboDesktopResolutions.SelectedItem;
			var tabletResolution = (DisplayResolution) cboTabletResolutions.SelectedItem;

			cboDesktopResolutions.Tag = desktopResolution;
			cboTabletResolutions.Tag = tabletResolution;

			_monitor.DesktopResolution = desktopResolution;
			_monitor.TabletResolution = tabletResolution;

			Properties.Settings.Default.DesktopResolutionWidth = desktopResolution.Width;
			Properties.Settings.Default.DesktopResolutionHeight = desktopResolution.Height;

			Properties.Settings.Default.TabletResolutionWidth = tabletResolution.Width;
			Properties.Settings.Default.TabletResolutionHeight = tabletResolution.Height;

			Properties.Settings.Default.Save();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			var supportedResolutions = DisplayResolutionManager.GetSupportedDisplayResolutions().ToArray();
			var currentResolution = DisplayResolutionManager.GetCurrentDisplayResolution();

			cboDesktopResolutions.Items.AddRange(supportedResolutions);
			cboDesktopResolutions.SelectedItem = currentResolution;

			cboTabletResolutions.Items.AddRange(supportedResolutions);
			cboTabletResolutions.SelectedItem = currentResolution;

			LoadSettings();
			ApplySettings();

			_monitor.Start();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			cboDesktopResolutions.SelectedItem = cboDesktopResolutions.Tag;
			cboTabletResolutions.SelectedItem = cboTabletResolutions.Tag;
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			ApplySettings();
		}

		private void settingsNotifyIcon_DoubleClick(object sender, EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == this.WindowState)
			{
				this.Hide();
			}
		}
	}
}