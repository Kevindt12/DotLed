using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLed.Domain.Services.Worker
{
	public interface IWokerService : IDisposable
	{
		/// <summary>
		/// Starts the worker service.
		/// </summary>
		void Start();

		/// <summary>
		/// Stops the service.
		/// </summary>
		void Stop();
	}
}
