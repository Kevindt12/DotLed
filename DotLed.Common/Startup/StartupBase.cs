using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace DotLed.Common.Startup
{
	public abstract class StartupBase
	{

		/// <summary>
		/// The configuration of this application.
		/// </summary>
		public IConfiguration Configuration { get; init; }



		public StartupBase()
		{

		}


		/// <summary>
		/// Configures the services for the project.
		/// </summary>
		/// <param name="services">The services.</param>
		public abstract void ConfigureServices(IServiceCollection services);
		

	}
}
