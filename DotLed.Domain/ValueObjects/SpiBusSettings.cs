using DotLed.Domain.Enums;

namespace DotLed.Domain.ValueObjects
{
	public record SpiBusSettings
	{
		/// <summary>
		/// The clock speed of the bus.
		/// </summary>
		public int ClockSpeed { get; init; }

		/// <summary>
		/// The data bit length of the bus.
		/// </summary>
		public int DataBitLength { get; init; }

		/// <summary>
		/// The flow of data on the bus.
		/// </summary>
		public SpiDataFlow DataFlow { get; init; }

		/// <summary>
		/// The spi mode of the bus.
		/// </summary>
		public SpiMode SpiMode { get; init; }

		public SpiBusSettings()
		{

		}

		public SpiBusSettings(int clockSpeed, int dataBitLength, SpiDataFlow flow, SpiMode mode) => (ClockSpeed, DataBitLength, DataFlow, SpiMode) = (clockSpeed, dataBitLength, flow, mode);
		


	}
}
