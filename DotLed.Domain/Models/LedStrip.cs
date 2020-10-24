using System;

using DotLed.Domain.Collections;

namespace DotLed.Domain.Models
{
	public class LedStrip
	{

		/// <summary>
		/// the leds on the strip.
		/// </summary>
		public LedArray Leds { get; protected set; }

		/// <summary>
		/// This is a value between 0 - 255 for the max brightness.
		/// </summary>
		public byte MaxBrightness { get; set; } = 255;

		/// <summary>
		/// Spi Bus that is connected to the led strip.
		/// </summary>
		public SpiBus SpiBus { get; protected set; }



		/// <summary>
		/// The led strip of the application.
		/// </summary>
		/// <param name="ledCount"></param>
		public LedStrip(int ledCount)
		{
			Leds = new LedArray(ledCount);
		}



		/// <summary>
		/// Attaching a SPI bus.
		/// </summary>
		/// <param name="bus"></param>
		public void AttachSpiBus(SpiBus bus)
		{
			// Making sure that the bus is not allready in use.
			if(bus.AttachedDevice != null) {
				throw new InvalidOperationException($"Bus {bus} is already in use and cannot be used on a other strip until detached.");
			}

			bus.AttachDevice(this);
			SpiBus = bus;
		}

		/// <summary>
		/// Detacheds the spi bus.
		/// </summary>
		public void DetachedSpiBus()
		{
			SpiBus.DetachDevice();
			SpiBus = null;
		}



	}
}
