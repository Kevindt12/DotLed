using System;

namespace DotLed.Domain.Models
{

	public delegate void AnimationSequenceAction(LedStrip ledStrip);


	public class Animation
	{
		/// <summary>
		/// The name of the animation.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The actions that this annimation will play.
		/// </summary>
		public Action<LedStrip>[] Sequence { get; protected set; }

		/// <summary>
		/// The led strip sequence.
		/// </summary>
		public LedStrip LedStrip { get; set; }

		/// <summary>
		/// Checks if the led strip is attached.
		/// </summary>
		public bool IsLedStripAttached => (LedStrip != null);


		/// <summary>
		/// A animation
		/// </summary>
		public Animation()
		{

		}




		
		


	}
}
