using System.Collections.Generic;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotLed.Common.Startup
{
	public class StartupCollection
	{

		protected List<StartupBase> StartupClasses { get; init; }

		public IConfiguration Configuration { get; init; }


		public StartupCollection(IConfiguration configuration)
		{
			StartupClasses = new List<StartupBase>();
			Configuration = configuration;
		}


		public void AddStartUp<TStartupBase>() where TStartupBase : StartupBase, new()
		{
			TStartupBase startup = new TStartupBase { Configuration = Configuration };

			StartupClasses.Add(startup);
		}


		public void ConfigureServices(IServiceCollection services)
		{
			StartupClasses.ForEach(startup => startup.ConfigureServices(services));
		}

		public IEnumerable<Assembly> GetAssemblies()
		{
			foreach (StartupBase startup in StartupClasses)
			{
				yield return startup.GetType().Assembly;
			}
		}


	}
}
