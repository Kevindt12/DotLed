using DotLed.Domain.Models;

namespace DotLed.Domain.Interfaces
{
	public interface IAnimation
	{
		/// <summary>
		/// The animation sequence to play on the led strip.
		/// </summary>
		public AnimationSequence AnimationSequence { get; }


		/// <summary>
		/// Starts the animation on the led strip.
		/// </summary>
		void PlayAnimation();

		/// <summary>
		/// Stops the animation on the led strip.
		/// </summary>
		void StopAnimation();
	}
}
