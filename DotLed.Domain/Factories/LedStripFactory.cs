
using DotLed.Domain.Models;
using DotLed.Domain.Services.LedStrips;

namespace DotLed.Domain.Factories
{
	public sealed class LedStripFactory
	{

		public ILedStripColorArrayNormalizer LedStripColorArrayNormalizer { get; init; }


		public LedStripFactory(ILedStripColorArrayNormalizer ledStripColorArrayNormalizer)
		{
			LedStripColorArrayNormalizer = ledStripColorArrayNormalizer;
		}


		public LedStrip CreateLedStrip(int ledCount, string name)
		{
			return new LedStrip(LedStripColorArrayNormalizer, ledCount)
			{
				Name = name
			};
		}

		public LedStrip CreateLedStrip(int ledCount, string name, SpiBus spiBus)
		{
			return new LedStrip(LedStripColorArrayNormalizer, ledCount)
			{
				Name = name,
				SpiBus = spiBus
			};
		}


	}
}
