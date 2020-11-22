
using System.Collections.Generic;

using DotLed.Infrastructure.Data;

namespace DotLed.Infrastructure.Services
{
	public interface IDeviceFileService
	{

		/// <summary>
		/// Gets all the device files sync
		/// </summary>
		/// <returns></returns>
		IEnumerable<DeviceFile> GetDeviceFiles();


		void RemoveFile(DeviceFile jsonFile);


	}
}
