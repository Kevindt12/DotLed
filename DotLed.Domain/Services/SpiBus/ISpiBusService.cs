using System;

using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Services.SpiBus
{
	public interface ISpiBusService
	{

		/// <summary>
		/// Creates a new software spi bus.
		/// </summary>
		/// <param name="pin"></param>
		/// <returns></returns>
		Models.SpiBus CreateSoftwareSPIBus(GpioPin pin);


		/// <summary>
		/// Removes a spi bus as as software spi bus.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when you try to remove a hardware spi bus.</exception>
		/// <param name="bus"></param>
		void RemoveSoftwareSpiBus(Models.SpiBus bus);





	}
}
