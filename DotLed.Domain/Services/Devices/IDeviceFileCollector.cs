using System;

using DotLed.Domain.Data.Devices;
using DotLed.Domain.EventsArgs;

namespace DotLed.Domain.Services.Devices
{
	public interface IDeviceFileCollector
	{
		/// <summary>
		/// When a new file has been found.
		/// </summary>
		event EventHandler<NewDeviceFileEventArgs> NewFileFound;

		/// <summary>
		/// Gets all the device jons
		/// </summary>
		/// <returns></returns>
		DeviceJsonFile[] GetDeviceJsonFiles();









	}
}
