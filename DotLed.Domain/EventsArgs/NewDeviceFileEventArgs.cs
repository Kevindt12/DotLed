using System;

using DotLed.Domain.Data.Devices;

namespace DotLed.Domain.EventsArgs
{
	public class NewDeviceFileEventArgs : EventArgs
	{



		public DeviceJsonFile File { get; set; }


	}
}
