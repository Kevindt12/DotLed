using System;

using DotLed.Domain.EventsArgs;
using DotLed.Domain.Models;

namespace DotLed.Domain.Services.Devices
{
	public interface IDeviceFileCollector
	{
		/// <summary>
		/// When a new file has been found.
		/// </summary>
		event EventHandler<DeviceFileFoundEventArgs> NewFileFound;

		/// <summary>
		/// Gets all the device jons
		/// </summary>
		/// <returns></returns>
		Device[] GetDeviceJsonFiles();









	}
}
