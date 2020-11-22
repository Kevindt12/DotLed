using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLed.Domain.Models
{
	public abstract class Bus
	{


		/// <summary>
		/// Writes data to the bus.
		/// </summary>
		/// <param name="data"></param>
		public abstract void Write(Span<byte> data);

		/// <summary>
		/// Writes data to the bus.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="count"></param>
		public abstract void Write(byte[] data, int index, int count);

		/// <summary>
		/// Writes data to the bus.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public abstract Task WriteAsync(Span<byte> data);

		/// <summary>
		/// Writes data to the bus.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public abstract Task WriteAsync(byte[] data, int index, int count);



	}
}
