namespace DotLed.Domain.Enums
{
	/// <summary>
	/// The data flow for the spi bus.
	/// </summary>
	public enum SpiDataFlow
	{
		/// <summary>
		/// The least sinifican t bit will go first.
		/// </summary>
		LsbFirst = 0,

		/// <summary>
		/// The most synificate bit will go first.
		/// </summary>
		MsbFirst = 1
	}
}
