using System;
using System.Device.Spi;
using System.Threading.Tasks;

using DotLed.Domain.Services.SpiBus;
using DotLed.Domain.ValueObjects;

using Iot.Device.Spi;

namespace DotLed.Infrastructure.Spi
{
	public class SpiBusWriter : ISpiBusWriter, IDisposable
	{
		private bool disposedValue;

		private SpiDevice _spiDevice;

		public int SpiBusId { get; init; }
		public int ChipEnableId { get; init; }
		public SpiBusSettings SpiBusSettings { get; set; }


		/// <summary>
		/// The led strip to write the spi data to.
		/// </summary>
		/// <param name="ledStrip"></param>
		public SpiBusWriter(int spiBusId, int chipEnableId, SpiBusSettings settings)
		{
			SpiBusId = spiBusId;
			ChipEnableId = chipEnableId;
			SpiBusSettings = settings;

			_spiDevice = SpiDevice.Create(new SpiConnectionSettings(spiBusId, chipEnableId)
			{
				ClockFrequency = settings.ClockSpeed,
				DataBitLength = settings.DataBitLength,
				DataFlow = (DataFlow)settings.DataFlow,
				Mode = (SpiMode)settings.SpiMode
			});
		}


		/// <summary>
		/// Creates a software spi bus writer.
		/// </summary>
		/// <param name="spiBusId"></param>
		/// <param name="chipEnableId"></param>
		/// <param name="settings"></param>
		/// <param name="pin"></param>
		public SpiBusWriter(int spiBusId, int chipEnableId, SpiBusSettings settings, GpioPin pin)
		{
			SpiBusId = spiBusId;
			ChipEnableId = chipEnableId;
			SpiBusSettings = settings;

			_spiDevice = new SoftwareSpi(
				pin.Clock, 0,
				pin.Mosi,
				pin.ChipEnable,
				new SpiConnectionSettings(spiBusId, chipEnableId)
				{
					ClockFrequency = settings.ClockSpeed,
					DataBitLength = settings.DataBitLength,
					DataFlow = (DataFlow)settings.DataFlow,
					Mode = (SpiMode)settings.SpiMode
				},
			new System.Device.Gpio.GpioController(System.Device.Gpio.PinNumberingScheme.Board),
			true
			);
		}

		public void Write(byte[] buffer, int index, int count)
		{
			_spiDevice.Write(buffer.AsMemory(index, count).Span);
		}

		public void Write(Span<byte> data)
		{
			_spiDevice.Write(data);
		}

		public Task WriteAsync(byte[] buffer, int index, int count)
		{
			return Task.Run(() => Write(buffer, index, count));
		}

		public Task WriteAsync(Span<byte> data)
		{
			byte[] buffer = data.ToArray();

			return Task.Run(() => Write(buffer));
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_spiDevice?.Dispose();
					_spiDevice = null;
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~SpiBusWriter()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
