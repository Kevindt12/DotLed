
using DotLed.Domain.Enums;
using DotLed.Domain.Models;
using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Factories
{
	public sealed class SpiBusFactory
	{

		public ISpiBusWriterFactory SpiBusWriterFactory { get; init; }

		public SpiBusFactory(ISpiBusWriterFactory spiBusWriterFactory)
		{
			SpiBusWriterFactory = spiBusWriterFactory;
		}

		public SpiBus CreateSpiBus(int spiBusId, int chipSelectId, SpiBusProvider spiBusProvider, GpioPin gpio)
		{
			return new SpiBus(SpiBusWriterFactory)
			{
				SpiBusId = spiBusId,
				ChipEnableId = chipSelectId,
				BusProvider = spiBusProvider,
				Gpio = gpio
			};
		}

		public SpiBus CreateSpiBus(int spiBusId, int chipSelectId, SpiBusProvider spiBusProvider, SpiBusSettings settings, GpioPin gpio)
		{
			return new SpiBus(SpiBusWriterFactory)
			{
				SpiBusId = spiBusId,
				ChipEnableId = chipSelectId,
				BusProvider = spiBusProvider,
				Settings = settings,
				Gpio = gpio
			};
		}
	}
}







