using DotLed.Domain.Models;
using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Data.Devices
{
	public class DeviceJsonFile
	{
		/// <summary>
		/// The name of the device.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The manfuacture of the device.
		/// </summary>
		public string Manufacture { get; set; }

		/// <summary>
		/// The first 3 bytes of the MAC Address.
		/// </summary>
		public byte[] MACPrefix { get; set; }

		/// <summary>
		/// GPIO pins on the device to be able to select.
		/// </summary>
		public GpioPin[] GPIOPins { get; set; }

		/// <summary>
		/// Getting all the spi busses that are avalible.
		/// </summary>
		public SpiBus[] GetSpiBus { get; set; }


	}

}

