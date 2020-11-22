using System;
using System.Collections.Generic;

using DotLed.Domain.EventsArgs;
using DotLed.Domain.Models;

namespace DotLed.Domain.Services.Devices
{

	/// <summary>
	/// This si the service for handling all the things to do with the automation for finding out where the files should be collected.
	/// </summary>
	public interface IDeviceFileCollectorService
	{
		/// <summary>
		/// When a new file has been found.
		/// </summary>
		event EventHandler<DeviceFileFoundEventArgs> NewFileFound;

		/// <summary>
		/// Gets all the device files.
		/// </summary>
		/// <returns></returns>
		IEnumerable<Device> GetDevices();

		/// <summary>
		/// The file location of where the collector is watching.
		/// </summary>
		string FolderLocation { get; }


	}
}
