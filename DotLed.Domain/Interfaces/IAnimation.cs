namespace DotLed.Domain.Interfaces
{
	public interface IAnimation
	{
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
