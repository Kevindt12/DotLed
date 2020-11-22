using System;
using System.Linq;

using DotLed.Common.Drawing;
using DotLed.Domain.Models;

namespace DotLed.Domain.Collections
{
	public sealed class LedArray
	{

		private readonly Led[] _leds;
		private readonly int _index;

		/// <summary>
		/// Gets the led on that index.
		/// </summary>
		/// <param name="index">The index of the led.</param>
		/// <returns></returns>
		public Led this[int index] => _leds[index];

		/// <summary>
		/// The length of the led array.
		/// </summary>
		public int Length => _index;


		/// <summary>
		/// The array for the led's.
		/// </summary>
		/// <param name="ledcount">This is the led count of the strip.</param>
		internal LedArray(int ledcount)
		{
			_leds = new Led[ledcount];

			int index = 0;

			// Intalizes all the leds with a new class that we created with this method.
			_leds.ToList().ForEach(x => x = GetNewLedInstance(index++));

			_index = index;
		}

		/// <summary>
		/// Gets a new led instance
		/// </summary>
		/// <returns></returns>
		private Led GetNewLedInstance(int index)
		{
			Led led = new Led(index);

			return led;
		}



		/// <summary>
		/// Sets a set of colors.
		/// </summary>
		/// <param name="colors">The colors you want to set on the leds.</param>
		/// <param name="index">The index of led strip where to start changing the color.</param>
		/// <param name="count">The amount of colors to read from the array</param>
		public void SetLedsColors(Color[] colors, int index, int count)
		{
			int arrayIndex = 0;
			for (int i = index; i < (index + count > Length ? index + count : Length); i++) {

				_leds[i].Color = colors[arrayIndex];

				arrayIndex++;
			}
		}

		public Span<Color> GetColors()
		{
			return _leds.Select(x => x.Color).ToArray().AsSpan();
		}


		/// <summary>
		/// Sets a set of colors.
		/// </summary>
		/// <param name="colors">The colors you want to set on the leds.</param>
		/// <param name="index">The index of led strip where to start changing the color.</param>
		/// <param name="count">The amount of colors to read from the array</param>
		public void SetLedsColors(Span<Color> colors)
		{
			for (int i = 0; i < colors.Length || i < Length; i++)
			{
				_leds[i].Color = colors[i];
			}
		}


		public void Clear()
		{
			// Sets all leds to a black color
			_leds.ToList().ForEach(x => x.Color = new Color(0));
		}

		/// <summary>
		/// Sets a single led to a spesfic color.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="color"></param>
		public void SetLedColor(int index, Color color)
		{
			_leds[index].Color = color;
		}


	}
}
