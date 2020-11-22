
using DotLed.Common.Startup;
using DotLed.Domain.Factories;
using DotLed.Infrastructure.Factories;

using Microsoft.Extensions.DependencyInjection;

namespace DotLed.Infrastructure
{
	public class Startup : StartupBase
	{

		public Startup() : base()
		{

		}



		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<ISpiBusWriterFactory, SpiBusWriterFactory>();
		}
	}
}
