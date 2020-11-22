using System;

namespace DotLed.Domain.Models
{
	public class Animation
	{
		/// <summary>
		/// The name of the animation.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The actions that this annimation will play.
		/// </summary>
		public AnimationSequence Sequence { get; init; }

		public int PlayFrequency { get; set; }

		/// <summary>
		/// A animation
		/// </summary>
		public Animation(AnimationSequence sequence)
		{
			Sequence = sequence ?? throw new ArgumentNullException(nameof(sequence), "The sequence of a animation cannot be null.");
		}



		
		
		


	}
}
