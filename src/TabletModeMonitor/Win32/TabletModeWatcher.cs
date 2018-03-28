using Microsoft.Win32;
using System;
using System.Management;

namespace TabletModeMonitor.Win32
{
	internal class TabletModeWatcher : IDisposable
	{
		private readonly ManagementEventWatcher _watcher;

		public TabletModeWatcher(string userSid)
		{
			if (string.IsNullOrEmpty(userSid)) throw new ArgumentNullException(nameof(userSid));

			string wmiQuery = $@"SELECT * FROM RegistryValueChangeEvent WHERE Hive='HKEY_USERS' AND KeyPath='{userSid}\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell' AND ValueName='TabletMode'";
			_watcher = new ManagementEventWatcher(new EventQuery(wmiQuery));

			_watcher.EventArrived +=
				(s, e) => {
					var tabletMode = (int) Registry.GetValue($"HKEY_USERS\\{userSid}\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell", "TabletMode", 0);

					if (tabletMode == 1)
					{
						//Registry.SetValue($"HKEY_USERS\\{userSid}\\Control Panel\\Desktop\\PerMonitorSettings\\{this.MonitorId}", "DpiValue", this.TabletDpiValue, RegistryValueKind.DWord);
						DisplayResolutionManager.SetResolution(this.TabletResolution.Width, this.TabletResolution.Height);
					}
					else
					{
						//Registry.SetValue($"HKEY_USERS\\{userSid}\\Control Panel\\Desktop\\PerMonitorSettings\\{this.MonitorId}", "DpiValue", this.DesktopDpiValue, RegistryValueKind.DWord);
						DisplayResolutionManager.SetResolution(this.DesktopResolution.Width, this.DesktopResolution.Height);
					}
				};
		}

		//public int DesktopDpiValue { get; set; }
		//public int TabletDpiValue { get; set; }

		public DisplayResolution DesktopResolution { get; set; }
		public DisplayResolution TabletResolution { get; set; }

		public void Start()
		{
			_watcher.Start();
		}

		public void Stop()
		{
			_watcher.Stop();
		}

		public void Dispose()
		{
			_watcher?.Dispose();
		}
	}
}