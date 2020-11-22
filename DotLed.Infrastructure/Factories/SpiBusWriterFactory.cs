
using DotLed.Domain.Factories;
using DotLed.Domain.Services.SpiBus;
using DotLed.Domain.ValueObjects;
using DotLed.Infrastructure.Spi;

namespace DotLed.Infrastructure.Factories
{
	public class SpiBusWriterFactory : ISpiBusWriterFactory
	{
		public ISpiBusWriter CreateHardwareSpiBusWriter(int spiBusId, int chipEnableId, SpiBusSettings settings)
		{
			return new SpiBusWriter(spiBusId, chipEnableId, settings);
		}

		public ISpiBusWriter CreateSoftwareSpiBusWriter(int spiBusId, int chipEnableId, SpiBusSettings settings, GpioPin pin)
		{
			return new SpiBusWriter(spiBusId, chipEnableId, settings, pin);
		}
	}
}
