
using DotLed.Common.LedStrip.Normalizers;
using DotLed.Common.Startup;
using DotLed.Core.Animations;
using DotLed.Domain.Services.LedStrips;

using Microsoft.Extensions.DependencyInjection;

namespace DotLed.Core
{
	public class Startup : StartupBase
	{


		public Startup()
		{

		}


		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<ILedStripColorArrayNormalizer, Ws2812ColorNormalizer>();
			services.AddSingleton<IAnimationPlayerPool, AnimationPlayerPool>((x) => new AnimationPlayerPool());
		}
	}
}
