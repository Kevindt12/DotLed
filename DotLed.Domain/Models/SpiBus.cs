
using System;
using System.Threading.Tasks;

using DotLed.Domain.Enums;
using DotLed.Domain.Factories;
using DotLed.Domain.Result;
using DotLed.Domain.Services.SpiBus;
using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Models
{
	public class SpiBus : Bus
	{
		public ISpiBusWriterFactory SpiBusWriterFactory { get; init; }

		protected SpiBusSettings _spiBusSettings;

		protected ISpiBusWriter SpiBusWriter { get; set; }


		/// <summary>
		/// The spi bus id of the device.
		/// </summary>
		public int SpiBusId { get; init; }

		/// <summary>
		/// The chip enable id of the devcie
		/// </summary>
		public int ChipEnableId { get; init; }

		/// <summary>
		/// Selects if its a hardware or software provider for the spi bus.
		/// </summary>
		public SpiBusProvider BusProvider { get; init; }

		/// <summary>
		/// The spi bus settings.
		/// </summary>
		public SpiBusSettings Settings
		{
			get => _spiBusSettings;
			set => _spiBusSettings = (Connected) ? throw new InvalidOperationException($"You cannot change the settings of the spi bus while the bus is running.") : value;
		}

		/// <summary>
		/// The GPIO for the spi bus if avalible. If using software then this will be populated else not unless the data is avalible to do so.
		/// </summary>
		public GpioPin Gpio { get; init; }

		public bool Connected => SpiBusWriter is not null;


		internal SpiBus(ISpiBusWriterFactory spiBusWriterFactory)
		{
			SpiBusWriterFactory = spiBusWriterFactory;
		}

		/// <summary>
		/// Connect to the spi bus.
		/// </summary>
		/// <returns></returns>
		public SpiConnectionResult Connect()
		{
			try
			{

			SpiBusWriter ??= (BusProvider == SpiBusProvider.Hardware) ?
				SpiBusWriterFactory.CreateHardwareSpiBusWriter(SpiBusId, ChipEnableId, Settings) :
				SpiBusWriterFactory.CreateSoftwareSpiBusWriter(SpiBusId, ChipEnableId, Settings, Gpio);

				return SpiConnectionResult.Success;
			}
			catch(Exception ex)
			{
				return SpiConnectionResult.Failed(SpiConnectionErrors.Failure);
			}
		}

		/// <summary>
		/// Disconnect from the spi bus.
		/// </summary>
		public void Disconnect()
		{
			SpiBusWriter?.Dispose();
			SpiBusWriter = null;
		}



		/// <summary>
		/// Writes data to the bus.
		/// </summary>
		/// <param name="data"></param>
		public override void Write(Span<byte> data)
		{
			if (!Connected)
			{
				throw new InvalidOperationException($"There is no spi bus connected.");
			}

			SpiBusWriter.Write(data);
		}

		/// <summary>
		/// WRites the data to the bus.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="count"></param>
		public override void Write(byte[] data, int index, int count)
		{
			if (!Connected)
			{
				throw new InvalidOperationException($"There is no spi bus connected.");
			}

			SpiBusWriter.Write(data, index, count);
		}

		/// <summary>
		/// WRites the data to the bus.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Task WriteAsync(Span<byte> data)
		{
			if (!Connected)
			{
				throw new InvalidOperationException($"There is no spi bus connected.");
			}

			return SpiBusWriter.WriteAsync(data);
		}

		/// <summary>
		/// Writes the data to the bus.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public override Task WriteAsync(byte[] data, int index, int count)
		{
			if (!Connected)
			{
				throw new InvalidOperationException($"There is no spi bus connected.");
			}

			return SpiBusWriter.WriteAsync(data, index, count);
		}
	}
}
