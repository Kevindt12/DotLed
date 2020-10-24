using System;

using DotLed.Domain.Interfaces;

namespace DotLed.Domain.Models
{

	public delegate void AnimationSequenceAction(LedStrip ledStrip);


	public class Animation : IAnimation
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


		public void StopAnimation()
		{

		}

		public void PlayAnimation()
		{
			
		}

		
		


	}
}
