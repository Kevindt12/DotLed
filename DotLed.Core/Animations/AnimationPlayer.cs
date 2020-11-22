using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using DotLed.Common.Drawing;
using DotLed.Domain.Models;
using DotLed.Domain.Services.Animations;

namespace DotLed.Core.Animations
{
	public class AnimationPlayer : IAnimationPlayer, IDisposable
	{
		private Thread _thread;

		private CancellationToken _payerCancellationToken;
		private bool disposedValue;

		/// <summary>
		/// The led strip to function on.
		/// </summary>
		public LedStrip LedStrip { get; init; }
		

		/// <summary>
		/// The animation that it should play.
		/// </summary>
		public Animation Animation { get; protected set; }

		/// <summary>
		/// Is the player running.
		/// </summary>
		public bool IsRunning => _thread.ThreadState.HasFlag(ThreadState.Running);



		public AnimationPlayer(LedStrip ledStrip, Animation animation)
		{
			if (ledStrip.SpiBus is null)
			{
				throw new ArgumentNullException(nameof(ledStrip));
			}

			if (animation.Sequence.AnimationSequences is null)
			{
				throw new ArgumentOutOfRangeException(nameof(animation));
			}

			LedStrip.SpiBus.Connect();

			LedStrip = ledStrip;

			Animation = animation;

			_payerCancellationToken = new CancellationToken(false);

			_thread = new Thread(new ThreadStart(SequencePlayer));
			_thread.Name = $"{LedStrip.Name}-{animation.Name}-animation-player";
			_thread.IsBackground = true;
		}

		protected virtual void SequencePlayer()
		{
			do
			{
				foreach (IEnumerable<Color> colorArray in Animation.Sequence.AnimationSequences)
				{
					LedStrip.Leds.SetLedsColors(new Span<Color>(colorArray.ToArray()));

					LedStrip.Update();
					
					Thread.Sleep(1000 / Animation.PlayFrequency);
				}
			}
			while (!_payerCancellationToken.IsCancellationRequested);
		}

		public void ChangeAnimation(Animation animation)
		{
			bool wasRunning = IsRunning;
			if (IsRunning)
			{
				Stop();
			}

			Animation = animation;

			if (wasRunning)
			{
				Start();
			}
		}


		public void Start()
		{
			// Renew the cancellation token.
			_payerCancellationToken = new CancellationToken(false);

			_thread.Start();
		}

		public void Stop()
		{
			_payerCancellationToken = new CancellationToken(true);

			_thread.Join();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					LedStrip.SpiBus.Disconnect();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~AnimationPlayer()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
