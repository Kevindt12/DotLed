using System.Threading.Tasks;

using DotLed.Domain.Models;

namespace DotLed.Infrastructure.Services
{
	public interface ILedStripBusWriter
	{
		public LedStrip LedStrip { get; init; }


		/// <summary>
		/// Writes the led strip data to the provided spi bus.
		/// <exception cref="System.ArgumentNullException">Thrown when the spi bus property on the led strip is null</exception>
		/// </summary>
		/// <param name="ledStrip">The led strip that you want to write the data to the bus.</param>
		void Write(LedStrip ledStrip);

		/// <summary>
		/// Writes the led strip data to the provided spi bus.
		/// <exception cref="System.ArgumentNullException">Thrown when the spi bus property on the led strip is null</exception>
		/// </summary>
		/// <param name="ledStrip">The led strip that you want to write the data to the bus.</param>
		Task WriteAsync(LedStrip ledStrip);

		

	}
}
