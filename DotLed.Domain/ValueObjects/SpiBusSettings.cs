using DotLed.Domain.Enums;

namespace DotLed.Domain.ValueObjects
{
	public class SpiBusSettings
	{
		/// <summary>
		/// The clock speed of the bus.
		/// </summary>
		public int ClockSpeed { get; set; }

		/// <summary>
		/// The data bit length of the bus.
		/// </summary>
		public int DataBitLength { get; set; }

		/// <summary>
		/// The flow of data on the bus.
		/// </summary>
		public DataFlow DataFlow { get; set; }

		/// <summary>
		/// The spi mode of the bus.
		/// </summary>
		public SpiMode SpiMode { get; set; }


	}
}
