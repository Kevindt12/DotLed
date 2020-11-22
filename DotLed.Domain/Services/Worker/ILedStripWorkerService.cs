
using DotLed.Domain.Interfaces;
using DotLed.Domain.Models;

namespace DotLed.Domain.Services.Worker
{
	public interface ILedStripWorkerService : IWokerService
	{
		/// <summary>
		/// The led strip animation.
		/// </summary>

		IAnimation LedStripAnimation { get; }
		

		/// <summary>
		/// The led strip we are interacting with.
		/// </summary>
		LedStrip LedStrip { get; }


		/// <summary>
		/// Changes the animation to something elee.
		/// </summary>
		/// <param name="animation">The animation that you want to change to.</param>
		void ChangeAnimation(IAnimation animation);




	}
}
