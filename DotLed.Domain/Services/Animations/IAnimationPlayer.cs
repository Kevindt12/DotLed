using System;

using DotLed.Domain.Models;

namespace DotLed.Domain.Services.Animations
{
	public interface IAnimationPlayer : IDisposable
	{

		LedStrip LedStrip { get; init; }

		Models.Animation Animation { get; }

		bool IsRunning { get; }


		void Start();

		void Stop();


		void ChangeAnimation(Models.Animation animation);



	}
}
