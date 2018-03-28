namespace TabletModeMonitor.Win32
{
	public class DisplayDevice
	{
		public string DeviceName { get; set; }
		public string DeviceString { get; set; }
		public string DeviceKey { get; set; }
		public DisplayDeviceStateFlags StateFlags { get; set; }
	}
}