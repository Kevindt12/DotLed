using System;
using System.Threading.Tasks;

namespace DotLed.Domain.Services.Bus
{
	public interface IBusCommunicationService
	{

		void Write(Span<byte> data);
		void Write(byte[] data, int index, int count);

		Task WriteAsync(Span<byte> data);
		Task WriteAsync(byte[] data, int index, int count);


	}
}
