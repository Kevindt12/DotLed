
using DotLed.Domain.Enums;
using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Models
{
	public class SpiBus
	{

		/// <summary>
		/// The spi bus id of the device.
		/// </summary>
		public int SpiBusId { get; set; }

		/// <summary>
		/// The chip enable id of the devcie
		/// </summary>
		public int ChipEnableId { get; set; }

		/// <summary>
		/// The led strip that is attached.
		/// </summary>
		public LedStrip AttachedDevice { get; protected set; }


		/// <summary>
		/// Selects if its a hardware or software provider for the spi bus.
		/// </summary>
		public SpiBusProvider BusProvider { get; set; }

		/// <summary>
		/// The spi bus settings.
		/// </summary>
		public SpiBusSettings Settings { get; set; }

		/// <summary>
		/// The GPIO for the spi bus if avalible. If using software then this will be populated else not unless the data is avalible to do so.
		/// </summary>
		public GpioPin Gpio { get; set; }


		public SpiBus()
		{

		}


		public void AttachDevice(LedStrip ledStrip)
		{
			AttachedDevice = ledStrip;
		}


		public void DetachDevice()
		{
			AttachedDevice = null;
		}



	}
}
