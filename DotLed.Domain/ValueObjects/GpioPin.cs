namespace DotLed.Domain.ValueObjects
{
	public struct GpioPin
	{
		/// <summary>
		/// The master out slave in pin of the device.
		/// </summary>
		public byte Mosi { get; set; }

		/// <summary>
		/// The clock pin of the device.
		/// </summary>
		public byte Clock { get; set; }

		/// <summary>
		/// The chip enable pin.
		/// </summary>
		public byte ChipEnable { get; set; }





	}
}
