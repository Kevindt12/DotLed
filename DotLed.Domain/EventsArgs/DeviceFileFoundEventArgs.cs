using System;

using DotLed.Domain.Models;

namespace DotLed.Domain.EventsArgs
{
	public class DeviceFileFoundEventArgs : EventArgs
	{



		public Device File { get; set; }


	}
}
