
using DotLed.Domain.Services.SpiBus;
using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Factories
{
	public interface ISpiBusWriterFactory
	{



		ISpiBusWriter CreateHardwareSpiBusWriter(int spiBusId, int chipEnableId, SpiBusSettings settings);

		ISpiBusWriter CreateSoftwareSpiBusWriter(int spiBusId, int chipEnableId, SpiBusSettings settings, GpioPin pin);

	}
}
