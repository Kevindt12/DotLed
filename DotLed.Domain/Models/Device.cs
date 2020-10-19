using System;

using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Models
{
	public class Device
	{

		/// <summary>
		/// The device name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The device manufacture.
		/// </summary>
		public string Manufacture { get; set; }

		/// <summary>
		/// The MAC Prefix for the device.
		/// </summary>
		public byte[] MACPrefix { get; set; }

		/// <summary>
		/// The operating system of the device.
		/// </summary>
		public OperatingSystem OS { get; set; }

		/// <summary>
		/// GPIO pins of the device.
		/// </summary>
		public GpioPin[] GPIOPins { get; protected set; }

		/// <summary>
		/// This device.
		/// </summary>
		internal Device()
		{

		}

		/// <summary>
		/// Gets all the spi busses that exist on the device.
		/// </summary>
		/// <returns></returns>
		public SpiBus[] GetSpiBusses()
		{
			throw new NotImplementedException();
		}

	}
}
