
using DotLed.Core.Animations;
using DotLed.Domain.Models;

namespace DotLed.Core.Factories
{
	public sealed class AnimationPlayerFactory
	{
		public IAnimationPlayerPool Pool { get; set; }


		public AnimationPlayerFactory(IAnimationPlayerPool pool)
		{
			Pool = pool;
		}

		public AnimationPlayer CreateAnimationPlayer(LedStrip ledStrip, Animation animation)
		{
			AnimationPlayer player = new AnimationPlayer(ledStrip, animation);

			Pool.Add(player);

			return player;
		}


	}
}
