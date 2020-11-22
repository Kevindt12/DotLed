
using DotLed.Common.Startup;
using DotLed.Domain.Factories;

using Microsoft.Extensions.DependencyInjection;

namespace DotLed.Domain
{
	public class Startup : StartupBase
	{



		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<LedStripFactory>();
			services.AddSingleton<SpiBusFactory>();
		}


	}
}
