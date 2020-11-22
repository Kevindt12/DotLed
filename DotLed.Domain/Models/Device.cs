using System;
using System.Collections.Generic;

using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Models
{
	public record Device
	{
		/// <summary>
		/// The device name.
		/// </summary>
		public string Name { get; init; }

		/// <summary>
		/// The device manufacture.
		/// </summary>
		public string Manufacture { get; init; }

		/// <summary>
		/// The MAC Prefix for the device.
		/// </summary>
		public byte[] MACPrefix { get; init; }

		/// <summary>
		/// The operating system of the device.
		/// </summary>
		public OperatingSystem? OS { get; init; }

		/// <summary>
		/// GPIO pins of the device.
		/// </summary>
		public IEnumerable<GpioPin> GPIOPins { get; init; }

		/// <summary>
		/// Gets all the spi buses that exist on the device.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<SpiBusInfo> SpiBusses { get; init; }

		public Device()
		{

		}

		
	}
}
