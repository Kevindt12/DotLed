namespace DotLed.Domain.Models
{

	public delegate void AnimationSequenceAction(LedStrip ledStrip);


	public class Animation
	{
		/// <summary>
		/// The actions that this annimation will play.
		/// </summary>
		public AnimationSequenceAction[] Sequence { get; protected set; }


		/// <summary>
		/// A animation
		/// </summary>
		public Animation()
		{

		}








	}
}
