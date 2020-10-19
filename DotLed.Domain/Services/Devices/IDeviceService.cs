using DotLed.Domain.Models;

namespace DotLed.Domain.Services.Devices
{
	public interface IDeviceService
	{


		/// <summary>
		/// Gets the current device or it gets default.
		/// </summary>
		/// <returns></returns>
		Device GetCurrentDeviceOrDefault();


		

	}
}
