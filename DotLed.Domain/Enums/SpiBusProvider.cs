namespace DotLed.Domain.Enums
{
	/// <summary>
	/// The provider type for the spi bus.
	/// </summary>
	public enum SpiBusProvider
	{
		/// <summary>
		/// The hardware spi provider on the board it self.
		/// </summary>
		Hardware = 0,

		/// <summary>
		/// The spi bus is emulated using software.
		/// </summary>
		Software = 1
	}
}
