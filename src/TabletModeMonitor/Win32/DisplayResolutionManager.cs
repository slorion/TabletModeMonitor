using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TabletModeMonitor.Win32
{
	public static class DisplayResolutionManager
	{
		private enum DMDO
		{
			DEFAULT = 0,
			D90 = 1,
			D180 = 2,
			D270 = 3
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct DEVMODE
		{
			public const int DM_PELSWIDTH = 0x80000;
			public const int DM_PELSHEIGHT = 0x100000;
			private const int CCHDEVICENAME = 32;
			private const int CCHFORMNAME = 32;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
			public string dmDeviceName;

			public short dmSpecVersion;
			public short dmDriverVersion;
			public short dmSize;
			public short dmDriverExtra;
			public int dmFields;

			public int dmPositionX;
			public int dmPositionY;
			public DMDO dmDisplayOrientation;
			public int dmDisplayFixedOutput;

			public short dmColor;
			public short dmDuplex;
			public short dmYResolution;
			public short dmTTOption;
			public short dmCollate;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
			public string dmFormName;

			public short dmLogPixels;
			public int dmBitsPerPel;
			public int dmPelsWidth;
			public int dmPelsHeight;
			public int dmDisplayFlags;
			public int dmDisplayFrequency;
			public int dmICMMethod;
			public int dmICMIntent;
			public int dmMediaType;
			public int dmDitherType;
			public int dmReserved1;
			public int dmReserved2;
			public int dmPanningWidth;
			public int dmPanningHeight;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct DISPLAY_DEVICE
		{
			[MarshalAs(UnmanagedType.U4)]
			public int cb;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string DeviceName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceString;
			[MarshalAs(UnmanagedType.U4)]
			public DisplayDeviceStateFlags StateFlags;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceID;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceKey;
		}

		private const int ENUM_CURRENT_SETTINGS = -1;
		private const int ENUM_REGISTRY_SETTINGS = -2;

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE lpDevMode);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

		public static IEnumerable<DisplayDevice> GetDisplayDevices()
		{
			var device = new DISPLAY_DEVICE();
			device.cb = Marshal.SizeOf(device);

			for (uint id = 0; EnumDisplayDevices(null, id, ref device, 0); id++)
			{
				yield return new DisplayDevice {
					DeviceKey = device.DeviceKey,
					DeviceName = device.DeviceName,
					DeviceString = device.DeviceString,
					StateFlags = device.StateFlags
				};
			}
		}

		private static IEnumerable<DEVMODE> GetDeviceResolutions(string deviceName)
		{
			if (string.IsNullOrEmpty(deviceName)) throw new ArgumentNullException(nameof(deviceName));

			var dm = new DEVMODE();
			dm.dmSize = (short) Marshal.SizeOf(typeof(DEVMODE));

			for (int iModeNum = 0; EnumDisplaySettings(deviceName, iModeNum, ref dm); iModeNum++)
			{
				DEVMODE copy = dm;
				yield return copy;
			}
		}

		public static IEnumerable<DisplayResolution> GetSupportedDisplayResolutions()
		{
			var device = GetDisplayDevices().First(dd => (dd.StateFlags & DisplayDeviceStateFlags.PrimaryDevice) != 0);

			return GetDeviceResolutions(device.DeviceName)
				.Select(r => new DisplayResolution(r.dmPelsWidth, r.dmPelsHeight))
				.Distinct();
		}

		public static DisplayResolution GetCurrentDisplayResolution()
		{
			var device = GetDisplayDevices().First(dd => (dd.StateFlags & DisplayDeviceStateFlags.PrimaryDevice) != 0);

			var dm = new DEVMODE();
			dm.dmSize = (short) Marshal.SizeOf(typeof(DEVMODE));

			if (!EnumDisplaySettings(device.DeviceName, ENUM_CURRENT_SETTINGS, ref dm))
				throw new InvalidOperationException("Could not find current display device.");

			return new DisplayResolution(dm.dmPelsWidth, dm.dmPelsHeight);
		}

		public static DisplayChangeResultCode SetResolution(int width, int height)
		{
			if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be > 0.");
			if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be > 0.");

			var dm = new DEVMODE();
			dm.dmSize = (short) Marshal.SizeOf(typeof(DEVMODE));

			dm.dmPelsWidth = width;
			dm.dmPelsHeight = height;

			dm.dmFields = DEVMODE.DM_PELSWIDTH | DEVMODE.DM_PELSHEIGHT;

			return (DisplayChangeResultCode) ChangeDisplaySettings(ref dm, 0);
		}
	}
}