using System;

using DotLed.Common.Drawing;

namespace DotLed.Domain.Services.LedStrips
{
	public interface ILedStripColorArrayNormalizer
	{

		byte[] GetBytes(Color color);

		byte[] GetBytes(Span<Color> colors);

	}
}
