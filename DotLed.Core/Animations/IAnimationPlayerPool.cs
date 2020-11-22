using System.Collections.Generic;

namespace DotLed.Core.Animations
{
	public interface IAnimationPlayerPool : ICollection<AnimationPlayer>
	{

		



		void StopAllPayers();


		void StartAllPlayers();


	}
}
