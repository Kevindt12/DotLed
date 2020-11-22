using System;
using System.Threading.Tasks;

using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Services.SpiBus
{
	public interface ISpiBusWriter : IDisposable
	{

		int SpiBusId { get; }

		int ChipEnableId { get; }

		SpiBusSettings SpiBusSettings { get; }



		void Write(byte[] buffer, int index, int count);

		void Write(Span<byte> data);

		Task WriteAsync(byte[] buffer, int index, int count);

		Task WriteAsync(Span<byte> data);

	}
}
