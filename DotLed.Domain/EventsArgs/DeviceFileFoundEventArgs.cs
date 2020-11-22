using System;

using DotLed.Domain.Models;

namespace DotLed.Domain.EventsArgs
{
	public class DeviceFileFoundEventArgs : EventArgs
	{
		/// <summary>
		/// The device file that has been found.
		/// </summary>
		public Device File { get; init; }

		/// <summary>
		/// The device file that has been found in the directory.
		/// </summary>
		public DeviceFileFoundEventArgs()
		{

		}

		/// <summary>
		/// The device file that has been found in the directory
		/// </summary>
		/// <param name="file">The file that has been found.</param>
		public DeviceFileFoundEventArgs(Device file)
		{
			File = file;
		}

	}
}
