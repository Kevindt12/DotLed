using System.Collections.Generic;

namespace DotLed.Infrastructure.Data
{
	/// <summary>
	/// The file of the devce.
	/// </summary>
	public record  DeviceFile
	{
		/// <summary>
		/// The name of the device.
		/// </summary>
		public string Name { get; init; }

		/// <summary>
		/// The manufacture of the device.
		/// </summary>
		public string Manufacture { get; init; }

		/// <summary>
		/// The first 3 bytes of the mac address (Manfufacture prefix)
		/// </summary>
		public byte[] MACPrefix { get; init; }


		/// <summary>
		/// The GPIO pins on the device.
		/// </summary>
		public IEnumerable<GPIOPin> GpioPins { get; init; }

		/// <summary>
		/// The Spi busses already addressible for the device.
		/// </summary>

		public IEnumerable<SpiBus> SpiBusses { get; init; }


		/// <summary>
		/// The GPIO pin on the device.
		/// </summary>
		public struct GPIOPin
		{
			/// <summary>
			/// The GPIO Pin
			/// </summary>
			public int Clock { get; init; }

			public int Mosi { get; set; }

			public int ChipEnable { get; set; }


		}

		/// <summary>
		/// The Spi busses that are already avalible.
		/// </summary>
		public struct SpiBus
		{
			public int SpiBusId { get; init; }

			public int ChipEnableId { get; init; }

			public GPIOPin GPIOPin { get; init; }


		}

	}




}
