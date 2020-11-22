
using System;

using DotLed.Domain.Collections;
using DotLed.Domain.Services.LedStrips;

namespace DotLed.Domain.Models
{
	public class LedStrip
	{

		public ILedStripColorArrayNormalizer LedStripColorArrayNormalizer { get; init; }


		/// <summary>
		/// The name of the ledstrip.
		/// </summary>
		public string Name { get; init; }

		/// <summary>
		/// the leds on the strip.
		/// </summary>
		public LedArray Leds { get; init; }

		/// <summary>
		/// This is a value between 0 - 255 for the max brightness.
		/// </summary>
		public byte MaxBrightness { get; set; } = 255;

		/// <summary>
		/// Spi Bus that is connected to the led strip.
		/// </summary>
		public SpiBus SpiBus { get; set; }


		


		/// <summary>
		/// The led strip of the application.
		/// </summary>
		/// <param name="ledCount"></param>
		public LedStrip(ILedStripColorArrayNormalizer normalizer, int ledCount)
		{
			Leds = new LedArray(ledCount);
		}




		public void Update()
		{
			// Check to make sure the spi bus is connected
			if(!SpiBus?.Connected ?? false)
			{
				throw new InvalidOperationException($"Cannot update the led strip on the {SpiBus?.SpiBusId}:{SpiBus?.ChipEnableId} becouse its not connected.");
			}

			// Writes the led strip data to the bus.
			SpiBus.Write(LedStripColorArrayNormalizer.GetBytes(Leds.GetColors()));

		}

		public void Clear()
		{
			Leds.Clear();

			Update();
		}



	}
}
