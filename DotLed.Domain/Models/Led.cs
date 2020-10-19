using DotLed.Common.Drawing;

namespace DotLed.Domain.Models
{
	public class Led
	{

		/// <summary>
		/// The index of the led.
		/// </summary>
		public int Index { get; private set; }

		/// <summary>
		/// The color of the led.
		/// </summary>
		public Color Color { get; set; }


		/// <summary>
		/// This is a led on a led strip. This is the instance that can be manipulated.
		/// </summary>
		internal Led(int index)
		{
			Index = index;
		}



	}
}
