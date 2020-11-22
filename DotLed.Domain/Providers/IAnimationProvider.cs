
using DotLed.Domain.Interfaces;

namespace DotLed.Domain.Providers
{
	public interface IAnimationProvider
	{


		IAnimation GetAnimation(string animationName);

	}
}
