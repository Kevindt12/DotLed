
using Microsoft.Extensions.Configuration;

namespace DotLed.Infrastructure.Extentions
{
	public static class IConfigurationExtentions
	{

		/// <summary>
		/// Gets the folder location of the stored device files
		/// </summary>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static string GetDeviceFilesFolderLocation(this IConfiguration configuration)
		{
			return configuration.GetSection("DeviceFiles").GetSection("FolderLocation").Value;
		}


	}
}
