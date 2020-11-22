using System;
using System.Collections.Generic;

using DotLed.Common.Drawing;
using DotLed.Domain.Interfaces;

namespace DotLed.Domain.Models
{
	public class AnimationSequence
	{

		public ICollection<IEnumerable<Color>> AnimationSequences { get; protected set; }

		/// <summary>
		/// The length of the led strip.
		/// </summary>
		public int LedStripLength { get; init; }

		/// <summary>
		/// Number of sequence action in the sequence.
		/// </summary>
		public int Count => AnimationSequences.Count;



		/// <summary>
		/// The animation Sequence of the led strip/
		/// </summary>
		/// <param name="ledStripLength"></param>
		public AnimationSequence(int ledStripLength)
		{
			LedStripLength = ledStripLength;
		}

		/// <summary>
		/// This the the animation seqence for a led strip.
		/// </summary>
		/// <param name="animationSequence"></param>
		internal AnimationSequence(ICollection<IEnumerable<Color>> animationSequence)
		{
			AnimationSequences = animationSequence;
		}


		public IAnimation CreateAnimation()
		{
			// Create the animation based on this 

			throw new NotImplementedException();
		}

	}
}
